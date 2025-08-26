namespace Rftim3LeetCode.Temp
{
    public class _00008_StringToIntegerAtoi
    {
        /// <summary>
        /// Implement the myAtoi(string s) function, which converts a string to a 32-bit signed integer 
        /// (similar to C/C++'s atoi function).
        /// The algorithm for myAtoi(string s) is as follows:
        /// Read in and ignore any leading whitespace.
        /// Check if the next character(if not already at the end of the string) is '-' or '+'. 
        /// Read this character in if it is either.This determines if the final result is negative or positive
        /// respectively. 
        /// Assume the result is positive if neither is present.
        /// Read in next the characters until the next non-digit character or the end of the input is reached.
        /// The rest of the string is ignored.
        /// Convert these digits into an integer (i.e. "123" -> 123, "0032" -> 32). 
        /// If no digits were read, then the integer is 0. 
        /// Change the sign as necessary (from step 2).
        /// If the integer is out of the 32-bit signed integer range[-231, 231 - 1], then clamp the integer 
        /// so that it remains in the range.
        /// Specifically, integers less than -231 should be clamped to -231, 
        /// and integers greater than 231 - 1 should be clamped to 231 - 1.
        /// Return the integer as the final result.
        /// Note:
        /// Only the space character ' ' is considered a whitespace character.
        /// Do not ignore any characters other than the leading whitespace or the rest 
        /// of the string after the digits.
        /// </summary>
        public _00008_StringToIntegerAtoi()
        {
            Console.WriteLine(StringToIntegerAtoi0("42"));
            Console.WriteLine(StringToIntegerAtoi0("   -42"));
            Console.WriteLine(StringToIntegerAtoi0("4193 with words"));
            Console.WriteLine(StringToIntegerAtoi0("words and 987"));
        }

        public static int StringToIntegerAtoi0(string a0) => RftStringToIntegerAtoi0(a0);

        public static int StringToIntegerAtoi1(string a0) => RftStringToIntegerAtoi1(a0);

        private static int RftStringToIntegerAtoi0(string s)
        {
            if (string.IsNullOrEmpty(s)) return 0;

            int res = 0, sign = 1;
            bool isign = false, idigit = false;

            foreach (char item in s)
            {
                if (!isign && !idigit && (item == '+' || item == '-'))
                {
                    isign = true;
                    sign = item == '+' ? 1 : -1;
                }
                else if (char.IsDigit(item))
                {
                    idigit = true;

                    if (res == 0 && item == '0') continue;
                    else if (res > int.MaxValue / 10 || res == int.MaxValue / 10 && item - '0' > int.MaxValue % 10) return sign == 1 ? int.MaxValue : int.MinValue;
                    else res = res * 10 + (item - '0');
                }
                else if (item != ' ' || (idigit || isign) && item == ' ' || idigit && item == '.') break;
            }

            return res * sign;
        }

        private static int RftStringToIntegerAtoi1(string s)
        {
            int sign = 1;
            int result = 0;
            int index = 0;
            int size = s.Length;

            while (index < size && s[index] == ' ')
            {
                index++;
            }

            if (index < size && s[index] == '+')
            {
                sign = 1;
                index++;
            }
            else if (index < size && s[index] == '-')
            {
                sign = -1;
                index++;
            }

            while (index < size && char.IsDigit(s[index]))
            {
                int digit = s[index] - '0';

                if (result > (int.MaxValue - digit) / 10) return sign == -1 ? int.MinValue : int.MaxValue;

                result = 10 * result + digit;
                index++;
            }

            return sign * result;
        }
    }
}
