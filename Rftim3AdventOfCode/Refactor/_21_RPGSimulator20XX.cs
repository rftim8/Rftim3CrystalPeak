using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;

namespace Rftim3AdventOfCode.Refactor
{
    public class _21_RPGSimulator20XX : I_21_RPGSimulator20XX
    {
        #region Static
        private readonly List<string>? data;

        public _21_RPGSimulator20XX()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_21_RPGSimulator20XX));
        }

        /// <summary>
        /// Little Henry Case got a new video game for Christmas. It's an RPG, and he's stuck on a boss. He needs to know what equipment to buy at the shop.
        /// He hands you the controller.
        /// 
        /// In this game, the player (you) and the enemy (the boss) take turns attacking. The player always goes first.
        /// Each attack reduces the opponent's hit points by at least 1. The first character at or below 0 hit points loses.
        /// 
        /// Damage dealt by an attacker each turn is equal to the attacker's damage score minus the defender's armor score.
        /// An attacker always does at least 1 damage.So, if the attacker has a damage score of 8, and the defender has an armor score of 3, the defender loses 5 hit points. 
        /// If the defender had an armor score of 300, the defender would still lose 1 hit point.
        /// 
        /// Your damage score and armor score both start at zero. They can be increased by buying items in exchange for gold.
        /// You start with no items and have as much gold as you need. Your total damage or armor is equal to the sum of those stats from all of your items. You have 100 hit points.
        /// 
        /// Here is what the item shop is selling:
        /// 
        /// Weapons:    Cost Damage  Armor
        /// Dagger        8     4       0
        /// Shortsword   10     5       0
        /// Warhammer    25     6       0
        /// Longsword    40     7       0
        /// Greataxe     74     8       0
        /// 
        /// 
        /// Armor:      Cost Damage  Armor
        /// Leather      13     0       1
        /// Chainmail    31     0       2
        /// Splintmail   53     0       3
        /// Bandedmail   75     0       4
        /// Platemail   102     0       5
        /// 
        /// 
        /// Rings:      Cost Damage  Armor
        /// Damage +1    25     1       0
        /// Damage +2    50     2       0
        /// Damage +3   100     3       0
        /// Defense +1   20     0       1
        /// Defense +2   40     0       2
        /// Defense +3   80     0       3
        /// You must buy exactly one weapon; no dual-wielding. Armor is optional, but you can't use more than one. You can buy 0-2 rings (at most one for each hand). 
        /// You must use any items you buy. The shop only has one of each item, so you can't buy, for example, two rings of Damage +3.
        /// 
        /// For example, suppose you have 8 hit points, 5 damage, and 5 armor, and that the boss has 12 hit points, 7 damage, and 2 armor:
        /// 
        /// The player deals 5-2 = 3 damage; the boss goes down to 9 hit points.
        /// The boss deals 7-5 = 2 damage; the player goes down to 6 hit points.
        /// The player deals 5-2 = 3 damage; the boss goes down to 6 hit points.
        /// The boss deals 7-5 = 2 damage; the player goes down to 4 hit points.
        /// The player deals 5-2 = 3 damage; the boss goes down to 3 hit points.
        /// The boss deals 7-5 = 2 damage; the player goes down to 2 hit points.
        /// The player deals 5-2 = 3 damage; the boss goes down to 0 hit points.
        /// In this scenario, the player wins! (Barely.)
        /// 
        /// You have 100 hit points.The boss's actual stats are in your puzzle input. What is the least amount of gold you can spend and still win the fight?
        /// </summary>
        [Benchmark]
        public int PartOne() => PartOne0(data!);

        private static int PartOne0(List<string> input)
        {
            int playerHp = 100;
            int bossHp = int.Parse(input[0].Split(':')[1].Trim());
            int bossAttack = int.Parse(input[1].Split(':')[1].Trim());
            int bossDefence = int.Parse(input[2].Split(':')[1].Trim());

            var weapons = new[]
            {
                new { Cost = 8, Attack = 4 },
                new { Cost = 10, Attack = 5 },
                new { Cost = 25, Attack = 6 },
                new { Cost = 40, Attack = 7 },
                new { Cost = 74, Attack = 8 },
            };

            var armour = new[]
            {
                new { Cost = 0, Armour = 0 },
                new { Cost = 13, Armour = 1 },
                new { Cost = 31, Armour = 2 },
                new { Cost = 53, Armour = 3 },
                new { Cost = 75, Armour = 4 },
                new { Cost = 102, Armour = 5 },
            };

            var rings = new[]
            {
                new { Cost = 0, Attack = 0, Armour = 0 },
                new { Cost = 25, Attack = 1, Armour = 0 },
                new { Cost = 50, Attack = 2, Armour = 0 },
                new { Cost = 100, Attack = 3, Armour = 0 },
                new { Cost = 20, Attack = 0, Armour = 1 },
                new { Cost = 40, Attack = 0, Armour = 2 },
                new { Cost = 80, Attack = 0, Armour = 3 },
            };

            bool isPlayerAlive(int playerAttack, int playerArmour)
            {
                int turnsToKillBoss = (int)Math.Ceiling(bossHp / (double)(playerAttack - bossDefence));
                return playerHp - (bossAttack - playerArmour) * (turnsToKillBoss - 1) > 0;
            }

            var combinations =
                from w in weapons
                from a in armour
                from ring1 in rings
                from ring2 in rings
                where ring1.Cost == 0 || ring1.Cost != ring2.Cost
                select new
                {
                    Attack = w.Attack + ring1.Attack + ring2.Attack,
                    Defence = a.Armour + ring1.Armour + ring2.Armour,
                    Cost = w.Cost + a.Cost + ring1.Cost + ring2.Cost
                };

            return (from c in combinations where isPlayerAlive(c.Attack, c.Defence) select c.Cost).Min();
        }

        /// <summary>
        /// Turns out the shopkeeper is working with the boss, and can persuade you to buy whatever items he wants. 
        /// The other rules still apply, and he still only has one of each item.
        /// What is the most amount of gold you can spend and still lose the fight?
        /// </summary>        
        [Benchmark]
        public int PartTwo() => PartTwo0(data!);

        private static int PartTwo0(List<string> input)
        {
            int playerHp = 100;
            int bossHp = int.Parse(input[0].Split(':')[1].Trim());
            int bossAttack = int.Parse(input[1].Split(':')[1].Trim());
            int bossDefence = int.Parse(input[2].Split(':')[1].Trim());

            var weapons = new[]
            {
                new { Cost = 8, Attack = 4 },
                new { Cost = 10, Attack = 5 },
                new { Cost = 25, Attack = 6 },
                new { Cost = 40, Attack = 7 },
                new { Cost = 74, Attack = 8 },
            };

            var armour = new[]
            {
                new { Cost = 0, Armour = 0 },
                new { Cost = 13, Armour = 1 },
                new { Cost = 31, Armour = 2 },
                new { Cost = 53, Armour = 3 },
                new { Cost = 75, Armour = 4 },
                new { Cost = 102, Armour = 5 },
            };

            var rings = new[]
            {
                new { Cost = 0, Attack = 0, Armour = 0 },
                new { Cost = 25, Attack = 1, Armour = 0 },
                new { Cost = 50, Attack = 2, Armour = 0 },
                new { Cost = 100, Attack = 3, Armour = 0 },
                new { Cost = 20, Attack = 0, Armour = 1 },
                new { Cost = 40, Attack = 0, Armour = 2 },
                new { Cost = 80, Attack = 0, Armour = 3 },
            };

            bool isPlayerAlive(int playerAttack, int playerArmour)
            {
                int turnsToKillBoss = (int)Math.Ceiling(bossHp / (double)(playerAttack - bossDefence));
                return playerHp - (bossAttack - playerArmour) * (turnsToKillBoss - 1) > 0;
            }

            var combinations =
                from w in weapons
                from a in armour
                from ring1 in rings
                from ring2 in rings
                where ring1.Cost == 0 || ring1.Cost != ring2.Cost
                select new
                {
                    Attack = w.Attack + ring1.Attack + ring2.Attack,
                    Defence = a.Armour + ring1.Armour + ring2.Armour,
                    Cost = w.Cost + a.Cost + ring1.Cost + ring2.Cost
                };

            return (from c in combinations where !isPlayerAlive(c.Attack, c.Defence) select c.Cost).Max();
        }
        #endregion

        #region UnitTest
        public static int PartOne_Test(List<string> data) => PartOne0(data);

        public static int PartTwo_Test(List<string> data) => PartTwo0(data);
        #endregion

        #region Host
        private readonly IRftAdventOfCodeHostData? RftAdventOfCodeHostData;

        public _21_RPGSimulator20XX(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_21_RPGSimulator20XX));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}