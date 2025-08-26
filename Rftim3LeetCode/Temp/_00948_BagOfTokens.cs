namespace Rftim3LeetCode.Temp
{
    public class _00948_BagOfTokens
    {
        /// <summary>
        /// You start with an initial power of power, an initial score of 0, 
        /// and a bag of tokens given as an integer array tokens, where each tokens[i] donates the value of tokeni.
        /// 
        /// Your goal is to maximize the total score by strategically playing these tokens.
        /// In one move, you can play an unplayed token in one of the two ways (but not both for the same token):
        /// 
        /// Face-up: If your current power is at least tokens[i], you may play tokeni, losing tokens[i] power and gaining 1 score.
        /// Face-down: If your current score is at least 1, you may play tokeni, gaining tokens[i] power and losing 1 score.
        /// Return the maximum possible score you can achieve after playing any number of tokens.
        /// </summary>
        public _00948_BagOfTokens()
        {
            Console.WriteLine(BagOfTokens0([100], 50));
            Console.WriteLine(BagOfTokens0([200, 100], 150));
            Console.WriteLine(BagOfTokens0([100, 200, 300, 400], 200));
        }

        public static int BagOfTokens0(int[] a0, int a1) => RftBagOfTokens0(a0, a1);

        public static int BagOfTokens1(int[] a0, int a1) => RftBagOfTokens1(a0, a1);

        // Two-Pointer
        private static int RftBagOfTokens0(int[] tokens, int power)
        {
            int low = 0;
            int high = tokens.Length - 1;
            int score = 0;
            Array.Sort(tokens);

            while (low <= high)
            {
                if (power >= tokens[low])
                {
                    score += 1;
                    power -= tokens[low];
                    low += 1;
                }
                else if (low < high && score > 0)
                {
                    score -= 1;
                    power += tokens[high];
                    high -= 1;
                }
                else return score;
            }

            return score;
        }

        // Linked List
        private static int RftBagOfTokens1(int[] tokens, int power)
        {
            int score = 0;
            Array.Sort(tokens);
            LinkedList<int> deque = [];

            foreach (int token in tokens)
            {
                deque.AddLast(token);
            }

            while (deque.Count != 0)
            {
                if (power >= deque.First())
                {
                    power -= deque.First();
                    deque.RemoveFirst();
                    score++;
                }
                else if (deque.Count > 1 && score > 0)
                {
                    power += deque.Last();
                    deque.RemoveLast();
                    score--;
                }
                else return score;
            }

            return score;
        }
    }
}
