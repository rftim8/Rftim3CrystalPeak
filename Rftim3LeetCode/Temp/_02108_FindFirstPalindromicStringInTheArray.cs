namespace Rftim3LeetCode.Temp
{
    public class _02108_FindFirstPalindromicStringInTheArray
    {
        /// <summary>
        /// Given an array of strings words, return the first palindromic string in the array. 
        /// If there is no such string, return an empty string "".
        /// A string is palindromic if it reads the same forward and backward.
        /// </summary>
        public _02108_FindFirstPalindromicStringInTheArray()
        {
            Console.WriteLine(FirstPalindrome(["abc", "car", "ada", "racecar", "cool"]));
            Console.WriteLine(FirstPalindrome(["notapalindrome", "racecar"]));
            Console.WriteLine(FirstPalindrome(["def", "ghi"]));
        }

        private static string FirstPalindrome0(string[] words)
        {
            foreach (string item in words)
            {
                int n = item.Length;
                int m = n / 2;
                if (n % 2 == 0)
                {
                    if (item[..m] == string.Concat(item[m..].Reverse())) return item;
                }
                else
                {
                    if (item[..m] == string.Concat(item[(m + 1)..].Reverse())) return item;
                }
            }

            return "";
        }

        private static string FirstPalindrome(string[] words)
        {
            foreach (string item in words)
            {
                int l = 0, r = item.Length - 1;

                while (l <= r)
                {
                    if (item[l] != item[r]) break;

                    l++;
                    r--;
                    if (l >= r) return item;
                }
            }

            return "";
        }
    }
}
