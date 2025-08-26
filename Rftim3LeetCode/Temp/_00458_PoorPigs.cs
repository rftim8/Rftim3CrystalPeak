namespace Rftim3LeetCode.Temp
{
    public class _00458_PoorPigs
    {
        /// <summary>
        /// There are buckets buckets of liquid, where exactly one of the buckets is poisonous. 
        /// To figure out which one is poisonous, you feed some number of (poor) pigs the liquid to see whether they will die or not. 
        /// Unfortunately, you only have minutesToTest minutes to determine which bucket is poisonous.
        /// 
        /// You can feed the pigs according to these steps:
        /// 
        /// Choose some live pigs to feed.
        /// For each pig, choose which buckets to feed it. 
        /// The pig will consume all the chosen buckets simultaneously and will take no time. 
        /// Each pig can feed from any number of buckets, and each bucket can be fed from by any number of pigs.
        /// Wait for minutesToDie minutes. You may not feed any other pigs during this time.
        /// After minutesToDie minutes have passed, any pigs that have been fed the poisonous bucket will die, and all others will survive.
        /// Repeat this process until you run out of time.
        /// Given buckets, minutesToDie, and minutesToTest, return the minimum number of pigs needed to figure out which bucket is poisonous within the allotted time.
        /// </summary>
        public _00458_PoorPigs()
        {
            Console.WriteLine(PoorPigs0(4, 15, 15));
            Console.WriteLine(PoorPigs0(4, 15, 30));
        }

        public static int PoorPigs0(int a0, int a1, int a2) => RftPoorPigs0(a0, a1, a2);

        public static int PoorPigs1(int a0, int a1, int a2) => RftPoorPigs1(a0, a1, a2);

        private static int RftPoorPigs0(int buckets, int minutesToDie, int minutesToTest)
        {
            return (int)Math.Ceiling(Math.Log2(buckets) / Math.Log2(minutesToTest / minutesToDie + 1));
        }

        private static int RftPoorPigs1(int buckets, int minutesToDie, int minutesToTest)
        {
            if (buckets < 2) return 0;

            int n = 1;
            int c = 1;
            int x = 1 + minutesToTest / minutesToDie;

            while (x * n < buckets)
            {
                n = x * n;
                c++;
            }

            return c;
        }
    }
}
