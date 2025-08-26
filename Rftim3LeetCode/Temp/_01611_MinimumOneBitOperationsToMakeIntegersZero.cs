namespace Rftim3LeetCode.Temp
{
    public class _01611_MinimumOneBitOperationsToMakeIntegersZero
    {
        /// <summary>
        /// Given an integer n, you must transform it into 0 using the following operations any number of times:
        /// 
        /// Change the rightmost(0th) bit in the binary representation of n.
        /// Change the ith bit in the binary representation of n if the(i-1)th bit is set to 1 and the(i-2)th through 0th bits are set to 0.
        /// Return the minimum number of operations to transform n into 0.
        /// </summary>
        public _01611_MinimumOneBitOperationsToMakeIntegersZero()
        {
            Console.WriteLine(MinimumOneBitOperationsToMakeIntegersZero0(3));
            Console.WriteLine(MinimumOneBitOperationsToMakeIntegersZero0(6));
        }

        public static int MinimumOneBitOperationsToMakeIntegersZero0(int a0) => RftMinimumOneBitOperationsToMakeIntegersZero0(a0);

        public static int MinimumOneBitOperationsToMakeIntegersZero1(int a0) => RftMinimumOneBitOperationsToMakeIntegersZero1(a0);

        public static int MinimumOneBitOperationsToMakeIntegersZero2(int a0) => RftMinimumOneBitOperationsToMakeIntegersZero2(a0);

        private static int RftMinimumOneBitOperationsToMakeIntegersZero0(int n)
        {
            if (n == 0) return 0;

            int k = 0;
            int curr = 1;
            while (curr * 2 <= n)
            {
                curr *= 2;
                k++;
            }

            return (1 << k + 1) - 1 - RftMinimumOneBitOperationsToMakeIntegersZero0(n ^ curr);
        }

        // Math iteration
        public static int RftMinimumOneBitOperationsToMakeIntegersZero1(int n)
        {
            int ans = 0;
            int k = 0;
            int mask = 1;

            while (mask <= n)
            {
                if ((n & mask) != 0)
                {
                    ans = (1 << k + 1) - 1 - ans;
                }

                mask <<= 1;
                k++;
            }

            return ans;
        }

        // Gray code
        public static int RftMinimumOneBitOperationsToMakeIntegersZero2(int n)
        {
            int ans = n;
            ans ^= ans >> 16;
            ans ^= ans >> 8;
            ans ^= ans >> 4;
            ans ^= ans >> 2;
            ans ^= ans >> 1;

            return ans;
        }
    }
}