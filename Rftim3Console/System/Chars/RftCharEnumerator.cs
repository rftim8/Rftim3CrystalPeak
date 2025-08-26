namespace Rftim3Console.System.Chars
{
    public class RftCharEnumerator
    {
        public RftCharEnumerator()
        {
            string title = "A Tale of Two Cities";
            CharEnumerator chEnum = title.GetEnumerator();
            int ctr = 1;
            string? outputLine1 = null;
            string? outputLine2 = null;
            string? outputLine3 = null;

            while (chEnum.MoveNext())
            {
                outputLine1 += ctr < 10 || ctr % 10 != 0 ? "  " : ctr / 10 + " ";
                outputLine2 += ctr % 10 + " ";
                outputLine3 += chEnum.Current + " ";
                ctr++;
            }

            Console.WriteLine($"The length of the string is {title.Length} characters:");
            Console.WriteLine(outputLine1);
            Console.WriteLine(outputLine2);
            Console.WriteLine(outputLine3);
        }
    }
}
