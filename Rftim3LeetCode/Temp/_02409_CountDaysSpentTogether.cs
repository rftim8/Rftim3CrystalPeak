namespace Rftim3LeetCode.Temp
{
    public class _02409_CountDaysSpentTogether
    {
        /// <summary>
        /// Alice and Bob are traveling to Rome for separate business meetings.
        /// You are given 4 strings arriveAlice, leaveAlice, arriveBob, and leaveBob.
        /// Alice will be in the city from the dates arriveAlice to leaveAlice(inclusive), while Bob will be in the city from the dates arriveBob to leaveBob(inclusive). 
        /// Each will be a 5-character string in the format "MM-DD", corresponding to the month and day of the date.
        /// Return the total number of days that Alice and Bob are in Rome together.
        /// You can assume that all dates occur in the same calendar year, which is not a leap year. 
        /// Note that the number of days per month can be represented as: [31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31].
        /// </summary>
        public _02409_CountDaysSpentTogether()
        {
            Console.WriteLine(CountDaysTogether("08-15", "08-18", "08-16", "08-19"));
            Console.WriteLine(CountDaysTogether("10-01", "10-31", "11-01", "12-31"));
        }

        private static int CountDaysTogether(string arriveAlice, string leaveAlice, string arriveBob, string leaveBob)
        {
            int arrive = Math.Max(DateTime.ParseExact(arriveAlice + "-2001", "M-d-yyyy", null).DayOfYear,
                              DateTime.ParseExact(arriveBob + "-2001", "M-d-yyyy", null).DayOfYear);

            int leave = Math.Min(DateTime.ParseExact(leaveAlice + "-2001", "M-d-yyyy", null).DayOfYear,
                                 DateTime.ParseExact(leaveBob + "-2001", "M-d-yyyy", null).DayOfYear);

            return Math.Clamp(leave - arrive + 1, 0, int.MaxValue);
        }
    }
}
