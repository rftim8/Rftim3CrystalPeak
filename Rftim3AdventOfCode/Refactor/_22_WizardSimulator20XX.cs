using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;

namespace Rftim3AdventOfCode.Refactor
{
    public class _22_WizardSimulator20XX : I_22_WizardSimulator20XX
    {
        #region Static
        private readonly List<string>? data;

        public _22_WizardSimulator20XX()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_22_WizardSimulator20XX));
        }

        /// <summary>
        /// Little Henry Case decides that defeating bosses with swords and stuff is boring. Now he's playing the game with a wizard.
        /// Of course, he gets stuck on another boss and needs your help again.
        /// 
        /// In this version, combat still proceeds with the player and the boss taking alternating turns. The player still goes first.
        /// Now, however, you don't get any equipment; instead, you must choose one of your spells to cast. The first character at or below 0 hit points loses.
        /// 
        /// Since you're a wizard, you don't get to wear armor, and you can't attack normally.
        /// However, since you do magic damage, your opponent's armor is ignored, and so the boss effectively has zero armor as well.
        /// As before, if armor (from a spell, in this case) would reduce damage below 1, it becomes 1 instead - that is, the boss' attacks always deal at least 1 damage.
        /// 
        /// On each of your turns, you must select one of your spells to cast. If you cannot afford to cast any spell, you lose. 
        /// Spells cost mana; you start with 500 mana, but have no maximum limit. You must have enough mana to cast a spell, and its cost is immediately deducted when you cast it. 
        /// Your spells are Magic Missile, Drain, Shield, Poison, and Recharge.
        /// 
        /// Magic Missile costs 53 mana. It instantly does 4 damage.
        /// Drain costs 73 mana. It instantly does 2 damage and heals you for 2 hit points.
        /// Shield costs 113 mana. It starts an effect that lasts for 6 turns. While it is active, your armor is increased by 7.
        /// Poison costs 173 mana. It starts an effect that lasts for 6 turns. At the start of each turn while it is active, it deals the boss 3 damage.
        /// Recharge costs 229 mana. It starts an effect that lasts for 5 turns. At the start of each turn while it is active, it gives you 101 new mana.
        /// Effects all work the same way.Effects apply at the start of both the player's turns and the boss' turns.
        /// Effects are created with a timer (the number of turns they last); at the start of each turn, after they apply any effect they have, their timer is decreased by one.
        /// If this decreases the timer to zero, the effect ends.You cannot cast a spell that would start an effect which is already active.
        /// However, effects can be started on the same turn they end.
        /// 
        /// For example, suppose the player has 10 hit points and 250 mana, and that the boss has 13 hit points and 8 damage:
        /// 
        /// -- Player turn --
        /// - Player has 10 hit points, 0 armor, 250 mana
        /// - Boss has 13 hit points
        /// Player casts Poison.
        /// 
        /// -- Boss turn --
        /// - Player has 10 hit points, 0 armor, 77 mana
        /// - Boss has 13 hit points
        /// Poison deals 3 damage; its timer is now 5.
        /// Boss attacks for 8 damage.
        /// 
        /// -- Player turn --
        /// - Player has 2 hit points, 0 armor, 77 mana
        /// - Boss has 10 hit points
        /// Poison deals 3 damage; its timer is now 4.
        /// Player casts Magic Missile, dealing 4 damage.
        /// 
        /// -- Boss turn --
        /// - Player has 2 hit points, 0 armor, 24 mana
        /// - Boss has 3 hit points
        /// Poison deals 3 damage. This kills the boss, and the player wins.
        /// Now, suppose the same initial conditions, except that the boss has 14 hit points instead:
        /// 
        /// -- Player turn --
        /// - Player has 10 hit points, 0 armor, 250 mana
        /// - Boss has 14 hit points
        /// Player casts Recharge.
        /// 
        /// -- Boss turn --
        /// - Player has 10 hit points, 0 armor, 21 mana
        /// - Boss has 14 hit points
        /// Recharge provides 101 mana; its timer is now 4.
        /// Boss attacks for 8 damage!
        /// 
        /// -- Player turn --
        /// - Player has 2 hit points, 0 armor, 122 mana
        /// - Boss has 14 hit points
        /// Recharge provides 101 mana; its timer is now 3.
        /// Player casts Shield, increasing armor by 7.
        /// 
        /// -- Boss turn --
        /// - Player has 2 hit points, 7 armor, 110 mana
        /// - Boss has 14 hit points
        /// Shield's timer is now 5.
        /// Recharge provides 101 mana; its timer is now 2.
        /// Boss attacks for 8 - 7 = 1 damage!
        /// 
        /// -- Player turn --
        /// - Player has 1 hit point, 7 armor, 211 mana
        /// - Boss has 14 hit points
        /// Shield's timer is now 4.
        /// Recharge provides 101 mana; its timer is now 1.
        /// Player casts Drain, dealing 2 damage, and healing 2 hit points.
        /// 
        /// -- Boss turn --
        /// - Player has 3 hit points, 7 armor, 239 mana
        /// - Boss has 12 hit points
        /// Shield's timer is now 3.
        /// Recharge provides 101 mana; its timer is now 0.
        /// Recharge wears off.
        /// Boss attacks for 8 - 7 = 1 damage!
        /// 
        /// -- Player turn --
        /// - Player has 2 hit points, 7 armor, 340 mana
        /// - Boss has 12 hit points
        /// Shield's timer is now 2.
        /// Player casts Poison.
        /// 
        /// -- Boss turn --
        /// - Player has 2 hit points, 7 armor, 167 mana
        /// - Boss has 12 hit points
        /// Shield's timer is now 1.
        /// Poison deals 3 damage; its timer is now 5.
        /// Boss attacks for 8 - 7 = 1 damage!
        /// 
        /// -- Player turn --
        /// - Player has 1 hit point, 7 armor, 167 mana
        /// - Boss has 9 hit points
        /// Shield's timer is now 0.
        /// Shield wears off, decreasing armor by 7.
        /// Poison deals 3 damage; its timer is now 4.
        /// Player casts Magic Missile, dealing 4 damage.
        /// 
        /// -- Boss turn --
        /// - Player has 1 hit point, 0 armor, 114 mana
        /// - Boss has 2 hit points
        /// Poison deals 3 damage. This kills the boss, and the player wins.
        /// You start with 50 hit points and 500 mana points. The boss's actual stats are in your puzzle input. 
        /// What is the least amount of mana you can spend and still win the fight? (Do not include mana recharge effects as "spending" negative mana.)
        /// </summary>
        [Benchmark]
        public int PartOne() => PartOne0(data!);

        private static int PartOne0(List<string> input)
        {
            Player player = new()
            {
                Life = 50,
                Mana = 500
            };
            Boss boss = new()
            {
                Life = int.Parse(input[0].Split(':')[1]),
                Damage = int.Parse(input[1].Split(':')[1])
            };

            int leastMana = int.MaxValue;
            for (int spell = 0; spell < 5; spell++)
            {
                Turn(player, boss, spell, ref leastMana);
            }

            return leastMana;
        }

        /// <summary>
        /// On the next run through the game, you increase the difficulty to hard.
        /// 
        /// At the start of each player turn(before any other effects apply), you lose 1 hit point.If this brings you to or below 0 hit points, you lose.
        /// 
        /// With the same starting stats for you and the boss, what is the least amount of mana you can spend and still win the fight?
        /// </summary>        
        [Benchmark]
        public int PartTwo() => PartTwo0(data!);

        private static int PartTwo0(List<string> input)
        {
            Player player = new()
            {
                Life = 50,
                Mana = 500
            };
            Boss boss = new()
            {
                Life = int.Parse(input[0].Split(':')[1]),
                Damage = int.Parse(input[1].Split(':')[1])
            };

            int leastMana = int.MaxValue;
            for (int spell = 0; spell < 5; spell++)
            {
                Turn(player, boss, spell, ref leastMana, hardMode: true);
            }

            return leastMana;
        }

        private struct Player
        {
            public int Life;
            public int Mana;
            public int Shield;
            public int Recharge;
        }

        private struct Boss
        {
            public int Life;
            public int Damage;
            public int Poison;
        }

        private static readonly int[] manaCosts = [53, 73, 113, 173, 229];
        private static readonly Random rnd = new();

        private static void Turn(Player player, Boss boss, int spell, ref int leastManaWin, bool playerTurn = true, int manaSpent = 0, bool hardMode = false)
        {
            if (playerTurn && hardMode)
            {
                player.Life--;
                if (player.Life <= 0) return;
            }

            if (player.Shield > 0) player.Shield--;
            if (player.Recharge > 0)
            {
                player.Mana += 101;
                player.Recharge--;
            }
            if (boss.Poison > 0)
            {
                boss.Life -= 3;
                boss.Poison--;
                if (boss.Life <= 0)
                {
                    leastManaWin = Math.Min(leastManaWin, manaSpent);
                    return;
                }
            }

            if (playerTurn)
            {
                if (player.Mana >= manaCosts[spell])
                {
                    manaSpent += manaCosts[spell];
                    player.Mana -= manaCosts[spell];
                    switch (spell)
                    {
                        case 0:
                            boss.Life -= 4;
                            break;
                        case 1:
                            boss.Life -= 2;
                            player.Life += 2;
                            break;
                        case 2:
                            if (player.Shield > 0) return;
                            player.Shield = 6;
                            break;
                        case 3:
                            if (boss.Poison > 0) return;
                            boss.Poison = 6;
                            break;
                        case 4:
                            if (player.Recharge > 0) return;
                            player.Recharge = 5;
                            break;
                    }
                }
                else return;
            }
            else player.Life -= Math.Max(1, player.Shield > 0 ? boss.Damage - 7 : boss.Damage);

            if (boss.Life <= 0)
            {
                leastManaWin = Math.Min(leastManaWin, manaSpent);
                return;
            }
            if (player.Life <= 0) return;
            if (manaSpent >= leastManaWin) return;

            int[] spells = [0, 1, 2, 3, 4];

            _ = spells.OrderBy(x => rnd.Next());
            if (playerTurn) Turn(player, boss, 0, ref leastManaWin, false, manaSpent, hardMode);
            else
            {
                foreach (int i in spells)
                {
                    Turn(player, boss, i, ref leastManaWin, true, manaSpent, hardMode);
                }
            }
        }
        #endregion

        #region UnitTest
        public static int PartOne_Test(List<string> data) => PartOne0(data);

        public static int PartTwo_Test(List<string> data) => PartTwo0(data);
        #endregion

        #region Host
        private readonly IRftAdventOfCodeHostData? RftAdventOfCodeHostData;

        public _22_WizardSimulator20XX(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_22_WizardSimulator20XX));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}