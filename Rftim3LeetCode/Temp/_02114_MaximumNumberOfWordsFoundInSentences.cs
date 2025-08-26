namespace Rftim3LeetCode.Temp
{
    public class _02114_MaximumNumberOfWordsFoundInSentences
    {
        /// <summary>
        /// A sentence is a list of words that are separated by a single space with no leading or trailing spaces.
        /// You are given an array of strings sentences, where each sentences[i] represents a single sentence.
        /// Return the maximum number of words that appear in a single sentence.
        /// </summary>
        public _02114_MaximumNumberOfWordsFoundInSentences()
        {
            Console.WriteLine(MaximumNumberOfWordsFoundInSentences0(["alice and bob love leetcode", "i think so too", "this is great thanks very much"]));
            Console.WriteLine(MaximumNumberOfWordsFoundInSentences0(["please wait", "continue to fight", "continue to win"]));
        }

        public static int MaximumNumberOfWordsFoundInSentences0(string[] a0) => RftMaximumNumberOfWordsFoundInSentences0(a0);

        private static int RftMaximumNumberOfWordsFoundInSentences0(string[] sentences)
        {
            int r = 0;

            for (int i = 0; i < sentences.Length; i++)
            {
                r = Math.Max(r, sentences[i].Split(' ').Length);
            }

            return r;
        }
    }
}