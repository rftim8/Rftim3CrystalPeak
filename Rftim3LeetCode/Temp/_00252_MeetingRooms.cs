namespace Rftim3LeetCode.Temp
{
    public class _00252_MeetingRooms
    {
        /// <summary>
        /// Given an array of meeting time intervals where intervals[i] = [starti, endi], determine if a person could attend all meetings.
        /// </summary>
        public _00252_MeetingRooms()
        {
            Console.WriteLine(CanAttendMeetings0([[0, 30], [5, 10], [15, 20]]));
            Console.WriteLine(CanAttendMeetings0([[7, 10], [2, 4]]));
            Console.WriteLine(CanAttendMeetings0([[13, 15], [1, 13]]));
        }

        public static bool CanAttendMeetings0(int[][] a0) => RftCanAttendMeetings0(a0);

        public static bool CanAttendMeetings1(int[][] a0) => RftCanAttendMeetings1(a0);

        private static bool RftCanAttendMeetings0(int[][] intervals)
        {
            int n = intervals.Length;

            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if ((intervals[i][0] < intervals[j][1] || intervals[i][1] < intervals[j][1]) &&
                        (intervals[i][0] > intervals[j][0] || intervals[i][1] > intervals[j][0]))
                        return false;
                }
            }

            return true;
        }

        private static bool RftCanAttendMeetings1(int[][] intervals)
        {
            Array.Sort(intervals, (a, b) => a[0] < b[0] ? -1 : 1);

            for (int i = 1; i < intervals.Length; i++)
            {
                if (intervals[i][0] < intervals[i - 1][1]) return false;
            }

            return true;
        }
    }
}
