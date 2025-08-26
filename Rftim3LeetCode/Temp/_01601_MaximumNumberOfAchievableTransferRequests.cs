using System.Numerics;

namespace Rftim3LeetCode.Temp
{
    public class _01601_MaximumNumberOfAchievableTransferRequests
    {
        /// <summary>
        /// We have n buildings numbered from 0 to n - 1. 
        /// Each building has a number of employees. 
        /// It's transfer season, and some employees want to change the building they reside in.
        /// You are given an array requests where requests[i] = [fromi, toi] represents an employee's request to transfer from building fromi to building toi.
        /// All buildings are full, so a list of requests is achievable only if for each building, the net change in employee transfers is zero.
        /// This means the number of employees leaving is equal to the number of employees moving in. 
        /// For example if n = 3 and two employees are leaving building 0, one is leaving building 1, and one is leaving building 2, 
        /// there should be two employees moving to building 0, one employee moving to building 1, and one employee moving to building 2.
        /// Return the maximum number of achievable requests.
        /// </summary>
        public _01601_MaximumNumberOfAchievableTransferRequests()
        {
            Console.WriteLine(MaximumRequests(5,
            [
                [0,1],
                [1,0],
                [0,1],
                [1,2],
                [2,0],
                [3,4]
            ]));
            Console.WriteLine(MaximumRequests(3,
            [
                [0,0],
                [1,2],
                [2,1]
            ]));
            Console.WriteLine(MaximumRequests(4,
            [
                [0,3],
                [3,1],
                [1,2],
                [2,0]
            ]));
        }

        // Bitmasking
        private static int MaximumRequests(int n, int[][] requests)
        {
            int answer = 0;

            for (int mask = 0; mask < 1 << requests.Length; mask++)
            {
                int[] indegree = new int[n];
                int pos = requests.Length - 1;
                //int bitCount = int.PopCount(mask);
                int bitCount = BitOperations.PopCount((uint)mask);

                if (bitCount <= answer) continue;

                for (int curr = mask; curr > 0; curr >>= 1, pos--)
                {
                    if ((curr & 1) == 1)
                    {
                        indegree[requests[pos][0]]--;
                        indegree[requests[pos][1]]++;
                    }
                }

                bool flag = true;
                for (int i = 0; i < n; i++)
                {
                    if (indegree[i] != 0)
                    {
                        flag = false;
                        break;
                    }
                }

                if (flag) answer = bitCount;
            }

            return answer;
        }

        // Bactracking
        private static int maxRequests = 0;

        private static int MaximumRequests0(int n, int[][] requests)
        {
            MaxRequests(requests, 0, [], new int[n]);

            return maxRequests;
        }

        private static void MaxRequests(int[][] requests, int ind, List<int[]> requestsConsidered, int[] netRequests)
        {
            if (CanRequestsBeFulfilled(netRequests)) maxRequests = Math.Max(maxRequests, requestsConsidered.Count);

            for (int i = ind; i < requests.Length; i++)
            {
                requestsConsidered.Add(requests[i]);
                netRequests[requests[i][0]]--;
                netRequests[requests[i][1]]++;
                MaxRequests(requests, i + 1, requestsConsidered, netRequests);
                netRequests[requests[i][0]]++;
                netRequests[requests[i][1]]--;
                requestsConsidered.RemoveAt(requestsConsidered.Count - 1);
            }
        }

        private static bool CanRequestsBeFulfilled(int[] netRequests)
        {
            for (int i = 0; i < netRequests.Length; i++)
            {
                if (netRequests[i] != 0) return false;
            }

            return true;
        }
    }
}
