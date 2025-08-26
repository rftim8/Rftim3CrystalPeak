namespace Rftim3Console.System.Exceptions
{
    public class RftArgumentException
    {
        public RftArgumentException()
        {
            // Define some integers for a division operation.
            int[] values = [10, 7];
            foreach (int value in values)
            {
                try
                {
                    Console.WriteLine($"{value} divided by 2 is {DivideByTwo(value)}");
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine($"{e.GetType().Name}: {e.Message}");
                }
                Console.WriteLine();
            }
        }

        private static int DivideByTwo(int num)
        {
            // If num is an odd number, throw an ArgumentException.
            // 0111
            // 0001
            if ((num & 1) == 1) throw new ArgumentException(string.Format("{0} is not an even number", num), nameof(num));

            // num is even, return half of its value.
            return num / 2;
        }
    }
}