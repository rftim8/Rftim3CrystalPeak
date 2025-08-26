namespace Rftim3LeetCode.Temp
{
    public class _02047_NumberOfValidWordsInASentence
    {
        /// <summary>
        /// A sentence consists of lowercase letters ('a' to 'z'), digits ('0' to '9'), hyphens ('-'), punctuation marks ('!', '.', and ','), and spaces (' ') only. 
        /// Each sentence can be broken down into one or more tokens separated by one or more spaces ' '.
        /// A token is a valid word if all three of the following are true:
        /// It only contains lowercase letters, hyphens, and/or punctuation(no digits).
        /// There is at most one hyphen '-'. If present, it must be surrounded by lowercase characters("a-b" is valid, but "-ab" and "ab-" are not valid).
        /// There is at most one punctuation mark.If present, it must be at the end of the token("ab,", "cd!", and "." are valid, but "a!b" and "c.," are not valid).
        /// Examples of valid words include "a-b.", "afad", "ba-c", "a!", and "!".
        /// Given a string sentence, return the number of valid words in sentence.
        /// </summary>
        public _02047_NumberOfValidWordsInASentence()
        {
            Console.WriteLine(CountValidWords("cat and  dog"));
            Console.WriteLine(CountValidWords("!this  1-s b8d!"));
            Console.WriteLine(CountValidWords("alice and  bob are playing stone-game10"));
        }

        private static int CountValidWords(string sentence)
        {
            List<string> r = sentence.Split(' ').Where(o => !string.IsNullOrEmpty(o)).ToList();

            int cnt = 0;
            foreach (string item in r)
            {
                if (item.Count(c => c == '-') > 1 || item.Count(c => c == '!') > 1 || item.Count(c => c == '.') > 1 || item.Count(c => c == ',') > 1) continue;
                if (item.Contains('-'))
                {
                    int pos = item.IndexOf('-');
                    if (pos == 0 || pos == item.Length - 1) continue;
                    if (item[pos - 1] < 'a' || item[pos - 1] > 'z' || item[pos + 1] < 'a' || item[pos + 1] > 'z') continue;
                }


                if (item.Contains('!') && item.IndexOf('!') != item.Length - 1
                 || item.Contains('.') && item.IndexOf('.') != item.Length - 1
                 || item.Contains(',') && item.IndexOf(',') != item.Length - 1) continue;
                if (item.Any(c => c >= '0' && c <= '9')) continue;

                cnt++;
            }

            return cnt;
        }

        private static int CountValidWords0(string sentence)
        {
            string[] words = sentence.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int validWordCount = 0;

            foreach (string word in words)
            {
                bool isValidWord = true;
                int hyphensCount = 0;

                for (int index = 0; index < word.Length; index++)
                {
                    if (char.IsLetter(word[index]) && char.IsLower(word[index])) continue;
                    else if (word[index] == '-' && index > 0 && index < word.Length - 1 && hyphensCount == 0 && char.IsLetter(word[index - 1]) && char.IsLetter(word[index + 1]))
                    {
                        hyphensCount++;
                        continue;
                    }
                    else if ((word[index] == '!' || word[index] == '.' || word[index] == ',') && index == word.Length - 1) continue;

                    isValidWord = false;
                    break;
                }

                validWordCount = isValidWord ? validWordCount + 1 : validWordCount;
            }

            return validWordCount;
        }
    }
}
