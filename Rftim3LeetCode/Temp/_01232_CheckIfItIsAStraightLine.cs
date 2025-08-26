namespace Rftim3LeetCode.Temp
{
    public class _01232_CheckIfItIsAStraightLine
    {
        /// <summary>
        /// You are given an array coordinates, coordinates[i] = [x, y], where [x, y] represents the coordinate of a point. 
        /// Check if these points make a straight line in the XY plane.
        /// </summary>
        public _01232_CheckIfItIsAStraightLine()
        {
            Console.WriteLine(CheckStraightLine([
                [1,2],
                [2,3],
                [3,4],
                [4,5],
                [5,6],
                [6,7]
            ]));

            Console.WriteLine(CheckStraightLine([
                [1,1],
                [2,2],
                [3,4],
                [4,5],
                [5,6],
                [7,7]
            ]));

            Console.WriteLine(CheckStraightLine([
                [0,0],
                [0,1],
                [0,-1]
            ]));

            Console.WriteLine(CheckStraightLine([
                [2,4],
                [2,5],
                [2,8]
            ]));

            Console.WriteLine(CheckStraightLine([
                [0,1],
                [1,3],
                [-4,-7],
                [5,11]
            ]));
        }

        private static bool CheckStraightLine(int[][] coordinates)
        {
            int n = coordinates.Length;

            int dx = coordinates[0][0] - coordinates[1][0];
            int dy = coordinates[0][1] - coordinates[1][1];

            for (int i = 2; i < n; i++)
            {
                if ((coordinates[i][0] - coordinates[0][0]) * dy != (coordinates[i][1] - coordinates[0][1]) * dx) return false;
            }

            return true;
        }
    }
}
