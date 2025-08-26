namespace Rftim3LeetCode.Temp
{
    public class _01518_WaterBottles
    {
        /// <summary>
        /// There are numBottles water bottles that are initially full of water. 
        /// You can exchange numExchange empty water bottles from the market with one full water bottle.
        /// The operation of drinking a full water bottle turns it into an empty bottle.
        /// Given the two integers numBottles and numExchange, return the maximum number of water bottles you can drink.
        /// </summary>
        public _01518_WaterBottles()
        {
            Console.WriteLine(NumWaterBottles(9, 3));
            Console.WriteLine(NumWaterBottles(15, 4));
        }

        private static int NumWaterBottles(int numBottles, int numExchange)
        {
            int c = numBottles;
            while (numBottles / numExchange > 0)
            {
                c += numBottles / numExchange;
                numBottles = numBottles / numExchange + numBottles % numExchange;
            }

            return c;
        }

        private static int NumWaterBottles0(int numBottles, int numExchange)
        {
            int result = numBottles;
            int empty = numBottles;
            while (empty >= numExchange)
            {
                int x = empty / numExchange;
                result += x;
                empty = x + empty % numExchange;
            }

            return result;
        }
    }
}
