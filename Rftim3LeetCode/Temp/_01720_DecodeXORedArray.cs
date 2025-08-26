using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _01720_DecodeXORedArray
    {
        /// <summary>
        /// There is a hidden integer array arr that consists of n non-negative integers.
        /// It was encoded into another integer array encoded of length n - 1, such that encoded[i] = arr[i] XOR arr[i + 1]. 
        /// For example, if arr = [1,0,2,1], then encoded = [1, 2, 3].
        /// You are given the encoded array.You are also given an integer first, that is the first element of arr, i.e.arr[0].
        /// Return the original array arr.It can be proved that the answer exists and is unique.
        /// </summary>
        public _01720_DecodeXORedArray()
        {
            int[] x = Decode([1, 2, 3], 1);
            int[] x0 = Decode([6, 2, 7, 3], 4);

            RftTerminal.RftReadResult(x);
            RftTerminal.RftReadResult(x0);
        }

        private static int[] Decode(int[] encoded, int first)
        {
            int n = encoded.Length;

            List<int> r = [first];
            for (int i = 0; i < n; i++)
            {
                int j = 0;
                while ((first ^ j) != encoded[i])
                {
                    j++;
                }
                r.Add(j);
                first = j;
            }

            return [.. r];
        }

        private static int[] Decode0(int[] encoded, int first)
        {

            int[] answer = new int[encoded.Length + 1];

            answer[0] = first;

            for (int i = 0; i < answer.Length - 1; i++)
            {
                answer[i + 1] = answer[i] ^ encoded[i];
            }

            return answer;

        }
    }
}
