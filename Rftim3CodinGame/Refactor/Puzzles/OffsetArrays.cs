namespace Rftim3CodinGame.Refactor.Puzzles
{
    public class OffsetArrays
    {
        public OffsetArrays()
        {
            //int n = 3;
            //int n = 1;
            //int n = 4;
            int n = 26;

            //List<string> list = new()
            //{
            //    "A[-1..1] = 1 2 3",
            //    "B[3..7] = 3 4 5 6 7",
            //    "C[-2..1] = 1 2 3 4"
            //};

            //List<string> list = new()
            //{
            //    "ARR[-5..-3] = 11 22 33"
            //};

            //List<string> list = new()
            //{
            //    "FIRST[1..5] = 1 2 3 4 5",
            //    "SECOND[1..3] = -69 2 6",
            //    "THIRD[1..4] = 1000 20 2 1",
            //    "FOURTH[1..2] = 85 -123"
            //};

            List<string> list = new()
            {
                "A[-19..-13] = 3 -3 -10 8 -3 -2 14",
                "B[7..11] = -1 5 7 4 1",
                "C[-8..1] = -13 4 11 -7 19 10 8 9 -9 20",
                "D[1..4] = 14 6 8 -13",
                "E[1..4] = 9 -14 14 -1",
                "F[14..18] = 12 -15 -18 18 18",
                "G[3..7] = -10 -16 -1 5 -18",
                "H[9..12] = -1 -9 7 -16",
                "I[2..10] = 16 14 18 -11 14 -12 -11 7 18",
                "J[11..15] = 2 1 19 -7 13",
                "K[-11..-5] = -2 -2 20 20 -15 19 4",
                "L[-15..-9] = -5 15 3 -4 19 8 -6",
                "M[4..10] = 17 20 4 3 -16 1 5",
                "N[-10..-1] = 6 -4 -19 10 17 -5 -10 -13 18 -10",
                "O[-13..-11] = 10 13 -19",
                "P[3..11] = 8 -12 -17 18 -3 4 6 -8 4",
                "Q[12..18] = 2 -20 14 -16 -15 10 14",
                "R[2..8] = 19 -10 -15 -11 -6 -15 3",
                "S[-18..-15] = 3 13 -9 1",
                "T[-2..4] = -3 12 -5 17 -6 -1 18",
                "U[5..9] = -7 2 -14 6 19",
                "V[-4..1] = -10 12 16 17 16 -2",
                "W[-20..-11] = -15 -14 9 12 0 17 -10 -6 -7 19",
                "X[2..10] = 20 8 15 -10 16 -6 1 17 -1",
                "Y[-10..-8] = -17 -15 13",
                "Z[-4..0] = -13 11 9 - 19 -14"
            };

            //string x = "A[0]";
            //string x = "ARR[-4]";
            //string x = "SECOND[THIRD[4]]";
            string x = "V[S[W[Q[S[P[M[C[A[R[B[Z[V[S[Q[V[V[J[W[-17]]]]]]]]]]]]]]]]]]]";

            Solve(n, list, x);
        }

        private static void Solve(int n, List<string> list, string x)
        {
            string target = x;
            int RecursionsNumber = target.Split('[').Length - 1;

            for (int i = 0; i < RecursionsNumber; i++)
            {
                string arrayName = target.Split('[')[^2];
                string temp1 = target.Split('[')[^1];
                int arrayIndex = int.Parse(temp1[..temp1.IndexOf(']')]);

                for (int j = 0; j < n; j++)
                {
                    string temp = list[j];
                    string name = temp[..temp.IndexOf('[')];

                    if (name == arrayName)
                    {
                        int lowerLimit = int.Parse(temp[(temp.IndexOf("[") + 1)..(temp.IndexOf("]") - 1)].Split('.')[0]);

                        int RecursiveResult = Math.Abs(lowerLimit - arrayIndex);
                        string arrayNumbers = temp.Split('=')[1].Trim();
                        int found = int.Parse(arrayNumbers.Split(' ')[Math.Abs(RecursiveResult)]);

                        target = $"{target[..target.LastIndexOf('[')][..^arrayName.Length]}{found}{target[(target.IndexOf(']') + 1)..]}";
                    }
                }
            }

            Console.WriteLine($"{target}");
        }
    }
}
