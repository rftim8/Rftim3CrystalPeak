namespace Rftim3LeetCode.Temp
{
    public class _01196_HowManyApplesCanYouPutIntoTheBasket
    {
        /// <summary>
        /// You have some apples and a basket that can carry up to 5000 units of weight.
        /// 
        /// Given an integer array weight where weight[i] is the weight of the ith apple, 
        /// return the maximum number of apples you can put in the basket.
        /// </summary>
        public _01196_HowManyApplesCanYouPutIntoTheBasket()
        {
            Console.WriteLine(HowManyApplesCanYouPutIntoTheBasket0([100, 200, 150, 1000])); // 4
            Console.WriteLine(HowManyApplesCanYouPutIntoTheBasket0([900, 950, 800, 1000, 700, 800])); // 5
        }

        public static int HowManyApplesCanYouPutIntoTheBasket0(int[] a0) => RftHowManyApplesCanYouPutIntoTheBasket0(a0);

        public static int HowManyApplesCanYouPutIntoTheBasket1(int[] a0) => RftHowManyApplesCanYouPutIntoTheBasket1(a0);

        private static int RftHowManyApplesCanYouPutIntoTheBasket0(int[] weight)
        {
            Array.Sort(weight);
            int res = 0, c = 0, n = weight.Length;

            for (int i = 0; i < n; i++)
            {
                if (c + weight[i] <= 5000)
                {
                    c += weight[i];
                    res++;
                }
            }

            return res;
        }

        private static int RftHowManyApplesCanYouPutIntoTheBasket1(int[] weight)
        {
            Array.Sort(weight);
            int bagWeight = 5000;
            int count = 0;

            foreach (int w in weight)
            {
                bagWeight -= w;

                if (bagWeight < 0) return count;

                count++;
            }

            return weight.Length;
        }
    }
}
