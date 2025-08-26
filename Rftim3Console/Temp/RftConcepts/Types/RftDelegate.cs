namespace Rftim3Console.Temp.RftConcepts.Types
{
    public class RftDelegate
    {
        private delegate double Function(double x);

        /// <summary>
        /// Method as entity
        /// </summary>
        public RftDelegate()
        {
            double[] a = [2.3, 3.4, 5.5];

            double[] b = RftExample(a, (x) => x * x);

            for (int i = 0; i < b.Length; i++)
            {
                Console.WriteLine(b[i]);
            }
        }

        private static double[] RftExample(double[] a, Function f)
        {
            double[] result = new double[a.Length];

            for (int i = 0; i < a.Length; i++)
            {
                result[i] = f(a[i]);
            }

            return result;
        }
    }
}
