namespace Rftim3LeetCode.Temp
{
    public class _02024_MaximizeTheConfusionOfAnExam
    {
        /// <summary>
        /// A teacher is writing a test with n true/false questions, with 'T' denoting true and 'F' denoting false. 
        /// He wants to confuse the students by maximizing the number of consecutive questions with the same answer (multiple trues or multiple falses in a row).
        /// You are given a string answerKey, where answerKey[i] is the original answer to the ith question.
        /// In addition, you are given an integer k, the maximum number of times you may perform the following operation:
        /// Change the answer key for any question to 'T' or 'F' (i.e., set answerKey[i] to 'T' or 'F').
        /// Return the maximum number of consecutive 'T's or 'F's in the answer key after performing the operation at most k times.
        /// </summary>
        public _02024_MaximizeTheConfusionOfAnExam()
        {
            Console.WriteLine(MaxConsecutiveAnswers("TTFF", 2));
            Console.WriteLine(MaxConsecutiveAnswers("TFFT", 1));
            Console.WriteLine(MaxConsecutiveAnswers("TTFTTFTT", 1));
        }

        // Binary search + fixed size sliding window
        private static int MaxConsecutiveAnswers(string answerKey, int k)
        {
            int n = answerKey.Length;
            int left = k, right = n;

            while (left < right)
            {
                int mid = (left + right + 1) / 2;

                if (IsValid(answerKey, mid, k)) left = mid;
                else right = mid - 1;
            }

            return left;
        }

        private static bool IsValid(string answerKey, int size, int k)
        {
            int n = answerKey.Length;
            Dictionary<char, int> counter = [];

            for (int i = 0; i < size; i++)
            {
                if (counter.TryGetValue(answerKey[i], out int value)) counter[answerKey[i]] = ++value;
                else counter.Add(answerKey[i], 1);
            }

            if (Math.Min(counter['T'], counter['F']) <= k) return true;

            for (int i = size; i < n; i++)
            {
                char c1 = answerKey[i];
                counter[c1]++;
                char c2 = answerKey[i - size];
                counter[c2]--;

                if (Math.Min(counter['T'], counter['F']) <= k) return true;
            }

            return false;
        }

        // Sliding window
        private static int MaxConsecutiveAnswers0(string answerKey, int k)
        {
            int maxSize = k;
            Dictionary<char, int> count = [];
            for (int i = 0; i < k; i++)
            {
                if (count.TryGetValue(answerKey[i], out int value)) count[answerKey[i]] = ++value;
                else count.Add(answerKey[i], 1);
            }

            int left = 0;
            for (int right = k; right < answerKey.Length; right++)
            {
                if (count.TryGetValue(answerKey[right], out int value)) count[answerKey[right]] = ++value;
                else count.Add(answerKey[right], 1);

                while (Math.Min(count.TryGetValue('T', out int value1) ? value1 : 0, count.TryGetValue('F', out int value0) ? value0 : 0) > k)
                {
                    count[answerKey[left]]--;
                    left++;
                }

                maxSize = Math.Max(maxSize, right - left + 1);
            }

            return maxSize;
        }

        // Advanced sliding window
        private static int MaxConsecutiveAnswers1(string answerKey, int k)
        {
            int maxSize = 0;
            Dictionary<char, int> count = [];

            for (int right = 0; right < answerKey.Length; right++)
            {
                if (count.ContainsKey(answerKey[right])) count[answerKey[right]]++;
                else count.Add(answerKey[right], 1);

                int minor = Math.Min(count.TryGetValue('T', out int value) ? value : 0, count.TryGetValue('F', out int value0) ? value0 : 0);

                if (minor <= k) maxSize++;
                else count[answerKey[right - maxSize]]--;
            }

            return maxSize;
        }

        private static int MaxConsecutiveAnswers2(string answerKey, int k)
        {
            int max = 0;
            int[] count = new int[128];
            int i = 0;

            for (int j = 0; j < answerKey.Length; j++)
            {
                max = Math.Max(max, ++count[answerKey[j]]);
                if (j - i + 1 > max + k) count[answerKey[i++]]--;
            }

            return answerKey.Length - i;
        }
    }
}
