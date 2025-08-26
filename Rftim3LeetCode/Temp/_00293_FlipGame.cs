using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00293_FlipGame
    {
        /// <summary>
        /// You are playing a Flip Game with your friend.
        /// 
        /// You are given a string currentState that contains only '+' and '-'. 
        /// You and your friend take turns to flip two consecutive "++" into "--". 
        /// The game ends when a person can no longer make a move, 
        /// and therefore the other person will be the winner.
        /// 
        /// Return all possible states of the string currentState after one valid move. 
        /// You may return the answer in any order. 
        /// If there is no valid move, return an empty list[].
        /// </summary>
        public _00293_FlipGame()
        {
            IList<string> a0 = FlipGame0("++++");
            RftTerminal.RftReadResult(a0);

            IList<string> a1 = FlipGame0("+");
            RftTerminal.RftReadResult(a1);
        }

        public static IList<string> FlipGame0(string a0) => RftFlipGame0(a0);

        public static IList<string> FlipGame1(string a0) => RftFlipGame1(a0);

        private static List<string> RftFlipGame0(string currentState)
        {
            List<string> res = [];
            int n = currentState.Length;

            for (int i = 0; i < n - 1; i++)
            {
                if ($"{currentState[i]}{currentState[i + 1]}" == "++")
                {
                    char[] x = currentState.ToCharArray();
                    x[i] = '-';
                    x[i + 1] = '-';
                    res.Add(string.Join("", x));
                }
            }

            return res;
        }

        private static List<string> RftFlipGame1(string currentState)
        {
            List<string> answer = [];

            for (int i = 0; i < currentState.Length - 1; i++)
            {
                if (currentState[i] == '+' && currentState[i + 1] == '+') answer.Add(string.Concat(currentState.AsSpan(0, i), "--", currentState.AsSpan(i + 2)));
            }

            return answer;
        }
    }
}
