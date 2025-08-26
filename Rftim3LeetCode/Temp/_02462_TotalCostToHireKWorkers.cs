namespace Rftim3LeetCode.Temp
{
    public class _02462_TotalCostToHireKWorkers
    {
        /// <summary>
        /// You are given a 0-indexed integer array costs where costs[i] is the cost of hiring the ith worker.
        /// You are also given two integers k and candidates.
        /// We want to hire exactly k workers according to the following rules:
        /// - You will run k sessions and hire exactly one worker in each session.
        /// - In each hiring session, choose the worker with the lowest cost from either the first candidates workers or the last candidates workers. 
        /// Break the tie by the smallest index.
        ///     - For example, if costs = [3, 2, 7, 7, 1, 2] and candidates = 2, then in the first hiring session, we will choose the 4th worker because they have the lowest cost [3,2,7,7,1,2].
        ///     - In the second hiring session, we will choose 1st worker because they have the same lowest cost as 4th worker but they have the smallest index [3,2,7,7,2]. 
        ///     Please note that the indexing may be changed in the process.
        /// - If there are fewer than candidates workers remaining, choose the worker with the lowest cost among them.Break the tie by the smallest index.
        /// - A worker can only be chosen once.
        /// Return the total cost to hire exactly k workers.
        /// </summary>
        public _02462_TotalCostToHireKWorkers()
        {
            Console.WriteLine(TotalCost([17, 12, 10, 2, 7, 2, 11, 20, 8], 3, 4));
            Console.WriteLine(TotalCost([1, 2, 4, 1], 3, 3));
        }

        private static long TotalCost(int[] costs, int k, int candidates)
        {
            PriorityQueue<int, int> pq1 = new();
            PriorityQueue<int, int> pq2 = new();
            int i = 0, j = costs.Length - 1;
            long totalCost = 0;

            while (k > 0)
            {
                while (pq1.Count < candidates && i <= j)
                {
                    pq1.Enqueue(costs[i], costs[i]);
                    i++;
                }

                while (pq2.Count < candidates && j >= i)
                {
                    pq2.Enqueue(costs[j], costs[j]);
                    j--;
                }

                int p1 = pq1.Count > 0 ? pq1.Peek() : int.MaxValue;
                int p2 = pq2.Count > 0 ? pq2.Peek() : int.MaxValue;

                if (p1 <= p2)
                {
                    totalCost += p1;
                    pq1.TryDequeue(out _, out _);
                }
                else
                {
                    totalCost += p2;
                    pq2.TryDequeue(out _, out _);
                }

                k--;
            }

            return totalCost;
        }

        private static long TotalCost0(int[] costs, int k, int candidates)
        {
            PriorityQueue<int, int> headWorkers = new();
            PriorityQueue<int, int> tailWorkers = new();

            for (int i = 0; i < candidates; i++)
            {
                headWorkers.Enqueue(costs[i], costs[i]);
            }

            for (int i = Math.Max(candidates, costs.Length - candidates); i < costs.Length; i++)
            {
                tailWorkers.Enqueue(costs[i], costs[i]);
            }

            long answer = 0;
            int nextHead = candidates;
            int nextTail = costs.Length - 1 - candidates;

            for (int i = 0; i < k; i++)
            {
                if (tailWorkers.Count == 0 || headWorkers.Count != 0 && headWorkers.Peek() <= tailWorkers.Peek())
                {
                    answer += headWorkers.Dequeue();

                    if (nextHead <= nextTail)
                    {
                        headWorkers.Enqueue(costs[nextHead], costs[nextHead]);
                        nextHead++;
                    }
                }

                else
                {
                    answer += tailWorkers.Dequeue();

                    if (nextHead <= nextTail)
                    {
                        tailWorkers.Enqueue(costs[nextTail], costs[nextTail]);
                        nextTail--;
                    }
                }
            }

            return answer;
        }

        private static long TotalCost1(int[] costs, int k, int candidates)
        {
            PriorityQueue<int[], int[]> pq = new(Comparer<int[]>.Create((a, b) =>
            {
                if (a[0] == b[0]) return a[1] - b[1];

                return a[0] - b[0];
            }));

            for (int i = 0; i < candidates; i++)
            {
                pq.Enqueue([costs[i], 0], [costs[i], 0]);
            }

            for (int i = Math.Max(candidates, costs.Length - candidates); i < costs.Length; i++)
            {
                pq.Enqueue([costs[i], 1], [costs[i], 1]);
            }

            long answer = 0;
            int nextHead = candidates;
            int nextTail = costs.Length - 1 - candidates;

            for (int i = 0; i < k; i++)
            {
                int[] curWorker = pq.Dequeue();
                int curCost = curWorker[0], curSectionId = curWorker[1];
                answer += curCost;

                if (nextHead <= nextTail)
                {
                    if (curSectionId == 0)
                    {
                        pq.Enqueue([costs[nextHead], 0], [costs[nextHead], 0]);
                        nextHead++;
                    }
                    else
                    {
                        pq.Enqueue([costs[nextTail], 1], [costs[nextTail], 1]);
                        nextTail--;
                    }
                }
            }

            return answer;
        }
    }
}
