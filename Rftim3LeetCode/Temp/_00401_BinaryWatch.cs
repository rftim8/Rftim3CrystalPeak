using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00401_BinaryWatch
    {
        /// <summary>
        /// A binary watch has 4 LEDs on the top to represent the hours (0-11), and 6 LEDs on the bottom to represent the minutes (0-59). 
        /// Each LED represents a zero or one, with the least significant bit on the right.
        /// For example, the below binary watch reads "4:51".
        /// Given an integer turnedOn which represents the number of LEDs that are currently on(ignoring the PM), return all possible times the watch could represent.
        /// You may return the answer in any order.
        /// The hour must not contain a leading zero.
        /// For example, "01:00" is not valid. It should be "1:00".
        /// The minute must consist of two digits and may contain a leading zero.
        /// For example, "10:2" is not valid. It should be "10:02".
        /// </summary>
        public _00401_BinaryWatch()
        {
            IList<string> x = ReadBinaryWatch0(1);
            RftTerminal.RftReadResult(x);

            IList<string> x0 = ReadBinaryWatch0(9);
            RftTerminal.RftReadResult(x0);
        }

        public static IList<string> ReadBinaryWatch0(int a0) => RftReadBinaryWatch0(a0);

        private static List<string> RftReadBinaryWatch0(int turnedOn)
        {
            List<string> result = [];
            GoOverAllBits(result, 0, 0, 0, turnedOn);

            return result;
        }

        private static void GoOverAllBits(List<string> result, int time, int startBit, int count, int num)
        {
            if (startBit == 10 || count == num)
            {
                if (count == num && IsValid(time)) result.Add(Print(time));

                return;
            }

            for (int i = startBit; i < 10; i++)
            {
                GoOverAllBits(result, time | 1 << i, i + 1, count + 1, num);
            }
        }

        private static bool IsValid(int time)
        {
            return (time & 0x3f) < 60 && (time >> 6 & 0xf) < 12;
        }

        private static string Print(int time)
        {
            int hour = time >> 6 & 0xf;
            int minutes = time & 0x3f;

            string timeFormatted = $"{hour}:{minutes}";
            if (minutes < 10) timeFormatted = $"{hour}:0{minutes}";

            return timeFormatted;
        }
    }
}
