namespace Rftim3LeetCode.Temp
{
    public class _01642_FurthestBuildingYouCanReach
    {
        /// <summary>
        /// You are given an integer array heights representing the heights of buildings, some bricks, and some ladders.
        /// 
        /// You start your journey from building 0 and move to the next building by possibly using bricks or ladders.
        /// 
        /// While moving from building i to building i+1 (0-indexed),
        /// 
        /// If the current building's height is greater than or equal to the next building's height, you do not need a ladder or bricks.
        /// If the current building's height is less than the next building's height, you can either use one ladder or (h[i + 1] - h[i]) bricks.
        /// Return the furthest building index(0-indexed) you can reach if you use the given ladders and bricks optimally.
        /// </summary>
        public _01642_FurthestBuildingYouCanReach()
        {
            Console.WriteLine(FurthestBuildingYouCanReach0([4, 2, 7, 6, 9, 14, 12], 5, 1));
            Console.WriteLine(FurthestBuildingYouCanReach0([4, 12, 2, 7, 3, 18, 20, 3, 19], 10, 2));
            Console.WriteLine(FurthestBuildingYouCanReach0([14, 3, 19, 3], 17, 0));
        }

        public static int FurthestBuildingYouCanReach0(int[] a0, int a1, int a2) => RftFurthestBuildingYouCanReach0(a0, a1, a2);

        public static int FurthestBuildingYouCanReach1(int[] a0, int a1, int a2) => RftFurthestBuildingYouCanReach1(a0, a1, a2);

        public static int FurthestBuildingYouCanReach2(int[] a0, int a1, int a2) => RftFurthestBuildingYouCanReach2(a0, a1, a2);

        public static int FurthestBuildingYouCanReach3(int[] a0, int a1, int a2) => RftFurthestBuildingYouCanReach3(a0, a1, a2);

        public static int FurthestBuildingYouCanReach4(int[] a0, int a1, int a2) => RftFurthestBuildingYouCanReach4(a0, a1, a2);

        public static int FurthestBuildingYouCanReach5(int[] a0, int a1, int a2) => RftFurthestBuildingYouCanReach5(a0, a1, a2);

        // Min-Heap
        private static int RftFurthestBuildingYouCanReach0(int[] heights, int bricks, int ladders)
        {
            PriorityQueue<int, int> ladderAllocations = new(Comparer<int>.Create((a, b) => a - b));
            for (int i = 0; i < heights.Length - 1; i++)
            {
                int climb = heights[i + 1] - heights[i];
                if (climb <= 0) continue;

                ladderAllocations.Enqueue(climb, climb);

                if (ladderAllocations.Count <= ladders) continue;

                bricks -= ladderAllocations.Dequeue();

                if (bricks < 0) return i;
            }

            return heights.Length - 1;
        }

        // Max-Heap
        private static int RftFurthestBuildingYouCanReach1(int[] heights, int bricks, int ladders)
        {
            PriorityQueue<int, int> brickAllocations = new(Comparer<int>.Create((a, b) => b - a));
            for (int i = 0; i < heights.Length - 1; i++)
            {
                int climb = heights[i + 1] - heights[i];
                if (climb <= 0) continue;

                brickAllocations.Enqueue(climb, climb);
                bricks -= climb;

                if (bricks < 0 && ladders == 0) return i;

                if (bricks < 0)
                {
                    bricks += brickAllocations.Dequeue();
                    ladders--;
                }
            }

            return heights.Length - 1;
        }

        // BS for final reacheable building
        private static int RftFurthestBuildingYouCanReach2(int[] heights, int bricks, int ladders)
        {
            int lo = 0;
            int hi = heights.Length - 1;
            while (lo < hi)
            {
                int mid = lo + (hi - lo + 1) / 2;
                if (IsReachable(mid, heights, bricks, ladders)) lo = mid;
                else hi = mid - 1;
            }

            return hi;
        }

        private static bool IsReachable(int buildingIndex, int[] heights, int bricks, int ladders)
        {
            List<int> climbs = [];
            for (int i = 0; i < buildingIndex; i++)
            {
                int h1 = heights[i];
                int h2 = heights[i + 1];

                if (h2 <= h1) continue;

                climbs.Add(h2 - h1);
            }
            climbs.Sort();

            foreach (int climb in climbs)
            {
                if (climb <= bricks) bricks -= climb;
                else if (ladders >= 1) ladders -= 1;
                else return false;
            }

            return true;
        }

        // Improved BS for final reacheable building
        private static int RftFurthestBuildingYouCanReach3(int[] heights, int bricks, int ladders)
        {
            List<int[]> sortedClimbs = [];
            for (int i = 0; i < heights.Length - 1; i++)
            {
                int climb = heights[i + 1] - heights[i];
                if (climb <= 0) continue;

                sortedClimbs.Add([climb, i + 1]);
            }
            sortedClimbs.Sort((a, b) => a[0] - b[0]);

            int lo = 0;
            int hi = heights.Length - 1;
            while (lo < hi)
            {
                int mid = lo + (hi - lo + 1) / 2;
                if (IsReachable0(mid, sortedClimbs, bricks, ladders)) lo = mid;
                else hi = mid - 1;
            }

            return hi;
        }

        private static bool IsReachable0(int buildingIndex, List<int[]> climbs, int bricks, int ladders)
        {
            foreach (int[] climbEntry in climbs)
            {
                int climb = climbEntry[0];
                int index = climbEntry[1];
                if (index > buildingIndex) continue;
                if (climb <= bricks) bricks -= climb;
                else if (ladders >= 1) ladders -= 1;
                else return false;
            }

            return true;
        }

        // BS on threshold
        private static int RftFurthestBuildingYouCanReach4(int[] heights, int bricks, int ladders)
        {
            int lo = int.MaxValue;
            int hi = int.MinValue;
            for (int i = 0; i < heights.Length - 1; i++)
            {
                int climb = heights[i + 1] - heights[i];
                if (climb <= 0) continue;

                lo = Math.Min(lo, climb);
                hi = Math.Max(hi, climb);
            }
            if (lo == int.MaxValue) return heights.Length - 1;

            while (lo <= hi)
            {
                int mid = lo + (hi - lo) / 2;
                int[] result = SolveWithGivenThreshold(heights, bricks, ladders, mid);
                int indexReached = result[0];
                int laddersRemaining = result[1];
                int bricksRemaining = result[2];
                if (indexReached == heights.Length - 1) return heights.Length - 1;
                if (laddersRemaining > 0)
                {
                    hi = mid - 1;
                    continue;
                }

                int nextClimb = heights[indexReached + 1] - heights[indexReached];
                if (nextClimb > bricksRemaining && mid > bricksRemaining) return indexReached;
                else lo = mid + 1;
            }

            return -1;
        }

        private static int[] SolveWithGivenThreshold(int[] heights, int bricks, int ladders, int K)
        {
            int laddersUsedOnThreshold = 0;
            for (int i = 0; i < heights.Length - 1; i++)
            {
                int climb = heights[i + 1] - heights[i];
                if (climb <= 0) continue;
                if (climb == K)
                {
                    laddersUsedOnThreshold++;
                    ladders--;
                }
                else if (climb > K) ladders--;
                else bricks -= climb;

                if (ladders < 0)
                {
                    if (laddersUsedOnThreshold >= 1)
                    {
                        laddersUsedOnThreshold--;
                        ladders++;
                        bricks -= K;
                    }
                    else return [i, ladders, bricks];
                }
                if (bricks < 0) return [i, ladders, bricks];
            }

            return [heights.Length - 1, ladders, bricks];
        }

        private static int RftFurthestBuildingYouCanReach5(int[] heights, int bricks, int ladders)
        {
            PriorityQueue<int, int> heap = new();
            int i = 0;
            while (i < heights.Length - 1)
            {
                int difference = heights[i + 1] - heights[i];
                if (difference <= 0)
                {
                    i++;
                    continue;
                }
                if (bricks >= difference)
                {
                    heap.Enqueue(difference, -difference);
                    bricks -= difference;
                }
                else if (ladders > 0)
                {
                    if (heap.Count > 0 && heap.Peek() > difference)
                    {
                        bricks += heap.Dequeue();
                        ladders--;
                        i--;
                    }
                    else ladders--;
                }
                else break;

                i++;
            }

            return i;
        }
    }
}
