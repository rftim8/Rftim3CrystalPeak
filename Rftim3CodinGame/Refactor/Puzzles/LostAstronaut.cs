using System.Text;

namespace Rftim3CodinGame.Refactor.Puzzles
{
    public class LostAstronaut
    {
        public LostAstronaut()
        {
            //string message = "1110100 1100101 1110011 1110100";
            //string message = "164 145 163 164 40 157 143 164 141 154 144 145 143 151 155 141 154";
            //string message = "74 65 73 74 20 68 65 78 61 64 65 63 69 6d 61 6c";
            //string message = "74 65 s 1110100 151 6e 147 40 6f 6e e 100000 164 77 157 40 74 1101000 72 1100101 145";
            //string message = "H 1100101 1101100 154 1101111 20 143 a 156 40 61 1101110 79 157 6e 145 20 150 1100101 a 1110010 40 m 65";
            //string message = "y 145 73   100000   20 147 72 65 a t";
            string message = "49   141 155 20 a 164 40 1001111 4f 5a 4f 132 132 5a 40 1001111 4f 117 1011010 O 132 Z 40 117 1001111 1001111 132 117 132 Z 40 O O 4f 132 1011010 5a Z 20 O O 1001111 132 Z 1001111 4f   4f O 117 Z O 5a 100000 4f Z O 4f 4f O   4f Z 117 4f 4f 4f 100000 117 117 4f Z O 4f 117 100000 117 4f O 1011010 1001111 4f 1001111 20 4f 1001111 O Z 4f 117 O   4f Z 4f O 4f 1011010 40 1001111 117 117 117 1011010 132 4f 20 1001111 4f 1011010 1001111 1001111 1001111 1001111   O O 117 132 4f 132 O 20 1001111 4f 1001111 1011010 1001111 Z 132 100000 4f 1001111 O Z O Z 117   O 1001111 5a 1011010 1011010 O 1011010   4f 1001111 Z Z 117 132 4f 40 117 1011010 117 1001111 1001111 5a 100000 O 117 1011010 5a 132 1001111 O   O 117 5a 1001111 1001111 O 1001111   O 117 5a O 4f 132 O   4f Z 117 1001111 1001111 117   117 O 4f 132 1001111 1001111 4f 40 117 1001111 5a 132 Z 132 O 40 O 4f 4f Z 117 Z 132   1001111 4f Z 132 Z O 4f 100000 1001111 4f 132 O 132 1011010 132   117 4f 4f O 117 1001111 20 4f 117 1001111 132 O 1001111 1011010 40 1001111 4f 1001111 4f 132 117 20 117 O 132 117 1011010 1011010 1001111 20 O 117 132 O 1011010 132 O 40 4f O 5a O Z 4f 117 20 117 117 1011010 Z 117 132   117 4f 132 1001111 132 117 20 O 117 O Z 4f 4f 4f 40 117 O 4f 5a 5a 132 117 20 4f 132 Z 117 132 Z 4f   117 117 1001111 Z O 5a O 40 1001111 Z 1011010 Z 1001111 O 1011010 20 4f 4f 132 4f O 1001111 1001111";

            Solve(message);
        }

        private static void Solve(string message)
        {
            message = message.Replace("   ", " @ ");
            string alpha = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string result = "";
            int n = message.Split(' ').Length;

            for (int i = 0; i < n; i++)
            {
                string temp = message.Split(' ')[i];
                if (temp.Length == 1 && alpha.Contains(temp)) result += temp;
                else if (temp.Contains('1') && temp.Contains('0') && temp.Length > 3)
                {
                    for (int j = 0; j < 8 - temp.Length - 1; j++)
                    {
                        temp = "0" + temp;
                    }

                    temp = "0" + temp;
                    List<byte> list = new();

                    for (int j = 0; j < temp.Length; j += 8)
                    {
                        string t = temp.Substring(j, 8);
                        list.Add(Convert.ToByte(t, 2));
                    }
                    result += Encoding.ASCII.GetString(list.ToArray());
                }
                else if (temp.Length == 2)
                {
                    string ascii = string.Empty;

                    for (int j = 0; j < temp.Length; j += 2)
                    {
                        string hs = temp.Substring(j, 2);
                        uint decval = Convert.ToUInt32(hs, 16);
                        char character = Convert.ToChar(decval);
                        ascii += character;
                    }
                    result += ascii;
                }
                else if (temp.Length == 3)
                {
                    if (int.TryParse(temp, out int x))
                    {
                        int Decimal_Number = 0;
                        int BASE = 1;
                        int temp1 = x;
                        while (temp1 > 0)
                        {
                            int last_digit = temp1 % 10;
                            temp1 /= 10;
                            Decimal_Number += last_digit * BASE;
                            BASE *= 8;
                        }

                        result += Convert.ToChar(Decimal_Number);
                    }
                }
                else
                {
                    result += temp;
                }
            }

            Console.WriteLine(result.Replace('@', ' '));
        }
    }
}
