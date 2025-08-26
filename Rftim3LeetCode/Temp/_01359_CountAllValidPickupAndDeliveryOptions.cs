namespace Rftim3LeetCode.Temp
{
    public class _01359_CountAllValidPickupAndDeliveryOptions
    {
        /// <summary>
        /// Given n orders, each order consist in pickup and delivery services. 
        /// Count all valid pickup/delivery possible sequences such that delivery(i) is always after of pickup(i). 
        /// Since the answer may be too large, return it modulo 10^9 + 7.
        /// </summary>
        public _01359_CountAllValidPickupAndDeliveryOptions()
        {
            Console.WriteLine(RftCountAllValidPickupAndDeliveryOptions0(1));
            Console.WriteLine(RftCountAllValidPickupAndDeliveryOptions0(2));
            Console.WriteLine(RftCountAllValidPickupAndDeliveryOptions0(3));
        }

        public static int CountAllValidPickupAndDeliveryOptions0(int a0) => RftCountAllValidPickupAndDeliveryOptions0(a0);
        public static int CountAllValidPickupAndDeliveryOptions1(int a0) => RftCountAllValidPickupAndDeliveryOptions1(a0);

        private static int RftCountAllValidPickupAndDeliveryOptions0(int n)
        {
            if (n == 0) return 0;

            long r = 1;
            int mod = 1000000007;

            for (int i = 1; i <= n; i++)
            {
                r *= i;
                r *= 2 * i - 1;
                r %= mod;
            }

            return (int)r;
        }

        private static int RftCountAllValidPickupAndDeliveryOptions1(int n)
        {
            int mod = 1000_000_007;
            if (n == 1) return 1;
            if (n == 2) return 6;

            long dp = RftCountAllValidPickupAndDeliveryOptions1(n - 1);

            return (int)(dp * ((n - 1) * 2 + 1) * n % mod);
        }
    }
}