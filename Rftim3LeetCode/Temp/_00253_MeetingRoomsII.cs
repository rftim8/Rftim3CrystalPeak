namespace Rftim3LeetCode.Temp
{
    public class _00253_MeetingRoomsII
    {
        /// <summary>
        /// Given an array of meeting time intervals intervals where intervals[i] = [starti, endi], 
        /// return the minimum number of conference rooms required.
        /// </summary>
        public _00253_MeetingRoomsII()
        {
            Console.WriteLine(MinMeetingRooms0([[0, 30], [5, 10], [15, 20]]));
            Console.WriteLine(MinMeetingRooms0([[7, 10], [2, 4]]));
        }

        public static int MinMeetingRooms0(int[][] a0) => RftMinMeetingRooms0(a0);

        public static int MinMeetingRooms1(int[][] a0) => RftMinMeetingRooms1(a0);

        // PriorityQueue
        private static int RftMinMeetingRooms0(int[][] intervals)
        {
            if (intervals.Length == 0) return 0;

            PriorityQueue<int, int> allocator = new(intervals.Length, Comparer<int>.Create((a, b) => a - b));

            Array.Sort(intervals, Comparer<int[]>.Create((a, b) => a[0] - b[0]));

            allocator.Enqueue(intervals[0][1], intervals[0][1]);

            for (int i = 1; i < intervals.Length; i++)
            {
                if (intervals[i][0] >= allocator.Peek()) allocator.Dequeue();

                allocator.Enqueue(intervals[i][1], intervals[i][1]);
            }

            return allocator.Count;
        }

        // Chronological Ordering
        private static int RftMinMeetingRooms1(int[][] input)
        {
            if (input.Length == 0) return 0;
            if (input.Length == 1) return 1;

            int[] startTimes = new int[input.Length];
            int[] endTimes = new int[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                startTimes[i] = input[i][0];
                endTimes[i] = input[i][1];
            }

            Array.Sort(startTimes);
            Array.Sort(endTimes);

            int start = 0, end = 0, max = 0;

            while (start < input.Length)
            {
                if (startTimes[start] < endTimes[end]) start++;
                else end++;

                max = Math.Max(max, start - end + 1);
            }

            return max - 1;
        }
    }
}
