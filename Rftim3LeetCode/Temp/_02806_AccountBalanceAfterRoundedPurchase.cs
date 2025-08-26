namespace Rftim3LeetCode.Temp
{
    public class _02806_AccountBalanceAfterRoundedPurchase
    {
        /// <summary>
        /// Initially, you have a bank account balance of 100 dollars.
        /// You are given an integer purchaseAmount representing the amount you will spend on a purchase in dollars.
        /// At the store where you will make the purchase, the purchase amount is rounded to the nearest multiple of 10. 
        /// In other words, you pay a non-negative amount, roundedAmount, such that roundedAmount is a multiple of 10 and abs(roundedAmount - purchaseAmount) is minimized.
        /// If there is more than one nearest multiple of 10, the largest multiple is chosen.
        /// Return an integer denoting your account balance after making a purchase worth purchaseAmount dollars from the store.
        /// Note: 0 is considered to be a multiple of 10 in this problem.
        /// </summary>
        public _02806_AccountBalanceAfterRoundedPurchase()
        {
            Console.WriteLine(AccountBalanceAfterPurchase(9));
            Console.WriteLine(AccountBalanceAfterPurchase(15));
        }

        private static int AccountBalanceAfterPurchase(int purchaseAmount)
        {
            int m = purchaseAmount % 10;

            if (m >= 5) return 100 - (purchaseAmount + 10 - m);
            else return 100 - (purchaseAmount - m);
        }
    }
}
