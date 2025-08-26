using System.Text;

namespace Rftim3CodinGame.Refactor.Puzzles
{
    public class ACoinGuessingGame
    {
        public ACoinGuessingGame()
        {
            int n = 2;
            List<Throw> throws = new()
            {
                new Throw(new List<int> { 4, 2 }),
                new Throw(new List<int> { 2, 4 }),
                new Throw(new List<int> { 4, 3 })
            };

            Solve(n, throws);
        }

        private static void Solve(int n, List<Throw> throws)
        {
            int sides = n * 2;
            List<int> odds = new();
            List<int> evens = new();
            List<Coin> coins = new();
            Dictionary<int, int> kvp = new();

            for (int i = 1; i <= sides; i++)
            {
                if (i % 2 == 0) evens.Add(i);
                else
                {
                    odds.Add(i);
                    coins.Add(new Coin(i, new List<int>()));
                }
            }

            foreach (Coin coin in coins)
            {
                coin.coins.AddRange(evens);
            }

            foreach (Throw @throw in throws)
            {
                foreach (Coin coin in coins)
                {
                    if (@throw.throws.Contains(coin.id))
                    {
                        foreach (int item in @throw.throws)
                        {
                            coin.coins.Remove(item);
                        }
                    }
                }
            }

            while (coins.Count > 0)
            {
                int flag = 0;

                for (int i = 0; i < coins.Count; i++)
                {
                    if (coins[i].coins.Count == 1)
                    {
                        kvp.Add(coins[i].id, coins[i].coins[0]);
                        flag = coins[i].coins[0];
                        i = coins.Count;
                    }
                }

                foreach (Coin coin2 in coins)
                {
                    if (coin2.coins.Contains(flag)) coin2.coins.Remove(flag);
                }

                coins.RemoveAll(o => o.coins.Count == 0);
            }

            StringBuilder sb = new();

            foreach (KeyValuePair<int, int> item in kvp.OrderBy(o => o.Key))
            {
                sb.Append($"{item.Value} ");
            }

            Console.WriteLine($"{sb.ToString().TrimEnd()}");
        }

        class Coin
        {
            public int id;
            public List<int> coins;

            public Coin(int id, List<int> coins)
            {
                this.id = id;
                this.coins = coins;
            }
        }

        class Throw
        {
            public List<int> throws;

            public Throw(List<int> throws)
            {
                this.throws = throws;
            }
        }
    }
}
