namespace Rftim3LeetCode.Temp
{
    public class _00657_RobotReturnToOrigin
    {
        /// <summary>
        /// There is a robot starting at the position (0, 0), the origin, on a 2D plane. 
        /// Given a sequence of its moves, judge if this robot ends up at (0, 0) after it completes its moves.
        /// You are given a string moves that represents the move sequence of the robot where moves[i] represents its ith move.
        /// Valid moves are 'R' (right), 'L' (left), 'U' (up), and 'D' (down).
        /// Return true if the robot returns to the origin after it finishes all of its moves, or false otherwise.
        /// Note: The way that the robot is "facing" is irrelevant. 
        /// 'R' will always make the robot move to the right once, 'L' will always make it move left, etc.
        /// Also, assume that the magnitude of the robot's movement is the same for each move.
        /// </summary>
        public _00657_RobotReturnToOrigin()
        {
            Console.WriteLine(RobotReturnToOrigin0("UD"));
            Console.WriteLine(RobotReturnToOrigin0("LL"));
        }

        public static bool RobotReturnToOrigin0(string a0) => RftRobotReturnToOrigin0(a0);

        private static bool RftRobotReturnToOrigin0(string moves)
        {
            int x = 0, y = 0;

            for (int i = 0; i < moves.Length; i++)
            {
                switch (moves[i])
                {
                    case 'U':
                        y++;
                        break;
                    case 'D':
                        y--;
                        break;
                    case 'L':
                        x--;
                        break;
                    case 'R':
                        x++;
                        break;
                    default:
                        break;
                }
            }

            return x == 0 && y == 0;
        }
    }
}