namespace Rftim3LeetCode.Temp
{
    public class _02614_PrimeInDiagonal
    {
        /// <summary>
        /// You are given a 0-indexed two-dimensional integer array nums.
        /// Return the largest prime number that lies on at least one of the diagonals of nums.
        /// In case, no prime is present on any of the diagonals, return 0.
        /// Note that:
        /// An integer is prime if it is greater than 1 and has no positive integer divisors other than 1 and itself.
        /// An integer val is on one of the diagonals of nums if there exists an integer i for which nums[i][i] = val or an i for which nums[i][nums.length - i - 1] = val.
        /// In the above diagram, one diagonal is [1,5,9] and another diagonal is [3,5,7].
        /// </summary>
        public _02614_PrimeInDiagonal()
        {
            Console.WriteLine(DiagonalPrime(
            [
                [1,2,3],
                [5,6,7],
                [9,10,11]
            ]));
            Console.WriteLine(DiagonalPrime(
            [
                [1,2,3],
                [5,17,7],
                [9,11,10]
            ]));
        }

        private static int DiagonalPrime(int[][] nums)
        {
            static bool IsPrime(int num)
            {
                if (num == 1) return false;
                for (int i = 2; i <= Math.Sqrt(num); i++)
                {
                    if (num % i == 0) return false;
                }

                return true;
            }

            int r = 0;
            int n = nums.Length;
            for (int i = 0; i < n; i++)
            {
                if (IsPrime(nums[i][i])) r = Math.Max(r, nums[i][i]);
                if (IsPrime(nums[i][n - 1 - i])) r = Math.Max(r, nums[i][n - 1 - i]);
            }

            return r;
        }
    }
}
