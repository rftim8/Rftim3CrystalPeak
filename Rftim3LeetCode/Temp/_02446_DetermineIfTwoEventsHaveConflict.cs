namespace Rftim3LeetCode.Temp
{
    public class _02446_DetermineIfTwoEventsHaveConflict
    {
        /// <summary>
        /// You are given two arrays of strings that represent two inclusive events that happened on the same day, event1 and event2, where:
        /// event1 = [startTime1, endTime1]
        /// and
        /// event2 = [startTime2, endTime2].
        /// Event times are valid 24 hours format in the form of HH:MM.
        /// A conflict happens when two events have some non-empty intersection(i.e., some moment is common to both events).
        /// Return true if there is a conflict between two events.Otherwise, return false.
        /// </summary>
        public _02446_DetermineIfTwoEventsHaveConflict()
        {
            Console.WriteLine(HaveConflict(["01:15", "02:00"], ["02:00", "03:00"]));
            Console.WriteLine(HaveConflict(["01:00", "02:00"], ["01:20", "03:00"]));
            Console.WriteLine(HaveConflict(["10:00", "11:00"], ["14:00", "15:00"]));
            Console.WriteLine(HaveConflict(["14:13", "22:08"], ["02:40", "08:08"]));
        }

        private static bool HaveConflict(string[] event1, string[] event2)
        {
            double t11 = TimeSpan.Parse(event1[0]).TotalMinutes;
            double t12 = TimeSpan.Parse(event1[1]).TotalMinutes;
            double t21 = TimeSpan.Parse(event2[0]).TotalMinutes;
            double t22 = TimeSpan.Parse(event2[1]).TotalMinutes;

            return t11 <= t21 && t21 <= t12 ||
                    t21 <= t11 && t11 <= t22;
        }
    }
}
