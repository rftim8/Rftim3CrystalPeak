namespace Rftim3LeetCode.Temp
{
    public class _02125_NumberOfLaserBeamsInABank
    {
        /// <summary>
        /// Anti-theft security devices are activated inside a bank. You are given a 0-indexed binary string array bank representing 
        /// the floor plan of the bank, which is an m x n 2D matrix. 
        /// bank[i] represents the ith row, consisting of '0's and '1's. '0' means the cell is empty, while'1' means the cell has a security device.
        /// 
        /// There is one laser beam between any two security devices if both conditions are met:
        /// 
        /// The two devices are located on two different rows: r1 and r2, where r1<r2.
        /// For each row i where r1 < i<r2, there are no security devices in the ith row.
        /// Laser beams are independent, i.e., one beam does not interfere nor join with another.
        /// 
        /// Return the total number of laser beams in the bank.
        /// </summary>
        public _02125_NumberOfLaserBeamsInABank()
        {
            int a0 = NumberOfBeams0(["011001", "000000", "010100", "001000"]);
            Console.WriteLine(a0);

            int a1 = NumberOfBeams0(["000", "111", "000"]);
            Console.WriteLine(a1);
        }

        public static int NumberOfBeams0(string[] a0) => RftNumberOfBeams0(a0);

        public static int NumberOfBeams1(string[] a0) => RftNumberOfBeams1(a0);

        private static int RftNumberOfBeams0(string[] bank)
        {
            int n = bank.Length;
            List<int> x = [];
            int r = 0;

            bool f = false;
            for (int i = 0; i < n; i++)
            {
                int m = bank[i].Length;
                int c = 0;

                for (int j = 0; j < m; j++)
                {
                    if (bank[i][j] == '1') c++;
                }

                if (c != 0)
                {
                    if (f) r += x[^1] * c;

                    x.Add(c);
                    f = true;
                }
            }

            return r;
        }

        private static int RftNumberOfBeams1(string[] bank)
        {
            int prevNonemptyRowDeviceCount = 0;
            int totalLasers = 0;

            foreach (string row in bank)
            {
                int rowDeviceCount = 0;
                foreach (char c in row)
                {
                    if (c == '1') ++rowDeviceCount;
                }

                if (rowDeviceCount == 0) continue;

                totalLasers += prevNonemptyRowDeviceCount * rowDeviceCount;
                prevNonemptyRowDeviceCount = rowDeviceCount;
            }

            return totalLasers;
        }
    }
}
