namespace Rftim3LeetCode.Temp
{
    public class _00717_OneBitAndTwoBitCharacters
    {
        /// <summary>
        /// We have two special characters:
        /// The first character can be represented by one bit 0.
        /// The second character can be represented by two bits(10 or 11).
        /// Given a binary array bits that ends with 0, return true if the last character must be a one-bit character.
        /// </summary>
        public _00717_OneBitAndTwoBitCharacters()
        {
            Console.WriteLine(IsOneBitCharacter([1, 0, 0]));
            Console.WriteLine(IsOneBitCharacter([1, 1, 1, 0]));
            Console.WriteLine(IsOneBitCharacter([0, 0]));
            Console.WriteLine(IsOneBitCharacter([0, 1, 0]));
        }

        private static bool IsOneBitCharacter(int[] bits)
        {
            int n = bits.Length;

            int last = 1;

            for (int i = 0; i < n; i++)
            {
                if (bits[i] == 1 && bits[i + 1] == 0 ||
                    bits[i] == 1 && bits[i + 1] == 1)
                {
                    i++;
                    last = 2;
                }
                else if (bits[i] == 0) last = 1;
            }

            return last == 1;
        }

        private static bool IsOneBitCharacter0(int[] bits)
        {
            bool sequence = false;
            for (int i = 0; i < bits.Length; i++)
            {
                if (sequence)
                {
                    if (i == bits.Length - 1) return false;
                    sequence = false;
                }
                else
                {
                    if (bits[i] == 1) sequence = true;
                }
            }

            return true;
        }
    }
}
