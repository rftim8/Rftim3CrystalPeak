namespace Rftim3LeetCode.Temp
{
    public class _01710_MaximumUnitsOnATruck
    {
        /// <summary>
        /// You are assigned to put some amount of boxes onto one truck.
        /// You are given a 2D array boxTypes, where boxTypes[i] = [numberOfBoxesi, numberOfUnitsPerBoxi]:
        /// numberOfBoxesi is the number of boxes of type i.
        /// numberOfUnitsPerBoxi is the number of units in each box of the type i.
        /// You are also given an integer truckSize, which is the maximum number of boxes that can be put on the truck.
        /// You can choose any boxes to put on the truck as long as the number of boxes does not exceed truckSize.
        /// Return the maximum total number of units that can be put on the truck.
        /// </summary>
        public _01710_MaximumUnitsOnATruck()
        {
            Console.WriteLine(MaximumUnits(
            [
                [1,3],
                [2,2],
                [3,1]
            ],
            4
            ));
            Console.WriteLine(MaximumUnits(
            [
                [5,10],
                [2,5],
                [4,7],
                [3,9]
            ],
            10
            ));
        }

        private static int MaximumUnits(int[][] boxTypes, int truckSize)
        {
            int size = 0;
            int c = 0;

            foreach (int[]? item in boxTypes.OrderByDescending(bt => bt[1]))
            {
                if (size + item[0] < truckSize)
                {
                    c += item[0] * item[1];
                    size += item[0];
                }
                else
                {
                    c += (truckSize - size) * item[1];
                    break;
                }
            }

            return c;
        }

        private static int MaximumUnits0(int[][] boxTypes, int truckSize)
        {
            Array.Sort(boxTypes, (a, b) => b[1] - a[1]);

            int index = 0;
            int ans = 0;

            while (truckSize > 0 && index < boxTypes.Length)
            {
                int count = boxTypes[index][0], units = boxTypes[index][1];

                if (truckSize >= count)
                {
                    truckSize -= count;
                    ans += count * units;
                    index++;
                }
                else
                {
                    ans += truckSize * units;
                    break;
                }
            }

            return ans;
        }
    }
}
