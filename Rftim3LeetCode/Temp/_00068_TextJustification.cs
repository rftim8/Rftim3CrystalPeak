using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00068_TextJustification
    {
        /// <summary>
        /// Given an array of strings words and a width maxWidth, format the text such that each line has exactly maxWidth characters and is fully (left and right) justified.
        /// You should pack your words in a greedy approach; that is, pack as many words as you can in each line.
        /// Pad extra spaces ' ' when necessary so that each line has exactly maxWidth characters.
        /// Extra spaces between words should be distributed as evenly as possible.
        /// If the number of spaces on a line does not divide evenly between words, the empty slots on the left will be assigned more spaces than the slots on the right.
        /// For the last line of text, it should be left-justified, and no extra space is inserted between words.
        /// Note:
        /// A word is defined as a character sequence consisting of non-space characters only.
        /// Each word's length is guaranteed to be greater than 0 and not exceed maxWidth.
        /// The input array words contains at least one word.
        /// </summary>
        public _00068_TextJustification()
        {
            IList<string> x = FullJustify(
                [
                    "This","is","an","example","of","text","justification"
                ],
                16
            );

            IList<string> x0 = FullJustify(
                [
                    "What","must","be","acknowledgment","shall","be"
                ],
                16
            );

            IList<string> x1 = FullJustify(
                [
                    "Science","is","what","we","understand","well","enough","to","explain","to","a","computer.","Art","is","everything","else","we","do"
                ],
                20
            );

            RftTerminal.RftReadResult(x);
            RftTerminal.RftReadResult(x0);
            RftTerminal.RftReadResult(x1);
        }

        private static List<string> FullJustify(string[] words, int maxWidth)
        {
            List<string> ans = [];
            int i = 0;

            while (i < words.Length)
            {
                List<string> currentLine = GetWords(i, words, maxWidth);
                i += currentLine.Count;
                ans.Add(CreateLine(currentLine, i, words, maxWidth));
            }

            return ans;
        }

        private static List<string> GetWords(int i, string[] words, int maxWidth)
        {
            List<string> currentLine = [];
            int currLength = 0;

            while (i < words.Length && currLength + words[i].Length <= maxWidth)
            {
                currentLine.Add(words[i]);
                currLength += words[i].Length + 1;
                i++;
            }

            return currentLine;
        }

        private static string CreateLine(List<string> line, int i, string[] words, int maxWidth)
        {
            int baseLength = -1;
            foreach (string word in line)
            {
                baseLength += word.Length + 1;
            }

            int extraSpaces = maxWidth - baseLength;

            if (line.Count == 1 || i == words.Length)
            {
                return string.Join(" ", line) + string.Concat(Enumerable.Repeat(" ", extraSpaces));
            }

            int wordCount = line.Count - 1;
            int spacesPerWord = extraSpaces / wordCount;
            int needsExtraSpace = extraSpaces % wordCount;

            for (int j = 0; j < needsExtraSpace; j++)
            {
                line[j] = line[j] + " ";
            }

            for (int j = 0; j < wordCount; j++)
            {
                line[j] = line[j] + string.Concat(Enumerable.Repeat(" ", spacesPerWord));
            }

            return string.Join(" ", line);
        }
    }
}
