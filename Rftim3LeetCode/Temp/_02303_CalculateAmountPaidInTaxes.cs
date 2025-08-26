namespace Rftim3LeetCode.Temp
{
    public class _02303_CalculateAmountPaidInTaxes
    {
        /// <summary>
        /// You are given a 0-indexed 2D integer array brackets where brackets[i] = [upperi, percenti] means that 
        /// the ith tax bracket has an upper bound of upperi and is taxed at a rate of percenti. 
        /// The brackets are sorted by upper bound (i.e. upperi-1 < upperi for 0 < i < brackets.length).
        /// Tax is calculated as follows:
        /// The first upper0 dollars earned are taxed at a rate of percent0.
        /// The next upper1 - upper0 dollars earned are taxed at a rate of percent1.
        /// The next upper2 - upper1 dollars earned are taxed at a rate of percent2.
        /// And so on.
        /// You are given an integer income representing the amount of money you earned.
        /// Return the amount of money that you have to pay in taxes.Answers within 10-5 of the actual answer will be accepted.
        /// </summary>
        public _02303_CalculateAmountPaidInTaxes()
        {
            Console.WriteLine(CalculateTax(
            [
                [3,50],
                [7,10],
                [15,25]
            ],
            10
            ));
            Console.WriteLine(CalculateTax(
            [
                [1,0],
                [4,25],
                [5,50]
            ],
            2
            ));
            Console.WriteLine(CalculateTax(
            [
                [2,50]
            ],
            0
            ));
        }

        private static double CalculateTax(int[][] brackets, int income)
        {
            double res = 0;

            for (int i = brackets.Length - 1; i > 0; i--)
            {
                brackets[i][0] -= brackets[i - 1][0];
            }

            for (int i = 0; i < brackets.Length; i++)
            {
                if (income <= 0) break;
                else
                {
                    if (brackets[i][0] > income)
                    {
                        res += income * brackets[i][1] / 100d;
                        income = 0;
                    }
                    else
                    {
                        res += brackets[i][0] * brackets[i][1] / 100d;
                        income -= brackets[i][0];
                    }
                }
            }

            return res;
        }
    }
}
