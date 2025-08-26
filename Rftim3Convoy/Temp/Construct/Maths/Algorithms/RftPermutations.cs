using System.Text;

namespace Rftim3Convoy.Temp.Construct.Maths.Algorithms
{
    public class RftPermutations
    {
        public RftPermutations()
        {
            StringPermutationsDemo();
        }

        private static readonly StringBuilder strBldr = new();

        public static void StringPermutationsDemo()
        {
            string result = Permute([1, 2, 3], 0);
            Console.WriteLine(result);
        }

        private static string Permute(int[] elementsList, int startIndex)
        {
            if (startIndex == elementsList.Length)
            {
                foreach (int element in elementsList)
                {
                    strBldr.Append(" " + element);
                }
                strBldr.AppendLine("");
            }
            else
            {
                for (int tempIndex = startIndex; tempIndex <= elementsList.Length - 1; tempIndex++)
                {
                    Swap(ref elementsList[startIndex], ref elementsList[tempIndex]);
                    Permute(elementsList, startIndex + 1);
                    Swap(ref elementsList[startIndex], ref elementsList[tempIndex]);
                }
            }

            return strBldr.ToString();
        }

        private static void Swap(ref int Char1, ref int Char2)
        {
            (Char2, Char1) = (Char1, Char2);
        }
    }
}
