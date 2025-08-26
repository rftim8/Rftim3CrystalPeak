namespace Rftim3LeetCode.Temp
{
    public class _00804_UniqueMorseCodeWords
    {
        /// <summary>
        /// International Morse Code defines a standard encoding where each letter is mapped to a series of dots and dashes, as follows:
        /// 'a' maps to ".-",
        /// 'b' maps to "-...",
        /// 'c' maps to "-.-.", and so on.
        ///         For convenience, the full table for the 26 letters of the English alphabet is given below:
        /// 
        /// [".-","-...","-.-.","-..",".","..-.","--.","....","..",".---","-.-",".-..","--","-.","---",".--.","--.-",".-.","...","-","..-","...-",".--","-..-","-.--","--.."]
        /// Given an array of strings words where each word can be written as a concatenation of the Morse code of each letter.
        /// For example, "cab" can be written as "-.-..--...", which is the concatenation of "-.-.", ".-", and "-...". We will call such a concatenation the transformation of a word.
        /// Return the number of different transformations among all words we have.
        /// </summary>
        public _00804_UniqueMorseCodeWords()
        {
            Console.WriteLine(UniqueMorseRepresentations(["gin", "zen", "gig", "msg"]));
            Console.WriteLine(UniqueMorseRepresentations(["a"]));
        }

        private static int UniqueMorseRepresentations(string[] words)
        {
            int n = words.Length;
            string[] a = [".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--.."];
            string b = "abcdefghijklmnopqrstuvwxyz";

            HashSet<string> r = [];
            for (int i = 0; i < n; i++)
            {
                string t = "";
                for (int j = 0; j < words[i].Length; j++)
                {
                    t += a[b.IndexOf(words[i][j])];
                }
                r.Add(t);
            }

            return r.Count;
        }
    }
}
