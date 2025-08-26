using System.Text;

namespace Rftim3CodinGame.Refactor.Puzzles
{
    public class Unary
    {
        public Unary()
        {
            string m = "oa";

            Solve(m);
        }

        private static void Solve(string m)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(m);
            string message = "";

            for (int i = 0; i < m.Length; i++)
            {
                string x = m[i].ToString();
                string binStr = string.Join("", x.Select(b => Convert.ToString(b, 2)));

                if (binStr.Length < 7) message += "0" + binStr;
                else message += binStr;
            }

            string result = "";

            int posCounter = 0;
            int negCounter = 0;
            for (int i = 0; i < message.Length; i++)
            {
                string temp = message[i].ToString();
                if (temp == "1")
                {
                    posCounter++;
                    switch (negCounter)
                    {
                        case 1: result += "00 0 "; break;
                        case 2: result += "00 00 "; break;
                        case 3: result += "00 000 "; break;
                        case 4: result += "00 0000 "; break;
                        case 5: result += "00 00000 "; break;
                        case 6: result += "00 000000 "; break;
                        case 7: result += "00 0000000 "; break;
                        default: break;
                    }
                    negCounter = 0;
                }
                else if (temp == "0")
                {
                    negCounter++;
                    switch (posCounter)
                    {
                        case 1: result += "0 0 "; break;
                        case 2: result += "0 00 "; break;
                        case 3: result += "0 000 "; break;
                        case 4: result += "0 0000 "; break;
                        case 5: result += "0 00000 "; break;
                        case 6: result += "0 000000 "; break;
                        case 7: result += "0 0000000 "; break;
                        default: break;
                    }
                    posCounter = 0;
                }
                if (i == message.Length - 1)
                {
                    switch (negCounter)
                    {
                        case 1: result += "00 0"; break;
                        case 2: result += "00 00"; break;
                        case 3: result += "00 000"; break;
                        case 4: result += "00 0000"; break;
                        case 5: result += "00 00000"; break;
                        case 6: result += "00 000000"; break;
                        case 7: result += "00 0000000"; break;
                        default: break;
                    }
                    switch (posCounter)
                    {
                        case 1: result += "0 0"; break;
                        case 2: result += "0 00"; break;
                        case 3: result += "0 000"; break;
                        case 4: result += "0 0000"; break;
                        case 5: result += "0 00000"; break;
                        case 6: result += "0 000000"; break;
                        case 7: result += "0 0000000"; break;
                        default: break;
                    }
                }
            }

            Console.WriteLine(result);
        }
    }
}
