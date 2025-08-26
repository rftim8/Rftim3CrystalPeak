namespace Rftim3LeetCode.Temp
{
    public class _01306_JumpGame3
    {
        /// <summary>
        /// Given an array of non-negative integers arr, you are initially positioned at start index of the array. 
        /// When you are at index i, you can jump to i + arr[i] or i - arr[i], check if you can reach to any index with value 0.
        /// Notice that you can not jump outside of the array at any time.
        /// </summary>
        public _01306_JumpGame3()
        {
            Console.WriteLine(CanReach([4, 2, 3, 0, 3, 1, 2], 5));
            Console.WriteLine(CanReach([4, 2, 3, 0, 3, 1, 2], 0));
            Console.WriteLine(CanReach([3, 0, 2, 1, 2], 2));
        }

        private static bool CanReach(int[] arr, int start)
        {
            int n = arr.Length;
            bool[] visited = new bool[n];
            Queue<int> q = new();
            q.Enqueue(start);
            visited[start] = true;

            while (q.Count != 0)
            {
                int crt = q.Dequeue();
                if (arr[crt] == 0) return true;

                int l = crt - arr[crt];
                int r = crt + arr[crt];
                if (l >= 0 && !visited[l])
                {
                    q.Enqueue(l);
                    visited[l] = true;
                }
                if (r < n && !visited[r])
                {
                    q.Enqueue(r);
                    visited[r] = true;
                }
            }

            return false;
        }

        private static bool CanReach0(int[] arr, int start)
        {
            bool[] seen = new bool[arr.Length];

            seen[start] = true;

            return Dfs(arr, start, seen);
        }

        private static bool Dfs(int[] arr, int index, bool[] seen)
        {
            if (arr[index] == 0) return true;

            int leftIndex = index + arr[index];
            int rightIndex = index - arr[index];

            bool leftFound = false;
            if (IsValidNeighbor(arr.Length, leftIndex) && !seen[leftIndex])
            {
                seen[leftIndex] = true;
                leftFound = Dfs(arr, leftIndex, seen);
            }

            var rightFound = false;
            if (IsValidNeighbor(arr.Length, rightIndex) && !seen[rightIndex])
            {
                seen[rightIndex] = true;
                rightFound = Dfs(arr, rightIndex, seen);
            }

            return leftFound || rightFound;
        }

        private static bool IsValidNeighbor(int arrLength, int index)
        {
            return index >= 0 && index < arrLength;
        }
    }
}
