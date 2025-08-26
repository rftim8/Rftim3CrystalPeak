namespace Rftim3LeetCode.Temp
{
    public class _02347_BestPokerHand
    {
        /// <summary>
        /// You are given an integer array ranks and a character array suits. 
        /// You have 5 cards where the ith card has a rank of ranks[i] and a suit of suits[i].
        /// The following are the types of poker hands you can make from best to worst:
        /// "Flush": Five cards of the same suit.
        /// "Three of a Kind": Three cards of the same rank.
        /// "Pair": Two cards of the same rank.
        /// "High Card": Any single card.
        /// Return a string representing the best type of poker hand you can make with the given cards.
        /// Note that the return values are case-sensitive.
        /// </summary>
        public _02347_BestPokerHand()
        {
            Console.WriteLine(BestHand([13, 2, 3, 1, 9], ['a', 'a', 'a', 'a', 'a']));
            Console.WriteLine(BestHand([4, 4, 2, 4, 4], ['d', 'a', 'a', 'b', 'c']));
            Console.WriteLine(BestHand([10, 10, 2, 12, 9], ['a', 'b', 'c', 'a', 'd']));
        }

        private static string BestHand(int[] ranks, char[] suits)
        {
            bool isSuit = true;
            foreach (char suit in suits)
            {
                if (suit != suits[0])
                {
                    isSuit = false;
                    break;
                }
            }
            if (isSuit) return "Flush";

            Dictionary<int, int> r = [];
            foreach (int rank in ranks)
            {
                r.TryAdd(rank, 0);
                r[rank]++;
            }

            if (r.Values.Max() >= 3) return "Three of a Kind";
            else if (r.Values.Max() == 2) return "Pair";
            else return "High Card";
        }
    }
}
