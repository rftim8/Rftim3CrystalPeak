﻿namespace Rftim3Console.System.Chars
{
    public class RftCharConvertFromUTF32
    {
        public RftCharConvertFromUTF32()
        {
            int letterA = 0x0041;  //U+00041 = LATIN CAPITAL LETTER A
            int music = 0x1D161; //U+1D161 = MUSICAL SYMBOL SIXTEENTH NOTE
            string s1;
            string comment = "Create a UTF-16 encoded string from a code point.";
            string comment1b = "Create a code point from a UTF-16 encoded string.";
            string comment2b = "Create a code point from a surrogate pair at a certain position in a string.";
            string comment2c = "Create a code point from a high surrogate and a low surrogate code point.";

            //  Convert code point U+0041 to UTF-16. The UTF-16 equivalent of
            //  U+0041 is a Char with hexadecimal value 0041.

            Console.WriteLine(comment);
            s1 = char.ConvertFromUtf32(letterA);
            Console.Write($"    1a) 0x{letterA:X} => ");
            Show(s1);
            Console.WriteLine();

            //  Convert the lone UTF-16 character to a code point.

            Console.WriteLine(comment1b);
            letterA = char.ConvertToUtf32(s1, 0);
            Console.Write("    1b) ");
            Show(s1);
            Console.WriteLine($" => 0x{letterA:X}");
            Console.WriteLine();

            // -------------------------------------------------------------------

            //  Convert the code point U+1D161 to UTF-16. The UTF-16 equivalent of
            //  U+1D161 is a surrogate pair with hexadecimal values D834 and DD61.

            Console.WriteLine(comment);
            s1 = char.ConvertFromUtf32(music);
            Console.Write($"    2a) 0x{music:X} => ");
            Show(s1);
            Console.WriteLine();

            //  Convert the surrogate pair in the string at index position
            //  zero to a code point.

            Console.WriteLine(comment2b);
            music = char.ConvertToUtf32(s1, 0);
            Console.Write("    2b) ");
            Show(s1);
            Console.WriteLine($" => 0x{music:X}");

            //  Convert the high and low characters in the surrogate pair into a code point.

            Console.WriteLine(comment2c);
            music = char.ConvertToUtf32(s1[0], s1[1]);
            Console.Write("    2c) ");
            Show(s1);
            Console.WriteLine($" => 0x{music:X}");
        }

        private static void Show(string s)
        {
            for (int x = 0; x < s.Length; x++)
            {
                Console.Write($"0x{(int)s[x]:X}{(x == s.Length - 1 ? string.Empty : ", ")}");
            }
        }
    }
}
