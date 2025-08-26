namespace Rftim3LeetCode.Temp
{
    public class _02496_MaximumValueOfAStringInAnArray
    {
        /// <summary>
        /// The value of an alphanumeric string can be defined as:
        /// The numeric representation of the string in base 10, if it comprises of digits only.
        /// The length of the string, otherwise.
        /// Given an array strs of alphanumeric strings, return the maximum value of any string in strs.
        /// </summary>
        public _02496_MaximumValueOfAStringInAnArray()
        {
            Console.WriteLine(MaximumValue(["alic3", "bob", "3", "4", "00000"]));
            Console.WriteLine(MaximumValue(["1", "01", "001", "0001"]));
        }

        private static int MaximumValue(string[] strs)
        {
            int r = 0;

            foreach (string item in strs)
            {
                if (int.TryParse(item, out int z)) r = Math.Max(r, z);
                else r = Math.Max(r, item.Length);
            }

            return r;
        }
    }
}
