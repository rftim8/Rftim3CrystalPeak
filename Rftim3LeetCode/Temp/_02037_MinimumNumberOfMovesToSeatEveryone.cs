namespace Rftim3LeetCode.Temp
{
    public class _02037_MinimumNumberOfMovesToSeatEveryone
    {
        /// <summary>
        /// There are n seats and n students in a room. You are given an array seats of length n, where seats[i] is the position of the ith seat. 
        /// You are also given the array students of length n, where students[j] is the position of the jth student.
        /// You may perform the following move any number of times:
        /// Increase or decrease the position of the ith student by 1 (i.e., moving the ith student from position x to x + 1 or x - 1)
        /// Return the minimum number of moves required to move each student to a seat such that no two students are in the same seat.
        /// Note that there may be multiple seats or students in the same position at the beginning.
        /// </summary>
        public _02037_MinimumNumberOfMovesToSeatEveryone()
        {
            Console.WriteLine(MinMovesToSeat([3, 1, 5], [2, 7, 4]));
            Console.WriteLine(MinMovesToSeat([4, 1, 5, 9], [1, 3, 2, 6]));
            Console.WriteLine(MinMovesToSeat([2, 2, 6, 6], [1, 3, 2, 6]));
        }

        private static int MinMovesToSeat(int[] seats, int[] students)
        {
            int n = students.Length;
            Array.Sort(seats);
            Array.Sort(students);

            int r = 0;
            for (int i = 0; i < n; i++)
            {
                r += Math.Abs(seats[i] - students[i]);
            }

            return r;
        }
    }
}
