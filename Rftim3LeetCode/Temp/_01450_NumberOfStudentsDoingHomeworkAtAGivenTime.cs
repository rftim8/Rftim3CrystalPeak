namespace Rftim3LeetCode.Temp
{
    public class _01450_NumberOfStudentsDoingHomeworkAtAGivenTime
    {
        /// <summary>
        /// Given two integer arrays startTime and endTime and given an integer queryTime.
        /// The ith student started doing their homework at the time startTime[i] and finished it at time endTime[i].
        /// Return the number of students doing their homework at time queryTime.
        /// More formally, return the number of students where queryTime lays in the interval[startTime[i], endTime[i]] inclusive.
        /// </summary>
        public _01450_NumberOfStudentsDoingHomeworkAtAGivenTime()
        {
            Console.WriteLine(BusyStudent([1, 2, 3], [3, 2, 7], 4));
            Console.WriteLine(BusyStudent([4], [4], 4));
        }

        private static int BusyStudent(int[] startTime, int[] endTime, int queryTime)
        {
            int n = startTime.Length;

            int c = 0;
            for (int i = 0; i < n; i++)
            {
                if (startTime[i] <= queryTime && endTime[i] >= queryTime) c++;
            }

            return c;
        }
    }
}
