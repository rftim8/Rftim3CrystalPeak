namespace Rftim3LeetCode.Temp
{
    public class _02591_DistributeMoneyToMaximumChildren
    {
        /// <summary>
        /// You are given an integer money denoting the amount of money (in dollars) that you have and another integer children 
        /// denoting the number of children that you must distribute the money to.
        /// You have to distribute the money according to the following rules:
        /// All money must be distributed.
        /// Everyone must receive at least 1 dollar.
        /// Nobody receives 4 dollars.
        /// Return the maximum number of children who may receive exactly 8 dollars if you distribute the money according to the aforementioned rules.
        /// If there is no way to distribute the money, return -1.
        /// </summary>
        public _02591_DistributeMoneyToMaximumChildren()
        {
            Console.WriteLine(DistMoney(20, 3));
            Console.WriteLine(DistMoney(16, 2));
        }

        private static int DistMoney(int money, int children)
        {
            int eights = Math.DivRem(money - children, 7, out int rest);

            if (eights > children) eights = children - 1;
            else if (eights == children && rest != 0) eights--;
            else if (eights + 1 == children && rest == 3) eights--;
            else if (money < children) eights = -1;

            return eights;
        }

        private static int DistMoney0(int money, int children)
        {
            if (money < children) return -1;
            money -= children;

            (int div, int mod) = (money / 7, money % 7);

            if (div == children) return mod == 0 ? children : children - 1;
            if (div < children) return mod == 3 && children - div == 1 ? div - 1 : div;

            return children - 1;
        }
    }
}
