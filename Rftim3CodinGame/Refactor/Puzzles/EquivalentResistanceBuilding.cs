namespace Rftim3CodinGame.Refactor.Puzzles
{
    public class EquivalentResistanceBuilding
    {
        public EquivalentResistanceBuilding()
        {
            //int N = 2;
            //int N = 7;
            //int N = 3;
            int n = 1;

            //string[] name1 = new string[] { "C", "D" };
            //string[] name1 = new string[] { "Alfa", "Bravo", "Charlie", "Delta", "Echo", "Foxtrot", "Golf" };
            //string[] name1 = new string[] { "Alef", "Bet", "Vet" };
            string[] name1 = new string[] { "Star" };

            //int[] R1 = new int[] { 20, 25 };
            //int[] R1 = new int[] { 1, 1, 12, 4, 2, 10, 8 };
            //int[] R1 = new int[] { 30, 20, 10 };
            int[] r1 = new int[] { 78 };
            //string circuit = "[ C D ]";
            //string circuit = "( Alfa [ Charlie Delta ( Bravo [ Echo ( Foxtrot Golf ) ] ) ] )";
            //string circuit = "( Alef [ ( Bet Bet Bet ) ( Vet [ ( Vet Vet ) ( Vet [ Bet Bet ] ) ] ) ] )";
            string circuit = "[ ( [ Star ( Star Star ) ] [ Star ( Star Star ) ] Star ) ( [ Star ( Star Star ) ] [ Star ( Star Star ) ] Star ) ]";

            Solve(n, name1, r1, circuit);
        }

        public static void Solve(int n, string[] name1, int[] r1, string circuit)
        {
            string circuit1 = "";

            for (int i = 0; i < n; i++)
            {
                circuit1 = circuit.Replace(name1[i], r1[i].ToString());
                circuit = circuit1;
            }

            while (circuit1.Contains('(') || circuit1.Contains('['))
            {
                List<int> x1 = new();
                List<int> x2 = new();
                List<int> y1 = new();
                List<int> y2 = new();

                for (int i = 0; i < circuit1.Length; i++)
                {
                    string temp = circuit1[i].ToString();
                    switch (temp)
                    {
                        case "(":
                            x1.Add(i);
                            break;
                        case ")":
                            x2.Add(i);
                            break;
                        case "[":
                            y1.Add(i);
                            break;
                        case "]":
                            y2.Add(i);
                            break;
                        default:
                            break;
                    }
                }

                string final;
                for (int i = 0; i < x1.Count; i++)
                {
                    for (int j = 0; j < x2.Count; j++)
                    {
                        int q = x2[j] - x1[i];
                        if (q > 0)
                        {
                            int spanX = x2[j] - x1[i];
                            if (spanX + x1[i] < circuit1.Length)
                            {
                                string opX1 = circuit1.Substring(x1[i] + 1, spanX);
                                string opX = circuit1.Substring(x1[i], spanX + 1);
                                if (!opX1.Contains('[') && !opX1.Contains(']') && !opX1.Contains('(') && opX1.Contains(')'))
                                {
                                    float result = 0.0f;
                                    for (int k = 1; k < opX.Split(' ').Length - 1; k++)
                                    {
                                        result += float.Parse(opX.Split(' ')[k]);
                                    }

                                    final = circuit1.Replace(opX, Math.Round(result, 1).ToString());
                                    circuit1 = final;
                                    Console.WriteLine(circuit1);
                                }
                            }
                        }
                    }
                }

                for (int i = 0; i < y1.Count; i++)
                {
                    for (int j = 0; j < y2.Count; j++)
                    {
                        int q = y2[j] - y1[i];
                        if (q > 0)
                        {
                            int spanY = y2[j] - y1[i];
                            if (spanY + y1[i] < circuit1.Length)
                            {
                                string opY1 = circuit1.Substring(y1[i] + 1, spanY);
                                string opY = circuit1.Substring(y1[i], spanY + 1);
                                if (!opY1.Contains('(') && !opY1.Contains(')') && !opY1.Contains('[') && opY1.Contains(']'))
                                {
                                    float result = 0.0f;
                                    for (int k = 1; k < opY.Split(' ').Length - 1; k++)
                                    {
                                        result += 1 / float.Parse(opY.Split(' ')[k]);
                                    }

                                    final = circuit1.Replace(opY, Math.Round(1 / result, 1).ToString());
                                    circuit1 = final;
                                    Console.WriteLine(circuit1);
                                }
                            }
                        }
                    }
                }
            }

            Console.WriteLine(string.Format("{0:F1}", decimal.Parse(circuit1)));
        }
    }
}
