using System.Text;

namespace Rftim3CodinGame.Refactor.Puzzles
{
    public class CaesarIsTheChief
    {
        public CaesarIsTheChief()
        {
            //string textToDecode = "HELLO";
            //string textToDecode = "CHIEF";
            string textToDecode = "DIJFG JT XSPOH";
            string alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            Solve(textToDecode, alpha);
        }

        private static void Solve(string message, string alpha)
        {
            List<string> messages = message.Split(' ').ToList();
            bool validMessage = false;
            int discrepancy = 0;

            foreach (string item in messages)
            {
                if (item.Length == 5)
                {
                    discrepancy = alpha.IndexOf(item[..1]) > alpha.IndexOf("C") ? alpha.IndexOf(item[..1]) - alpha.IndexOf("C") : alpha.IndexOf("C") - alpha.IndexOf(item[..1]);
                    string temp = item;

                    Console.WriteLine($"discrepancy: {discrepancy}");

                    for (int i = 0; i < item.Length; i++)
                    {
                        string charOrig = temp[i].ToString();
                        int indexCharOrig = alpha.IndexOf(charOrig);
                        int indexCharTarget = indexCharOrig - discrepancy;
                        if (indexCharTarget < 0) indexCharTarget = alpha.Length - (-indexCharTarget);

                        Console.WriteLine($"{charOrig}: {indexCharOrig} -> {indexCharTarget}");

                        temp = $"{temp[..i]}{alpha.Substring(indexCharTarget, 1)}{temp[(i + 1)..]}";
                    }

                    if (temp == "CHIEF")
                    {
                        validMessage = true;
                        break;
                    }
                    Console.WriteLine(temp);
                }
            }

            if (!validMessage) Console.WriteLine("WRONG MESSAGE");
            else
            {
                StringBuilder sb = new();
                foreach (string item in messages)
                {
                    string temp = item;

                    Console.WriteLine($"discrepancy: {discrepancy}");

                    for (int i = 0; i < item.Length; i++)
                    {
                        string charOrig = temp[i].ToString();
                        int indexCharOrig = alpha.IndexOf(charOrig);
                        int indexCharTarget = indexCharOrig - discrepancy;
                        if (indexCharTarget < 0) indexCharTarget = alpha.Length - (-indexCharTarget);

                        Console.WriteLine($"{charOrig}: {indexCharOrig} -> {indexCharTarget}");

                        temp = $"{temp[..i]}{alpha.Substring(indexCharTarget, 1)}{temp[(i + 1)..]}";
                    }

                    sb.Append($"{temp} ");
                }
                Console.WriteLine($"{sb.ToString().TrimEnd()}");
            }
        }
    }
}
