namespace Rftim3CodinGame.Refactor.Puzzles
{
    public class RocketEngines
    {
        public RocketEngines()
        {
            //  @Goal
            //  It is a public secret that you need a rocket to go to Mars, but only a few know that your rocket engines must be balanced.
            //Because Mars is fourth planet from the Sun, your rocket has four engines positioned in matrix 2x2.Before launch, each engine has it own default power, but you as engineer and captain of rocket can change power of engines.In one turn, you can increase by 1 every engine in arbitrary row or column, and you can perform multiple actions (there is no limit). Imbalance of rocket is defined as difference between maximal engine power and minimal engine power.
            //Your goal is to find what is the minimal possible imbalance of rocket you can obtain using described action.
            //Example:
            //Given default power of each engine
            //1 1
            //0 3

            //Next actions are performed: 1 x first row, 2 x first column
            //1 1 -> 2 2 -> 3 2 -> 4 2
            //0 3    0 3    1 3    2 3

            //So minimal imbalance of rocket is 4 - 2 = 2.
            //Input
            //2 lines : Matrix 2x2 which represent default power of each rocket engine.
            //Output
            //Line 1 :Number which represent minimal imbalance of rocket.
            //Constraints
            //a[i][j] - Element of matrix
            //0 ≤ a[i][j] ≤ 1000000000

            //Example

            //Input
            //1 1
            //0 3

            //Output
            //2

            //// Test 1 -> 2
            //List<long> rockets1 = new()
            //{
            //    1,
            //    1,
            //    0,
            //    3
            //};

            //// Validator 1 -> 3
            //List<long> rocketsV1 = new()
            //{
            //    9,
            //    8,
            //    7,
            //    0
            //};

            //// Test 2 -> 0
            //List<long> rockets2 = new()
            //{
            //    6,
            //    6,
            //    6,
            //    6
            //};

            //// Validator 2 -> 0
            //List<long> rocketsV2 = new()
            //{
            //    0,
            //    0,
            //    0,
            //    0
            //};

            //// Test 3 -> 9
            //List<long> rockets3 = new()
            //{
            //    3,
            //    12,
            //    12,
            //    3
            //};

            //// Validator 3 -> 1
            //List<long> rocketsV3 = new()
            //{
            //   7,
            //   19,
            //   7,
            //   18
            //};

            //// Test 4 -> 21
            //List<long> rockets4 = new()
            //{
            //    83,
            //    104,
            //    84,
            //    64
            //};

            //// Validator 4 -> 29
            //List<long> rocketsV4 = new()
            //{
            //    81,
            //    6,
            //    106,
            //    89
            //};

            //// Test 5 ->81
            //List<long> rockets5 = new()
            //{
            //    1120,
            //    1193,
            //    1185,
            //    1096
            //};

            //// Validator 5 ->69
            //List<long> rocketsV5 = new()
            //{
            //    640,
            //    520,
            //    640,
            //    382
            //};

            //// Test 6 ->1292687
            //List<long> rockets6 = new()
            //{
            //    2593648,
            //    2164630,
            //    3695065,
            //    5851421
            //};

            ////Validator 6 ->5810473
            //List<long> rocketsV6 = new()
            //{
            //    1973577,
            //    6675192,
            //    9961385,
            //    3042054
            //};

            ////Test 7 ->636195
            //List<long> rockets7 = new()
            //{
            //    466643937,
            //    459483554,
            //    462812334,
            //    456924340
            //};

            ////Validator 7 ->14098690
            //List<long> rocketsV7 = new()
            //{
            //    236663937,
            //    161103138,
            //    151141275,
            //    103777855
            //};

            ////Test 8 ->105614554
            //List<long> rockets8 = new()
            //{
            //    257096859,
            //    257096859,
            //    45867751,
            //    257096859
            //};

            ////Validator 8 ->168072185
            //List<long> rocketsV8 = new()
            //{
            //    329249334,
            //    363706684,
            //    341679234,
            //    39992214
            //};

            ////Test 9 -> 105484701
            //List<long> rockets9 = new()
            //{
            //    32095790,
            //    173465731,
            //    71866326,
            //    424205669
            //};

            ////Validator 9 -> 117665333
            //List<long> rocketsV9 = new()
            //{
            //    225352867,
            //    225352867,
            //    460683533,
            //    225352867
            //};

            ////Test 10 -> 0
            //List<long> rockets10 = new()
            //{
            //    208949331,
            //    489817533,
            //    208949331,
            //    489817533
            //};

            //Validator 10 -> 44008765
            List<long> rocketsV10 = new()
            {
                467765325,
                497519746,
                60981056,
                2717947
            };

            Solve(rocketsV10);
        }

        private static void Solve(List<long> rockets)
        {
            Console.WriteLine($"{(Math.Abs(rockets[0] + rockets[3] - rockets[1] - rockets[2]) + 1) / 2}");
        }
    }
}
