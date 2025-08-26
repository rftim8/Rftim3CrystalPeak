namespace Rftim3CodinGame.Refactor.Puzzles
{
    public class SevenSegmentScanner
    {
        public SevenSegmentScanner()
        {
            string line1 = " _     _  _     _  _  _  _  _ ";
            string line2 = "| |  | _| _||_||_ |_   ||_||_|";
            string line3 = "|_|  ||_  _|  | _||_|  ||_| _|";

            Solve(line1, line2, line3);
        }

        private static void Solve(string line1, string line2, string line3)
        {
            string result = "";
            int n = 3;
            int nrs = line1.Length / 3;

            for (int i = 0; i < nrs; i++)
            {
                string nr = line1[..n] + line2[..n] + line3[..n];

                switch (nr)
                {
                    case " _ | ||_|": result += "0"; break;
                    case "     |  |": result += "1"; break;
                    case " _  _||_ ": result += "2"; break;
                    case " _  _| _|": result += "3"; break;
                    case "   |_|  |": result += "4"; break;
                    case " _ |_  _|": result += "5"; break;
                    case " _ |_ |_|": result += "6"; break;
                    case " _   |  |": result += "7"; break;
                    case " _ |_||_|": result += "8"; break;
                    case " _ |_| _|": result += "9"; break;
                    default: break;
                }
                line1 = line1.Remove(0, n);
                line2 = line2.Remove(0, n);
                line3 = line3.Remove(0, n);
            }

            Console.WriteLine(result);
        }
    }
}
