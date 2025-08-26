namespace Rftim3LeetCode.Temp
{
    public class _00881_BoatsToSavePeople
    {
        /// <summary>
        /// You are given an array people where people[i] is the weight of the ith person, 
        /// and an infinite number of boats where each boat can carry a maximum weight of limit. 
        /// Each boat carries at most two people at the same time, provided the sum of the weight of those people is at most limit.
        /// Return the minimum number of boats to carry every given person.
        /// </summary>
        public _00881_BoatsToSavePeople()
        {
            Console.WriteLine(BoatsToSavePeople0([1, 2], 3));
            Console.WriteLine(BoatsToSavePeople0([3, 2, 2, 1], 3));
            Console.WriteLine(BoatsToSavePeople0([3, 5, 3, 4], 5));
            Console.WriteLine(BoatsToSavePeople0([5, 1, 4, 2], 6));
            Console.WriteLine(BoatsToSavePeople0([2, 4], 5));
            Console.WriteLine(BoatsToSavePeople0([2, 2], 5));
        }

        public static int BoatsToSavePeople0(int[] a0, int a1) => RftBoatsToSavePeople0(a0, a1);

        private static int RftBoatsToSavePeople0(int[] people, int limit)
        {
            int n = people.Length;
            Array.Sort(people);

            int x = 0, l = 0, r = n - 1;

            while (l <= r)
            {
                x++;
                if (people[l] + people[r] <= limit) l++;
                r--;
            }

            return x;
        }
    }
}