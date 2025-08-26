namespace Rftim3Convoy.Temp.Construct.Maths.Algorithms.Sorting
{
    public class RftSelectSort
    {
        public RftSelectSort()
        {
            int[] x = SelectionSort([4, 2, 3, 4, 1]);
            foreach (int item in x)
            {
                Console.WriteLine(item);
            }
        }

        private static int[] SelectionSort(int[] arr)
        {
            // Mutates arr so that it is sorted via selecting the minimum element and
            // swapping it with the corresponding index
            int min_index;
            for (int i = 0; i < arr.Length; i++)
            {
                min_index = i;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[min_index]) min_index = j;
                }
                // Swap current index with minimum element in rest of list
                (arr[i], arr[min_index]) = (arr[min_index], arr[i]);
            }

            return arr;
        }
    }
}
