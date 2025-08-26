using System.Text;

namespace Rftim3Console.System.Texts.StringBuilders
{
    public class RftStringBuilder
    {
        public RftStringBuilder()
        {
            RftProperties();
        }

        private static void RftProperties()
        {
            StringBuilder stringBuilder = new();
            stringBuilder.EnsureCapacity(1000);
            stringBuilder.Append("first sentence\n");
            stringBuilder.AppendFormat("second {0} in the {1} sentence", "append", "second");
            Console.WriteLine($"String builder content: {stringBuilder}");
            Console.WriteLine($"String builder capacity: {stringBuilder.Capacity}");
        }
    }
}
