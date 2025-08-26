namespace Rftim3LeetCode.Temp
{
    public class _02848_PointsThatIntersectWithCars
    {
        /// <summary>
        /// You are given a 0-indexed 2D integer array nums representing the coordinates of the cars parking on a number line. 
        /// For any index i, nums[i] = [starti, endi] where starti is the starting point of the ith car and endi is the ending point of the ith car.
        /// Return the number of integer points on the line that are covered with any part of a car.
        /// </summary>
        public _02848_PointsThatIntersectWithCars()
        {
            Console.WriteLine(NumberOfPoints(
            [
                [ 3,6 ],
                [ 1,5 ],
                [ 4,7 ]
            ]));
            Console.WriteLine(NumberOfPoints(
            [
                [ 1,3 ],
                [ 5,8 ]
            ]));
        }

        private static int NumberOfPoints(IList<IList<int>> nums)
        {
            HashSet<int> r = [];

            foreach (IList<int> item in nums)
            {
                for (int i = item[0]; i <= item[1]; i++)
                {
                    r.Add(i);
                }
            }

            return r.Count;
        }
    }
}
