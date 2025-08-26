using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00735_AsteroidCollision
    {
        /// <summary>
        /// We are given an array asteroids of integers representing asteroids in a row.
        /// For each asteroid, the absolute value represents its size, and the sign represents its direction(positive meaning right, negative meaning left). 
        /// Each asteroid moves at the same speed.
        /// Find out the state of the asteroids after all collisions.If two asteroids meet, the smaller one will explode.
        /// If both are the same size, both will explode.
        /// Two asteroids moving in the same direction will never meet.
        /// </summary>
        public _00735_AsteroidCollision()
        {
            int[] x = AsteroidCollision([5, 10, -5]);
            int[] x0 = AsteroidCollision([8, -8]);
            int[] x1 = AsteroidCollision([10, 2, -5]);

            RftTerminal.RftReadResult(x);
            RftTerminal.RftReadResult(x0);
            RftTerminal.RftReadResult(x1);
        }

        private static int[] AsteroidCollision(int[] asteroids)
        {
            Stack<int> stack = new();
            foreach (int ast in asteroids)
            {
                bool x = true;
                while (stack.Count != 0 && ast < 0 && 0 < stack.Peek())
                {
                    if (!x) break;
                    if (stack.Peek() < -ast)
                    {
                        stack.Pop();
                        continue;
                    }
                    else if (stack.Peek() == -ast)
                    {
                        stack.Pop();
                    }
                    x = false;
                }
                if (x) stack.Push(ast);
            }

            int[] ans = new int[stack.Count];
            for (int t = ans.Length - 1; t >= 0; --t)
            {
                ans[t] = stack.Pop();
            }

            return ans;
        }

        private static int[] AsteroidCollision0(int[] asteroids)
        {
            Stack<int> stack = new();

            for (int i = 0; i < asteroids.Length; i++)
            {
                int curr = asteroids[i];
                if (stack.Count == 0) stack.Push(curr);
                else
                {
                    while (stack.Count > 0)
                    {
                        if (stack.Peek() > 0 && curr < 0)
                        {
                            int sRMass = Math.Abs(stack.Peek());
                            int nRMass = Math.Abs(curr);
                            if (sRMass == nRMass)
                            {
                                stack.Pop();
                                break;
                            }
                            else if (sRMass < nRMass)
                            {
                                stack.Pop();
                                if (stack.Count == 0)
                                {
                                    stack.Push(curr);
                                    break;
                                }
                            }
                            else break;
                        }
                        else
                        {
                            stack.Push(curr);
                            break;
                        }
                    }
                }
            }
            int[] ans = [.. stack];
            Array.Reverse(ans);

            return ans;
        }
    }
}
