using System.Text;

namespace Rftim3LeetCode.Temp
{
    public class _02785_SortVowelsInAString
    {
        /// <summary>
        /// Given a 0-indexed string s, permute s to get a new string t such that:
        /// 
        /// All consonants remain in their original places.More formally, if there is an index i with 0 <= i<s.length such that s[i] is a consonant, then t[i] = s[i].
        /// The vowels must be sorted in the nondecreasing order of their ASCII values.More formally, for pairs of indices i, j with 0 <= i<j<s.length such that s[i] 
        /// and s[j] are vowels, then t[i] must not have a higher ASCII value than t[j].
        /// Return the resulting string.
        /// 
        /// The vowels are 'a', 'e', 'i', 'o', and 'u', and they can appear in lowercase or uppercase.Consonants comprise all letters that are not vowels.
        /// </summary>
        public _02785_SortVowelsInAString()
        {
            Console.WriteLine(SortVowels0("lEetcOde"));
            Console.WriteLine(SortVowels0("lYmpH"));
        }

        public static string SortVowels0(string a0) => RftSortVowels0(a0);

        private static string RftSortVowels0(string s)
        {
            List<char> x = [];
            List<int> y = [];
            char[] z = ['A', 'E', 'I', 'O', 'U', 'a', 'e', 'i', 'o', 'u'];

            StringBuilder sb = new(s);
            for (int i = 0; i < sb.Length; i++)
            {
                if (z.Contains(sb[i]))
                {
                    x.Add(sb[i]);
                    y.Add(i);
                }
            }

            x.Sort();
            for (int i = 0; i < x.Count; i++)
            {
                sb[y[i]] = x[i];
            }

            return sb.ToString();
        }
    }
}
