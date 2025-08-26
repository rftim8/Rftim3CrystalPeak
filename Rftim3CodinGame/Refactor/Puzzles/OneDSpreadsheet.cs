namespace Rftim3CodinGame.Refactor.Puzzles
{
    public class OneDSpreadsheet
    {
        public OneDSpreadsheet()
        {
            int n = 9;
            string[] ops = new string[] { "VALUE", "VALUE", "ADD", "ADD", "ADD", "ADD", "ADD", "ADD", "ADD" };
            string[] args1 = new string[] { "0", "1", "$0", "$1", "$2", "$3", "$4", "$5", "$6" };
            string[] args2 = new string[] { "_", "_", "$1", "$2", "$3", "$4", "$5", "$6", "$7" };
            string[] results = new string[9];
            bool processing = true;

            Solve(n, ops, args1, args2, results, processing);
        }

        private static void Solve(int n, string[] ops, string[] args1, string[] args2, string[] results, bool processing)
        {
            for (int i = 0; i < n; i++) results[i] = "";

            while (processing)
            {
                for (int i = 0; i < n; i++)
                {
                    string temp1;
                    string temp2;
                    switch (ops[i])
                    {
                        case "VALUE":
                            if (!args1[i].Contains('$')) results[i] = args1[i];
                            else if (args1[i].Contains('$'))
                            {
                                temp1 = results[int.Parse(args1[i].Split('$')[1])];
                                if (temp1 != "") results[i] = results[int.Parse(args1[i].Split('$')[1])];
                            }
                            break;
                        case "ADD":
                            if (!args1[i].Contains('$') && args2[i].Contains('$'))
                            {
                                temp1 = results[int.Parse(args2[i].Split('$')[1])];
                                if (temp1 != "") results[i] = (int.Parse(args1[i]) + int.Parse(temp1)).ToString();
                            }
                            else if (args1[i].Contains('$') && !args2[i].Contains('$'))
                            {
                                temp1 = results[int.Parse(args1[i].Split('$')[1])];
                                if (temp1 != "") results[i] = (int.Parse(temp1) + int.Parse(args2[i])).ToString();
                            }
                            else if (!args1[i].Contains('$') && !args2[i].Contains('$')) results[i] = (int.Parse(args1[i]) + int.Parse(args2[i])).ToString();
                            else if (args1[i].Contains('$') && args2[i].Contains('$'))
                            {
                                temp1 = results[int.Parse(args1[i].Split('$')[1])];
                                temp2 = results[int.Parse(args2[i].Split('$')[1])];
                                if (temp1 != "" && temp2 != "") results[i] = (int.Parse(temp1) + int.Parse(temp2)).ToString();
                            }
                            break;
                        case "SUB":
                            if (!args1[i].Contains('$') && args2[i].Contains('$'))
                            {
                                temp2 = results[int.Parse(args2[i].Split('$')[1])];
                                if (temp2 != "") results[i] = (int.Parse(args1[i]) - int.Parse(temp2)).ToString();
                            }
                            else if (args1[i].Contains('$') && !args2[i].Contains('$'))
                            {
                                temp1 = results[int.Parse(args1[i].Split('$')[1])];
                                if (temp1 != "") results[i] = (int.Parse(temp1) - int.Parse(args2[i])).ToString();
                            }
                            else if (!args1[i].Contains('$') && !args2[i].Contains('$')) results[i] = (int.Parse(args1[i]) - int.Parse(args2[i])).ToString();
                            else if (args1[i].Contains('$') && args2[i].Contains('$'))
                            {
                                temp1 = results[int.Parse(args1[i].Split('$')[1])];
                                temp2 = results[int.Parse(args2[i].Split('$')[1])];
                                if (temp1 != "" && temp2 != "") results[i] = (int.Parse(temp1) - int.Parse(temp2)).ToString();
                            }
                            break;
                        case "MULT":
                            if (!args1[i].Contains('$') && args2[i].Contains('$'))
                            {
                                temp2 = results[int.Parse(args2[i].Split('$')[1])];
                                if (temp2 != "") results[i] = (int.Parse(args1[i]) * int.Parse(temp2)).ToString();
                            }
                            else if (args1[i].Contains('$') && !args2[i].Contains('$'))
                            {
                                temp1 = results[int.Parse(args1[i].Split('$')[1])];
                                if (temp1 != "") results[i] = (int.Parse(temp1) * int.Parse(args2[i])).ToString();
                            }
                            else if (!args1[i].Contains('$') && !args2[i].Contains('$')) results[i] = (int.Parse(args1[i]) * int.Parse(args2[i])).ToString();
                            else if (args1[i].Contains('$') && args2[i].Contains('$'))
                            {
                                temp1 = results[int.Parse(args1[i].Split('$')[1])];
                                temp2 = results[int.Parse(args2[i].Split('$')[1])];
                                if (temp1 != "" && temp2 != "") results[i] = (int.Parse(temp1) * int.Parse(temp2)).ToString();
                            }
                            break;
                        default:
                            break;
                    }
                }

                int flag = 0;
                for (int i = 0; i < n; i++)
                {
                    if (results[i] == "") flag++;
                }

                if (flag == 0) processing = false;
            }

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(results[i]);
            }
        }
    }
}
