namespace Rftim3Console.System.Actions
{
    public class RftActionT
    {
        public RftActionT()
        {
            List<string> names = ["Bruce", "Alfred", "Tim", "Richard"];

            Action<string> x = Print;
            names.ForEach(x);

            names.ForEach(Print);

            names.ForEach(Console.WriteLine);

            #region Legacy
            //names.ForEach(delegate (string s)
            //{
            //    Console.WriteLine(s);
            //});
            #endregion
        }

        private static void Print(string s)
        {
            Console.WriteLine(s);
        }
    }
}
