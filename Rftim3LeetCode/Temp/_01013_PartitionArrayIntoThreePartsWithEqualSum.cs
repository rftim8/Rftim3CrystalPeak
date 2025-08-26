namespace Rftim3LeetCode.Temp
{
    public class _01013_PartitionArrayIntoThreePartsWithEqualSum
    {
        /// <summary>
        /// Given an array of integers arr, return true if we can partition the array into three non-empty parts with equal sums.
        /// Formally, we can partition the array if we can find indexes 
        /// i + 1 < j with(arr[0] + arr[1] + ... + arr[i] == arr[i + 1] + arr[i + 2] + ... + arr[j - 1] == arr[j] + arr[j + 1] + ... + arr[arr.length - 1])
        /// </summary>
        public _01013_PartitionArrayIntoThreePartsWithEqualSum()
        {
            Console.WriteLine(CanThreePartsEqualSum([0, 2, 1, -6, 6, -7, 9, 1, 2, 0, 1]));
            Console.WriteLine(CanThreePartsEqualSum([0, 2, 1, -6, 6, 7, 9, -1, 2, 0, 1]));
            Console.WriteLine(CanThreePartsEqualSum([3, 3, 6, 5, -2, 2, 5, 1, -9, 4]));
        }

        private static bool CanThreePartsEqualSum(int[] arr)
        {
            if (arr.Sum() % 3 != 0) return false;

            int sum = arr.Sum() / 3;
            int j = 0;

            for (int i = 0; i < 3; i++)
            {
                bool init = true;
                int c = 0;

                if (j >= arr.Length) return false;

                while (init || j < arr.Length && c != sum)
                {
                    init = false;
                    c += arr[j];
                    j++;
                }

                if (c != sum) return false;
            }

            return true;
        }

        private static bool CanThreePartsEqualSum0(int[] arr)
        {
            int sum = arr.Sum();
            if (sum % 3 != 0) return false;

            int avg = sum / 3;
            int cnt = 0;
            int part = 0;
            foreach (int a in arr)
            {
                part += a;
                if (part == avg)
                {
                    cnt++;
                    if (cnt == 3) return true;

                    part = 0;
                }
            }

            return false;
        }
    }
}
