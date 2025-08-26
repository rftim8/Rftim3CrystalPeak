namespace Rftim3Console.System.Exceptions
{
    public class RftArgumentNullException
    {
        public RftArgumentNullException()
        {
            string? x = null;

            try
            {
                RftTest(x);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void RftTest(string? x)
        {
            if (x is null) throw new ArgumentNullException(string.Format("{0}", x), "Error: Empty string provided!");
        }
    }
}
