namespace Rftim3LeetCode.Temp
{
    public class _00013_RomanToInteger
    {
        /// <summary>
        /// Roman numerals are represented by seven different symbols: I, V, X, L, C, D and M.
        ///        Symbol Value
        /// I             1
        /// V             5
        /// X             10
        /// L             50
        /// C             100
        /// D             500
        /// M             1000
        /// For example, 2 is written as II in Roman numeral, just two ones added together. 12 is written as XII, which is simply X + II.
        /// The number 27 is written as XXVII, which is XX + V + II.
        /// Roman numerals are usually written largest to smallest from left to right. However, the numeral for four is not IIII. 
        /// Instead, the number four is written as IV.Because the one is before the five we subtract it making four. 
        /// The same principle applies to the number nine, which is written as IX.There are six instances where subtraction is used:
        /// I can be placed before V (5) and X(10) to make 4 and 9. 
        /// X can be placed before L(50) and C(100) to make 40 and 90. 
        /// C can be placed before D(500) and M(1000) to make 400 and 900.
        /// Given a roman numeral, convert it to an integer.
        /// </summary>
        public _00013_RomanToInteger()
        {

        }

        public static int RomanToInteger0(string a0) => RftRomanToInteger0(a0);

        private static int RftRomanToInteger0(string s)
        {
            int x = 0;
            int y = s.Length;
            for (int i = 0; i < y; i++)
            {
                switch (s[i].ToString())
                {
                    case "I":
                        if (i < y - 1)
                        {
                            if (s[i + 1] == 'V')
                            {
                                x += 4;
                                i++;
                            }
                            else if (s[i + 1] == 'X')
                            {
                                x += 9;
                                i++;
                            }
                            else x++;
                        }
                        else x++;
                        break;
                    case "V":
                        x += 5;
                        break;
                    case "X":
                        if (i < y - 1)
                        {
                            if (s[i + 1] == 'L')
                            {
                                x += 40;
                                i++;
                            }
                            else if (s[i + 1] == 'C')
                            {
                                x += 90;
                                i++;
                            }
                            else x += 10;
                        }
                        else x += 10;
                        break;
                    case "L":
                        x += 50;
                        break;
                    case "C":
                        if (i < y - 1)
                        {
                            if (s[i + 1] == 'D')
                            {
                                x += 400;
                                i++;
                            }
                            else if (s[i + 1] == 'M')
                            {
                                x += 900;
                                i++;
                            }
                            else x += 100;
                        }
                        else x += 100;
                        break;
                    case "D":
                        x += 500;
                        break;
                    case "M":
                        x += 1000;
                        break;
                    default:
                        break;
                }
            }
            return x;
        }
    }
}
