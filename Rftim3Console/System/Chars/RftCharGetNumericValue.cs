namespace Rftim3Console.System.Chars
{
    public class RftCharGetNumericValue
    {
        public RftCharGetNumericValue()
        {
            for (int utf32 = 0x10107; utf32 <= 0x10133; utf32++)
            {
                string surrogate = char.ConvertFromUtf32(utf32);
                for (int ctr = 0; ctr < surrogate.Length; ctr++)
                {
                    Console.Write($"U+{Convert.ToUInt16(surrogate[ctr]):X4} at position {ctr}: {char.GetNumericValue(surrogate, ctr)}     ");
                }

                Console.WriteLine();
            }
        }
    }
}
