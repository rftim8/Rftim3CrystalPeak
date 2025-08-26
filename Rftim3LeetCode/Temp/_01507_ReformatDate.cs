using System.Text;

namespace Rftim3LeetCode.Temp
{
    public class _01507_ReformatDate
    {
        /// <summary>
        /// Given a date string in the form Day Month Year, where:
        /// Day is in the set {"1st", "2nd", "3rd", "4th", ..., "30th", "31st"}.
        /// Month is in the set {"Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"}.
        /// Year is in the range[1900, 2100].
        /// Convert the date string to the format YYYY-MM-DD, where:
        /// YYYY denotes the 4 digit year.
        /// MM denotes the 2 digit month.
        /// DD denotes the 2 digit day.
        /// </summary>
        public _01507_ReformatDate()
        {
            Console.WriteLine(ReformatDate("20th Oct 2052"));
            Console.WriteLine(ReformatDate("6th Jun 1933"));
            Console.WriteLine(ReformatDate("26th May 1960"));
        }

        private static string ReformatDate(string date)
        {
            string[] r = [.. date.Split(' ')];
            Dictionary<string, string> x = new()
            {
                ["Jan"] = "01",
                ["Feb"] = "02",
                ["Mar"] = "03",
                ["Apr"] = "04",
                ["May"] = "05",
                ["Jun"] = "06",
                ["Jul"] = "07",
                ["Aug"] = "08",
                ["Sep"] = "09",
                ["Oct"] = "10",
                ["Nov"] = "11",
                ["Dec"] = "12"
            };
            StringBuilder sb = new();

            sb.Append($"{r[2]}-");
            sb.Append($"{x[r[1]]}-");

            if (!char.IsDigit(r[0][1])) sb.Append($"0{r[0][0]}");
            else sb.Append(r[0][..2]);

            return sb.ToString();
        }
    }
}
