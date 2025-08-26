namespace Rftim3LeetCode.Temp
{
    public class _00278_FirstBadVersion
    {
        /// <summary>
        /// You are a product manager and currently leading a team to develop a new product. Unfortunately, the latest version of your product fails the quality check. 
        /// Since each version is developed based on the previous version, all the versions after a bad version are also bad.
        /// Suppose you have n versions[1, 2, ..., n] and you want to find out the first bad one, which causes all the following ones to be bad.
        /// You are given an API bool isBadVersion(version) which returns whether version is bad.Implement a function to find the first bad version.
        /// You should minimize the number of calls to the API.
        /// </summary>
        public _00278_FirstBadVersion()
        {
            Console.WriteLine(FirstBadVersion0(5, 4));
            Console.WriteLine(FirstBadVersion0(1, 1));
        }

        public static int FirstBadVersion0(int a0, int a1) => RftFirstBadVersion0(a0, a1);

        private static int RftFirstBadVersion0(int n, int m)
        {
            int i = 1,
            j = n;
            while (i <= j)
            {
                int mid = i + (j - i) / 2;
                if (IsBadVersion(mid, m)) j = mid - 1;
                else i = mid + 1;
            }

            return j + 1;
        }

        private static bool IsBadVersion(int n, int m)
        {
            if (n >= m) return true;
            else return false;
        }
    }
}
