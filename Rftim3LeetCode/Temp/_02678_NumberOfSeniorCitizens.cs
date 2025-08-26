namespace Rftim3LeetCode.Temp
{
    public class _02678_NumberOfSeniorCitizens
    {
        /// <summary>
        /// You are given a 0-indexed array of strings details.
        /// Each element of details provides information about a given passenger compressed into a string of length 15. 
        /// The system is such that:
        /// The first ten characters consist of the phone number of passengers.
        /// The next character denotes the gender of the person.
        /// The following two characters are used to indicate the age of the person.
        /// The last two characters determine the seat allotted to that person.
        /// Return the number of passengers who are strictly more than 60 years old.
        /// </summary>
        public _02678_NumberOfSeniorCitizens()
        {
            Console.WriteLine(CountSeniors(["7868190130M7522", "5303914400F9211", "9273338290F4010"]));
            Console.WriteLine(CountSeniors(["1313579440F2036", "2921522980M5644"]));
        }

        private static int CountSeniors(string[] details)
        {
            int r = 0;

            foreach (string item in details)
            {
                if (int.Parse(item[11..13].ToString()) > 60) r++;
            }

            return r;
        }
    }
}
