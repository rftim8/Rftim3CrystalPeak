namespace Rftim3LeetCode.Temp
{
    public class _01672_RichestCustomerWealth
    {
        /// <summary>
        /// You are given an m x n integer grid accounts where accounts[i][j] is the amount of money the i​​​​​​​​​​​th​​​​ customer has in the j​​​​​​​​​​​th​​​​ bank. 
        /// Return the wealth that the richest customer has.
        /// A customer's wealth is the amount of money they have in all their bank accounts. The richest customer is the customer that has the maximum wealth.
        /// </summary>
        public _01672_RichestCustomerWealth()
        {
            Console.WriteLine(MaximumWealth([
                [1,2,3],
                [3,2,1]
            ]));

            Console.WriteLine(MaximumWealth([
                [1,5],
                [7,3],
                [3,5]
            ]));

            Console.WriteLine(MaximumWealth([
                [2,8,7],
                [7,1,3],
                [1,9,5]
            ]));
        }

        private static int MaximumWealth(int[][] accounts)
        {
            int n = accounts.Length;
            int[] x = new int[n];

            for (int i = 0; i < n; i++)
            {
                x[i] = accounts[i].Sum();
            }

            return x.Max();
        }
    }
}
