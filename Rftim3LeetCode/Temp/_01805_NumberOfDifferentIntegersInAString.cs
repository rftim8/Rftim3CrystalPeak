namespace Rftim3LeetCode.Temp
{
    public class _01805_NumberOfDifferentIntegersInAString
    {
        /// <summary>
        /// You are given a string word that consists of digits and lowercase English letters.
        /// You will replace every non-digit character with a space.For example, "a123bc34d8ef34" will become " 123  34 8  34". 
        /// Notice that you are left with some integers that are separated by at least one space: "123", "34", "8", and "34".
        /// Return the number of different integers after performing the replacement operations on word.
        /// Two integers are considered different if their decimal representations without any leading zeros are different.
        /// </summary>
        public _01805_NumberOfDifferentIntegersInAString()
        {
            Console.WriteLine(NumDifferentIntegers("a123bc34d8ef34"));
            Console.WriteLine(NumDifferentIntegers("leet1234code234"));
            Console.WriteLine(NumDifferentIntegers("a1b01c001"));
            Console.WriteLine(NumDifferentIntegers("gi851a851q8510v"));
            Console.WriteLine(NumDifferentIntegers("0a0"));
            Console.WriteLine(NumDifferentIntegers("sh8s0"));
        }

        private static int NumDifferentIntegers(string word)
        {
            int n = word.Length;
            HashSet<string> r = [];

            string t = "";
            int z = 0;
            for (int i = 0; i < n; i++)
            {
                if (char.IsDigit(word[i]))
                {
                    if (t == "" && word[i] == '0') z++;
                    else t += word[i];

                    if (i == n - 1)
                    {
                        if (z > 0 && t == "") r.Add("0");
                        else if (t != "") r.Add(t);
                    }
                }
                else
                {
                    if (t != "") r.Add(t);
                    else if (z > 0) r.Add("0");
                    t = "";
                    z = 0;
                }
            }

            return r.Count;
        }

        private static int NumDifferentIntegers0(string word)
        {
            int n = word.Length, i = 0;
            HashSet<string> h = [];
            while (i < n)
            {
                if (!char.IsDigit(word[i]))
                {
                    i++;
                    continue;
                }
                int t = i + 1;
                while (t < n && char.IsDigit(word[t]))
                {
                    t++;
                    if (word[i] == '0') i++;
                }
                h.Add(word[i..t]);
                i = t;
            }

            return h.Count;
        }
    }
}
