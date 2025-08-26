namespace Rftim3CodinGame.Refactor.Puzzles
{
    public class PrefixCode
    {
        public PrefixCode()
        {
            //const int n = 5;
            //const int n = 18;
            const int n = 14;
            //string[] x = new string[n] {
            //    "1",
            //    "001",
            //    "000",
            //    "011",
            //    "010"
            //};
            //string[] x = new string[n] {
            //    "11",
            //    "1001",
            //    "000011",
            //    "000010",
            //    "0011",
            //    "011",
            //    "000001",
            //    "00101",
            //    "000000",
            //    "00100",
            //    "10111",
            //    "1000",
            //    "00011",
            //    "10110",
            //    "010",
            //    "10101",
            //    "00010",
            //    "10100"
            //};
            string[] x = new string[n] {
                "101",
                "0000",
                "0111",
                "01001",
                "11",
                "0110",
                "0101",
                "00111",
                "00110",
                "00101",
                "100",
                "00100",
                "00011",
                "00010"
            };
            //int[] y = new int[n] {
            //    97,
            //    98,
            //    114,
            //    99,
            //    100
            //};
            //int[] y = new int[n] {
            //    32,
            //    97,
            //    98,
            //    99,
            //    100,
            //    101,
            //    102,
            //    104,
            //    73,
            //    105,
            //    108,
            //    110,
            //    111,
            //    114,
            //    116,
            //    118,
            //    120,
            //    58
            //};
            int[] y = new int[n] {
                32,
                97,
                99,
                100,
                101,
                105,
                108,
                109,
                110,
                112,
                114,
                116,
                118,
                58
            };

            //string s = "10010001011101010010001";
            //string s = "0000001000101011001101110010000111110100110110001001010110100111000011001000101110010101101000101011110111000001111000110000011101000101011110111000000010000110011011001111010011000100101";
            string s = "0100000110000110000010101100100111101000101010101111010010110011001110110111001010111000010000000111001001110011";

            Solve(n, x, y, s);
        }

        private static void Solve(int n, string[] x, int[] y, string s)
        {
            string[] converted = new string[n];
            string test = "";
            string testRemain = "";
            string orig = s;
            int fail = 0;

            for (int i = 0; i < y.Length; i++) converted[i] = Convert.ToChar(y[i]).ToString();

            while (s != "")
            {
                int flag = 0;
                for (int i = 0; i < x.Length; i++)
                {
                    if (s.Length != 0 && x[i].Length <= s.Length)
                    {
                        if (s[..x[i].Length] == x[i])
                        {
                            s = s[x[i].Length..];
                            test += converted[i];
                            Console.WriteLine(s);
                            Console.WriteLine(x[i]);
                            Console.WriteLine(converted[i]);
                            Console.WriteLine(orig.Length - s.Length);
                            Console.WriteLine();
                            flag++;
                        }
                    }
                }
                if (flag == 0)
                {
                    fail = orig.Length - s.Length;
                    testRemain = s;
                    s = "";
                }
            }

            if (fail != 0 && testRemain.Length != 0) Console.WriteLine($"DECODE FAIL AT INDEX {fail}");
            else if (fail == 0 && testRemain.Length != 0) Console.WriteLine($"DECODE FAIL AT INDEX {fail}");
            else Console.WriteLine(test);
        }
    }
}
