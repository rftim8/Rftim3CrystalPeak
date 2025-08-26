namespace Rftim3LeetCode.Temp
{
    public class _00925_LongPressedName
    {
        /// <summary>
        /// Your friend is typing his name into a keyboard. Sometimes, when typing a character c, the key might get long pressed, and the character will be typed 1 or more times.
        /// You examine the typed characters of the keyboard.
        /// Return True if it is possible that it was your friends name, with some characters (possibly none) being long pressed.
        /// </summary>
        public _00925_LongPressedName()
        {
            Console.WriteLine(IsLongPressedName("alex", "aaleex"));
            Console.WriteLine(IsLongPressedName("saeed", "ssaaedd"));
            Console.WriteLine(IsLongPressedName("vtkgn", "vttkgnn"));
            Console.WriteLine(IsLongPressedName("rick", "kric"));
        }

        private static bool IsLongPressedName(string name, string typed)
        {
            int n = name.Length;
            int m = typed.Length;

            if (n > m) return false;

            List<(char, int)> l0 = [];
            (char, int) l = new(name[0], 1);

            if (n == 1) l0.Add(l);
            else
            {
                for (int i = 1; i < n; i++)
                {
                    if (name[i - 1] == name[i]) l.Item2++;
                    else
                    {
                        l0.Add(l);
                        l.Item1 = name[i];
                        l.Item2 = 1;
                    }
                    if (i == n - 1) l0.Add(l);
                }
            }

            List<(char, int)> r0 = [];
            (char, int) r = new(typed[0], 1);

            if (m == 1) return name == typed;
            else
            {
                for (int i = 1; i < m; i++)
                {
                    if (typed[i - 1] == typed[i]) r.Item2++;
                    else
                    {
                        r0.Add(r);
                        r.Item1 = typed[i];
                        r.Item2 = 1;
                    }
                    if (i == m - 1) r0.Add(r);
                }
            }

            if (l0.Count != r0.Count) return false;

            for (int i = 0; i < l0.Count; i++)
            {
                if (l0[i].Item1 != r0[i].Item1) return false;
                else
                {
                    if (l0[i].Item2 > r0[i].Item2) return false;
                }
            }

            return true;
        }

        private static bool IsLongPressedName0(string name, string typed)
        {
            int m = name.Length;
            int n = typed.Length;
            if (n < m) return false;

            int i = 0;
            int j = 0;

            while (j < n)
            {
                if (i < m && name[i] == typed[j]) i++;
                else if (j == 0 || typed[j] != typed[j - 1]) return false;

                j++;
            }

            return i >= m;
        }
    }
}
