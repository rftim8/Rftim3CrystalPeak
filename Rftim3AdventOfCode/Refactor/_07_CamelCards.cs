using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;

namespace Rftim3AdventOfCode.Refactor
{
    public class _07_CamelCards : I_07_CamelCards
    {
        #region Static
        private readonly List<string>? data;

        public _07_CamelCards()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_07_CamelCards));
        }

        /// <summary>
        /// Your all-expenses-paid trip turns out to be a one-way, five-minute ride in an airship. 
        /// (At least it's a cool airship!) It drops you off at the edge of a vast desert and descends back to Island Island.
        /// 
        /// "Did you bring the parts?"
        /// 
        /// You turn around to see an Elf completely covered in white clothing, wearing goggles, and riding a large camel.
        /// 
        /// "Did you bring the parts?" she asks again, louder this time.You aren't sure what parts she's looking for; you're here to figure out why the sand stopped.
        /// 
        /// "The parts! For the sand, yes! Come with me; I will show you." She beckons you onto the camel.
        /// 
        /// After riding a bit across the sands of Desert Island, you can see what look like very large rocks covering half of the horizon.
        /// The Elf explains that the rocks are all along the part of Desert Island that is directly above Island Island, making it hard to even get there.
        /// Normally, they use big machines to move the rocks and filter the sand, but the machines have broken down because 
        /// Desert Island recently stopped receiving the parts they need to fix the machines.
        /// 
        /// You've already assumed it'll be your job to figure out why the parts stopped when she asks if you can help. You agree automatically.
        /// 
        /// Because the journey will take a few days, she offers to teach you the game of Camel Cards. 
        /// Camel Cards is sort of similar to poker except it's designed to be easier to play while riding a camel.
        /// 
        /// In Camel Cards, you get a list of hands, and your goal is to order them based on the strength of each hand. 
        /// A hand consists of five cards labeled one of A, K, Q, J, T, 9, 8, 7, 6, 5, 4, 3, or 2. 
        /// The relative strength of each card follows this order, where A is the highest and 2 is the lowest.
        /// 
        /// Every hand is exactly one type. From strongest to weakest, they are:
        /// 
        /// Five of a kind, where all five cards have the same label: AAAAA
        /// Four of a kind, where four cards have the same label and one card has a different label: AA8AA
        /// Full house, where three cards have the same label, and the remaining two cards share a different label: 23332
        /// Three of a kind, where three cards have the same label, and the remaining two cards are each different from any other card in the hand: TTT98
        /// Two pair, where two cards share one label, two other cards share a second label, and the remaining card has a third label: 23432
        /// One pair, where two cards share one label, and the other three cards have a different label from the pair and each other: A23A4
        /// High card, where all cards' labels are distinct: 23456
        /// Hands are primarily ordered based on type; for example, every full house is stronger than any three of a kind.
        /// 
        /// If two hands have the same type, a second ordering rule takes effect. Start by comparing the first card in each hand. 
        /// If these cards are different, the hand with the stronger first card is considered stronger. 
        /// If the first card in each hand have the same label, however, then move on to considering the second card in each hand. 
        /// If they differ, the hand with the higher second card wins; otherwise, continue with the third card in each hand, then the fourth, then the fifth.
        /// 
        /// So, 33332 and 2AAAA are both four of a kind hands, but 33332 is stronger because its first card is stronger. 
        /// Similarly, 77888 and 77788 are both a full house, but 77888 is stronger because its third card is stronger (and both hands have the same first and second card).
        /// 
        /// To play Camel Cards, you are given a list of hands and their corresponding bid(your puzzle input). For example:
        /// 
        /// 32T3K 765
        /// T55J5 684
        /// KK677 28
        /// KTJJT 220
        /// QQQJA 483
        /// This example shows five hands; each hand is followed by its bid amount.
        /// Each hand wins an amount equal to its bid multiplied by its rank, where the weakest hand gets rank 1, the second-weakest hand gets rank 2,
        /// and so on up to the strongest hand.Because there are five hands in this example, the strongest hand will have rank 5 and its bid will be multiplied by 5.
        /// 
        /// So, the first step is to put the hands in order of strength:
        /// 
        /// 32T3K is the only one pair and the other hands are all a stronger type, so it gets rank 1.
        /// KK677 and KTJJT are both two pair.Their first cards both have the same label, but the second card of KK677 is stronger(K vs T),
        /// so KTJJT gets rank 2 and KK677 gets rank 3.
        /// T55J5 and QQQJA are both three of a kind.QQQJA has a stronger first card, so it gets rank 5 and T55J5 gets rank 4.
        /// Now, you can determine the total winnings of this set of hands by adding up the result of multiplying each hand's bid with its 
        /// rank (765 * 1 + 220 * 2 + 28 * 3 + 684 * 4 + 483 * 5). So the total winnings in this example are 6440.
        /// 
        /// Find the rank of every hand in your set. What are the total winnings?
        /// </summary>
        [Benchmark]
        public long PartOne() => PartOne0(data!);

        private static long PartOne0(List<string> input)
        {
            int n = input.Count;
            int r = 0;

            List<(string, int, int)> max = [];
            foreach (string item in input)
            {
                string a = item.Split(" ")[0];
                int a0 = int.Parse(item.Split(" ")[1]);

                max.Add((a, RftTypePartOne(a), a0));
            }

            max = [.. max.OrderBy(o => o.Item2).ThenByDescending(o => o.Item1, new CustomSortPartOne())];

            for (int j = 0; j < max.Count; j++)
            {
                r += (max.Count - j) * max[j].Item3;
            }

            return r;
        }

        private class CustomSortPartOne : IComparer<string>
        {
            public int Compare(string? a, string? b)
            {
                Dictionary<char, int> cards = [];
                cards.Add('2', 0);
                cards.Add('3', 1);
                cards.Add('4', 2);
                cards.Add('5', 3);
                cards.Add('6', 4);
                cards.Add('7', 5);
                cards.Add('8', 6);
                cards.Add('9', 7);
                cards.Add('T', 8);
                cards.Add('J', 9);
                cards.Add('Q', 10);
                cards.Add('K', 11);
                cards.Add('A', 12);

                if (a == null) return b == null ? 0 : -1;

                if (b == null) return 1;

                int minLength = Math.Min(a.Length, b.Length);

                for (int i = 0; i < minLength; i++)
                {
                    int i1 = cards[a[i]];
                    int i2 = cards[b[i]];

                    if (i1 == -1) throw new Exception(a);
                    if (i2 == -1) throw new Exception(b);

                    int cmp = i1.CompareTo(i2);

                    if (cmp != 0) return cmp;
                }

                return a.Length.CompareTo(b.Length);
            }
        }

        private static int RftTypePartOne(string a)
        {
            Dictionary<char, int> kvp = [];
            bool five = false;
            bool four = false;
            bool full = false;
            bool two = false;
            bool three = false;
            bool one = false;
            bool high = false;

            foreach (char item in a)
            {
                if (kvp.TryGetValue(item, out int value)) kvp[item] = ++value;
                else kvp.Add(item, 1);
            }

            if (kvp.Count == 1) five = true;
            else if (kvp.Count == 2)
            {
                foreach (KeyValuePair<char, int> item in kvp)
                {
                    if (item.Value == 2) full = true;
                    if (item.Value == 1) four = true;
                }
            }
            else if (kvp.Count == 3)
            {
                foreach (KeyValuePair<char, int> item in kvp)
                {
                    if (item.Value == 2) two = true;
                    if (item.Value == 3) three = true;
                }
            }
            else if (kvp.Count == 4)
            {
                foreach (KeyValuePair<char, int> item in kvp)
                {
                    if (item.Value == 2) one = true;
                }
            }
            else high = true;

            if (five) return 0;
            if (four) return 1;
            if (full) return 2;
            if (three) return 3;
            if (two) return 4;
            if (one) return 5;
            if (high) return 6;

            return -1;
        }

        /// <summary>
        /// To make things a little more interesting, the Elf introduces one additional rule. 
        /// Now, J cards are jokers - wildcards that can act like whatever card would make the hand the strongest type possible.
        /// 
        /// To balance this, J cards are now the weakest individual cards, weaker even than 2. 
        /// The other cards stay in the same order: A, K, Q, T, 9, 8, 7, 6, 5, 4, 3, 2, J.
        /// 
        /// J cards can pretend to be whatever card is best for the purpose of determining hand type;
        /// for example, QJJQ2 is now considered four of a kind.
        /// However, for the purpose of breaking ties between two hands of the same type, J is always treated as J, 
        /// not the card it's pretending to be: JKKK2 is weaker than QQQQ2 because J is weaker than Q.
        /// 
        /// Now, the above example goes very differently:
        /// 
        /// 32T3K 765
        /// T55J5 684
        /// KK677 28
        /// KTJJT 220
        /// QQQJA 483
        /// 32T3K is still the only one pair; it doesn't contain any jokers, so its strength doesn't increase.
        /// KK677 is now the only two pair, making it the second-weakest hand.
        /// T55J5, KTJJT, and QQQJA are now all four of a kind! T55J5 gets rank 3, QQQJA gets rank 4, and KTJJT gets rank 5.
        /// With the new joker rule, the total winnings in this example are 5905.
        /// 
        /// Using the new joker rule, find the rank of every hand in your set.What are the new total winnings?
        /// </summary>        
        [Benchmark]
        public long PartTwo() => PartTwo0(data!);

        private static long PartTwo0(List<string> input)
        {
            int n = input.Count;
            int r = 0;

            List<(string, (int, string), int)> max = [];
            foreach (string item in input)
            {
                string a = item.Split(" ")[0];
                int a0 = int.Parse(item.Split(" ")[1]);

                max.Add((a, RftTypePartTwo(a), a0));
            }

            max = [.. max.OrderBy(o => o.Item2.Item1)];//.ThenByDescending(o => o.Item2.Item2, new CustomSortPartTwo()).ThenByDescending(o => o.Item1, new CustomSortPartTwo())];

            for (int j = 0; j < max.Count; j++)
            {
                //Console.WriteLine($"{max[j].Item1} {max[j].Item2.Item2} {max[j].Item2.Item1} {max[j].Item3}");
                r += (max.Count - j) * max[j].Item3;
            }

            return r;
        }

        private class CustomSortPartTwo : IComparer<string>
        {
            public int Compare(string? a, string? b)
            {
                Dictionary<char, int> cards = [];
                cards.Add('J', 0);
                cards.Add('2', 1);
                cards.Add('3', 2);
                cards.Add('4', 3);
                cards.Add('5', 4);
                cards.Add('6', 5);
                cards.Add('7', 6);
                cards.Add('8', 7);
                cards.Add('9', 8);
                cards.Add('T', 9);
                cards.Add('Q', 10);
                cards.Add('K', 11);
                cards.Add('A', 12);

                if (a == null) return b == null ? 0 : -1;

                if (b == null) return 1;

                int minLength = Math.Min(a.Length, b.Length);

                for (int i = 0; i < minLength; i++)
                {
                    int i1 = cards[a[i]];
                    int i2 = cards[b[i]];

                    if (i1 == -1) throw new Exception(a);
                    if (i2 == -1) throw new Exception(b);

                    int cmp = i1.CompareTo(i2);

                    if (cmp != 0) return cmp;
                }

                return a.Length.CompareTo(b.Length);
            }
        }

        private static (int, string) RftTypePartTwo(string a)
        {
            List<char> cards = [
                'A',
                'K',
                'T',
                'Q',
                '9',
                '8',
                '7',
                '6',
                '5',
                '4',
                '3',
                '2',
                'J'
            ];

            Dictionary<char, int> kvp = [];
            bool five = false;
            bool four = false;
            bool full = false;
            bool two = false;
            bool three = false;
            bool one = false;
            bool high = false;

            foreach (char item in a)
            {
                if (kvp.TryGetValue(item, out int value)) kvp[item] = ++value;
                else kvp.Add(item, 1);
            }

            if (kvp.TryGetValue('J', out int value0))
            {
                int c = value0;
                if (c == 5) return (0, "AAAAA");

                int t = kvp.MaxBy(o => o.Value).Value;
                List<KeyValuePair<char, int>> y = [.. kvp.Where(o => o.Value == t)];

                if (y.Count != 0)
                {
                    y = [.. y.OrderByDescending(o => o.Value).ThenByDescending(o => o.Key.ToString(), new CustomSortPartTwo())];
                    foreach (KeyValuePair<char, int> item in y)
                    {
                        if (item.Key != 'J' && kvp.ContainsKey(item.Key))
                        {
                            kvp[item.Key] += kvp['J'];
                            kvp.Remove('J');
                            a = a.Replace('J', item.Key);
                            break;
                        }
                    }
                }
            }

            if (kvp.Count == 1) five = true;
            else if (kvp.Count == 2)
            {
                foreach (KeyValuePair<char, int> item in kvp)
                {
                    if (item.Value == 2) full = true;
                    if (item.Value == 1) four = true;
                }
            }
            else if (kvp.Count == 3)
            {
                foreach (KeyValuePair<char, int> item in kvp)
                {
                    if (item.Value == 2) two = true;
                    if (item.Value == 3) three = true;
                }
            }
            else if (kvp.Count == 4)
            {
                foreach (KeyValuePair<char, int> item in kvp)
                {
                    if (item.Value == 2) one = true;
                }
            }
            else high = true;

            if (five) return (0, a);
            if (four) return (1, a);
            if (full) return (2, a);
            if (three) return (3, a);
            if (two) return (4, a);
            if (one) return (5, a);
            if (high) return (6, a);

            return (-1, a);
        }

        #region Game 1
        public const string CARDRANKS = "23456789TJQKA";

        public enum HandType
        {
            HighCard = 0,
            Pair = 1,
            TwoPair = 2,
            ThreeOfAKind = 3,
            FullHouse = 4,
            FourOfAKind = 5,
            FiveOfAKind = 6
        }

        private record Game(string Hand, int Score, int Bet, int Occurring0, int Occurring1) : IComparable<Game>
        {
            public HandType Type =>
                Occurring0 switch
                {
                    5 => HandType.FiveOfAKind,
                    4 => HandType.FourOfAKind,
                    3 => Occurring1 == 2 ? HandType.FullHouse : HandType.ThreeOfAKind,
                    2 => Occurring1 == 2 ? HandType.TwoPair : HandType.Pair,
                    _ => HandType.HighCard,
                };
            public int CompareTo(Game? other) => Type == other!.Type ? Score.CompareTo(other.Score) : Type.CompareTo(other.Type);
        }

        private static List<Game> ParseGames(string input, bool jokers = false)
        {
            return input.Trim().Split("\n").Select(line =>
            {
                string[] parts = line.Split(" ");
                int bet = int.Parse(parts[1]);
                string hand = parts[0];

                if (jokers)
                {
                    Dictionary<char, int> occuring = hand.GroupBy(c => c).ToDictionary(group => group.Key, group => group.Count());
                    int score = hand.Aggregate(0, (acc, c) => (acc << 4) + (c == 'J' ? 0 : CARDRANKS.IndexOf(c) + 1));
                    int jokerCount = 0;
                    if (occuring.TryGetValue('J', out int value))
                    {
                        jokerCount = value;
                        occuring.Remove('J');
                    }

                    // JJJJJ
                    if (occuring.Count == 0) return new Game(hand, score, bet, 5, 0);

                    int maxCount = occuring.Values.Max();
                    char maxCountKey = occuring.FirstOrDefault(x => x.Value == maxCount).Key;

                    if (jokerCount > 0)
                    {
                        occuring[maxCountKey] += jokerCount;
                        maxCount = occuring[maxCountKey];
                    }

                    int occuring1 = occuring.Count > 1 ? occuring.OrderByDescending(x => x.Value).Skip(1).First().Value : 0;

                    return new Game(hand, score, bet, maxCount, occuring1);
                }
                else
                {
                    int score = hand.Aggregate(0, (acc, c) => (acc << 4) + CARDRANKS.IndexOf(c));
                    List<int> occuring = [.. hand.GroupBy(c => c).Select(group => group.Count()).OrderByDescending(count => count)];
                    int occuring1 = occuring.Count > 1 ? occuring[1] : 0;

                    return new Game(hand, score, bet, occuring[0], occuring1);
                }
            }).ToList();
        }

        private static int PartOne(string input) => ParseGames(input).Order().Select((game, index) => (index + 1) * game.Bet).Sum();

        private static int PartTwo(string input) => ParseGames(input, true).Order().Select((game, index) => (index + 1) * game.Bet).Sum();
        #endregion

        #region Game 2
        private const int FiveOfAKind = 6, FourOfAKind = 5, FullHouse = 4, ThreeOfAKind = 3, TwoPairs = 2, Pair = 1, HighCard = 0;

        private static long Run(List<string> inputLines)
        {
            (string hand, int bid)[] hands = inputLines
                .Select(l => l.Split())
                .Select(a => (hand: a[0], bid: int.Parse(a[1])))
                .ToArray();
            //Console.WriteLine(Test(hands, HandStrength1, 11));
            //Console.WriteLine(Test(hands, HandStrength2, 0));
            return Test(hands, HandStrength2, 0);
        }

        private static int Test((string hand, int bid)[] hands, Func<string, int> handStrength, int jokerStrength) => hands
            .OrderBy(h => handStrength(h.hand))
            .ThenBy(h => h.hand.Aggregate(0, (score, card) => score * 15 + CardStrength(card, jokerStrength)))
            .Select((h, rankMinusOne) => h.bid * (rankMinusOne + 1))
            .Sum();

        private static int HandStrengthIgnoringJokers(string hand, out int jokerCount)
        {
            Dictionary<char, int> counts = hand.GroupBy(card => card).ToDictionary(group => group.Key, group => group.Count());
            counts.TryGetValue('J', out jokerCount);
            return counts.Count switch
            {
                1 => FiveOfAKind,
                2 => counts.Values.Any(count => count == 4) ? FourOfAKind : FullHouse,
                3 => counts.Values.Any(count => count == 2) ? TwoPairs : ThreeOfAKind,
                4 => Pair,
                _ => HighCard
            };
        }

        private static int HandStrength1(string hand) => HandStrengthIgnoringJokers(hand, out int _);

        private static int HandStrength2(string hand)
        {
            return (HandStrengthIgnoringJokers(hand, out int jokerCount), jokerCount) switch
            {
                (var handStrengthIgnoringJokers, 0) => handStrengthIgnoringJokers,
                (HighCard, 1) => Pair,
                (Pair, _) => ThreeOfAKind,
                (TwoPairs, 1) => FullHouse,
                (TwoPairs, 2) => FourOfAKind,
                (ThreeOfAKind, _) => FourOfAKind,
                (FullHouse, 1) => FourOfAKind,
                (FullHouse, _) => FiveOfAKind,
                (FourOfAKind, _) => FiveOfAKind,
                (var handStrengthIgnoringJokers, _) => handStrengthIgnoringJokers
            };
        }

        private static int CardStrength(char card, int jokerStrength) => card switch
        {
            'A' => 14,
            'K' => 13,
            'Q' => 12,
            'J' => jokerStrength,
            'T' => 10,
            _ => card - '0'
        };
        #endregion
        #endregion

        #region UnitTest
        public static long PartOne_Test(List<string> data) => PartOne0(data);

        public static long PartTwo_Test(List<string> data) => PartTwo0(data);
        #endregion

        #region Host
        private readonly IRftAdventOfCodeHostData? RftAdventOfCodeHostData;

        public _07_CamelCards(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_07_CamelCards));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}