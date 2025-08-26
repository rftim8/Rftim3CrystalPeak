using System.Text;

namespace Rftim3LeetCode.Temp
{
    public class _00071_SimplifyPath
    {
        /// <summary>
        /// Given a string path, which is an absolute path (starting with a slash '/') to a file or directory in a Unix-style file system, 
        /// convert it to the simplified canonical path.
        /// In a Unix-style file system, a period '.' refers to the current directory, a double period '..' refers to the directory up a level, 
        /// and any multiple consecutive slashes(i.e. '//') are treated as a single slash '/'. For this problem, any other format of periods such as '...' 
        /// are treated as file/directory names.
        /// The canonical path should have the following format:
        /// The path starts with a single slash '/'.
        /// Any two directories are separated by a single slash '/'.
        /// The path does not end with a trailing '/'.
        /// The path only contains the directories on the path from the root directory to the target file or directory (i.e., no period '.' or double period '..')
        /// Return the simplified canonical path.
        /// </summary>
        public _00071_SimplifyPath()
        {
            Console.WriteLine(SimplifyPath("/home/"));
            Console.WriteLine(SimplifyPath("/../"));
            Console.WriteLine(SimplifyPath("/home//foo/"));
            Console.WriteLine(SimplifyPath("/a/./b/../../c/"));
            Console.WriteLine(SimplifyPath("/a//b////c/d//././/.."));
        }

        private static string SimplifyPath(string path)
        {
            int n = path.Length;

            Stack<string> x = new();
            int c = 0, index = 0;

            for (int i = 0; i < n; i++)
            {
                if (path[i] == '/')
                {
                    if (c == 0)
                    {
                        index = i;
                        c++;
                    }
                    else
                    {
                        string y = path[(index + 1)..i];
                        index = i;
                        if (y == "..")
                        {
                            if (x.Any()) x.Pop();
                        }
                        if (!string.IsNullOrEmpty(y) && y != ".." && y != ".") x.Push(y);
                    }
                }
                if (i == n - 1)
                {
                    string y = path[(index + 1)..n];
                    if (y == "..")
                    {
                        if (x.Any()) x.Pop();
                    }
                    if (!string.IsNullOrEmpty(y) && y != ".." && y != ".") x.Push(y);
                }
            }

            if (!x.Any()) return "/";

            StringBuilder sb = new();
            foreach (string item in x)
            {
                sb.Insert(0, $"/{item}");
            }

            return sb.ToString();
        }

        private static string SimplifyPath0(string path)
        {
            string[] parts = path.Split("/");
            Stack<string> result = new();
            foreach (string part in parts)
            {
                if (part == "") continue;
                if (part == ".") continue;
                if (part == "..")
                {
                    if (result.Any()) result.Pop();
                    continue;
                }
                result.Push(part);
            }

            return "/" + string.Join("/", result.Reverse());
        }
    }
}
