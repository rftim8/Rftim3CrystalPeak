using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;

namespace Rftim3AdventOfCode.Refactor
{
    public class _23_Amphipod : I_23_Amphipod
    {
        #region Static
        private readonly List<string>? data;

        public _23_Amphipod()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_23_Amphipod));
        }

        /// <summary>
        /// A group of amphipods notice your fancy submarine and flag you down. "With such an impressive shell," one amphipod says,
        /// "surely you can help us with a question that has stumped our best scientists."
        /// 
        /// They go on to explain that a group of timid, stubborn amphipods live in a nearby burrow.
        /// Four types of amphipods live there: Amber(A), Bronze(B), Copper(C), and Desert(D). 
        /// They live in a burrow that consists of a hallway and four side rooms.The side rooms are initially full of amphipods, and the hallway is initially empty.
        /// 
        /// They give you a diagram of the situation (your puzzle input), including locations of each amphipod(A, B, C, or D, each of which is occupying an otherwise open space), 
        /// walls(#), and open space (.).
        /// 
        /// For example:
        /// 
        /// #############
        /// #...........#
        /// ###B#C#B#D###
        /// # A#D#C#A#
        /// #########
        /// The amphipods would like a method to organize every amphipod into side rooms so that each side room contains one type of amphipod 
        /// and the types are sorted A-D going left to right, like this:
        /// 
        /// #############
        /// #...........#
        /// ###A#B#C#D###
        /// # A#B#C#D#
        /// #########
        /// Amphipods can move up, down, left, or right so long as they are moving into an unoccupied open space.
        /// Each type of amphipod requires a different amount of energy to move one step: Amber amphipods require 1 energy per step, 
        /// Bronze amphipods require 10 energy, Copper amphipods require 100, and Desert ones require 1000. 
        /// The amphipods would like you to find a way to organize the amphipods that requires the least total energy.
        /// However, because they are timid and stubborn, the amphipods have some extra rules:
        ///
        ///
        /// Amphipods will never stop on the space immediately outside any room.They can move into that space so long as they immediately continue moving.
        /// (Specifically, this refers to the four open spaces in the hallway that are directly above an amphipod starting position.)
        /// Amphipods will never move from the hallway into a room unless that room is their destination room and that room contains no amphipods which do not
        /// also have that room as their own destination.If an amphipod's starting room is not its destination room, it can stay in that room until it leaves the room.
        /// (For example, an Amber amphipod will not move from the hallway into the right three rooms, and will only move into the leftmost room if that room 
        /// is empty or if it only contains other Amber amphipods.)
        /// Once an amphipod stops moving in the hallway, it will stay in that spot until it can move into a room.
        /// (That is, once any amphipod starts moving, any other amphipods currently in the hallway are locked in place and will not move again 
        /// until they can move fully into a room.)
        /// In the above example, the amphipods can be organized using a minimum of 12521 energy.One way to do this is shown below.
        /// 
        /// Starting configuration:
        /// 
        /// #############
        /// #...........#
        /// ###B#C#B#D###
        /// # A#D#C#A#
        /// #########
        /// One Bronze amphipod moves into the hallway, taking 4 steps and using 40 energy:
        /// 
        /// #############
        /// #...B.......#
        /// ###B#C#.#D###
        ///   #A#D#C#A#
        ///   #########
        /// The only Copper amphipod not in its side room moves there, taking 4 steps and using 400 energy:
        /// 
        /// #############
        /// #...B.......#
        /// ###B#.#C#D###
        ///   #A#D#C#A#
        ///   #########
        /// A Desert amphipod moves out of the way, taking 3 steps and using 3000 energy, and then the Bronze amphipod takes its place, taking 3 steps and using 30 energy:
        /// 
        /// #############
        /// #.....D.....#
        /// ###B#.#C#D###
        ///   #A#B#C#A#
        ///   #########
        /// The leftmost Bronze amphipod moves to its room using 40 energy:
        /// 
        /// #############
        /// #.....D.....#
        /// ###.#B#C#D###
        ///   #A#B#C#A#
        ///   #########
        /// Both amphipods in the rightmost room move into the hallway, using 2003 energy in total:
        /// 
        /// #############
        /// #.....D.D.A.#
        /// ###.#B#C#.###
        ///   #A#B#C#.#
        ///   #########
        /// Both Desert amphipods move into the rightmost room using 7000 energy:
        /// 
        /// #############
        /// #.........A.#
        /// ###.#B#C#D###
        ///   #A#B#C#D#
        ///   #########
        /// Finally, the last Amber amphipod moves into its room, using 8 energy:
        /// 
        /// #############
        /// #...........#
        /// ###A#B#C#D###
        ///   #A#B#C#D#
        ///   #########
        /// What is the least energy required to organize the amphipods?
        /// </summary>
        [Benchmark]
        public int PartOne() => PartOne0(data!);

        private static int PartOne0(List<string> input0)
        {
            string input = string.Concat(input0);
            char[] initialWorld = input.Where(c => c is '.' or >= 'A' and <= 'D').ToArray();
            int hallwaySize = initialWorld.Where(c => c == '.').Count();

            int[] cost = [1, 10, 100, 1000];
            int[] directions = [-1, 1];

            return Organize(new GameState(initialWorld, 0), hallwaySize, cost, directions);
        }

        /// <summary>
        /// As you prepare to give the amphipods your solution, you notice that the diagram they handed you was actually folded up.
        /// As you unfold it, you discover an extra part of the diagram.
        /// 
        /// Between the first and second lines of text that contain amphipod starting positions, insert the following lines:
        /// 
        ///   # D#C#B#A#
        /// # D#B#A#C#
        /// So, the above example now becomes:
        /// 
        /// #############
        /// #...........#
        /// ###B#C#B#D###
        ///   #D#C#B#A#
        ///   #D#B#A#C#
        ///   #A#D#C#A#
        ///   #########
        /// The amphipods still want to be organized into rooms similar to before:
        /// 
        /// #############
        /// #...........#
        /// ###A#B#C#D###
        /// # A#B#C#D#
        /// # A#B#C#D#
        /// # A#B#C#D#
        /// #########
        /// In this updated example, the least energy required to organize these amphipods is 44169:
        /// 
        /// #############
        /// #...........#
        /// ###B#C#B#D###
        /// # D#C#B#A#
        /// # D#B#A#C#
        /// # A#D#C#A#
        /// #########
        /// 
        /// #############
        /// #..........D#
        /// ###B#C#B#.###
        /// # D#C#B#A#
        /// # D#B#A#C#
        /// # A#D#C#A#
        /// #########
        /// 
        /// #############
        /// # A.........D#
        /// ###B#C#B#.###
        /// # D#C#B#.#
        /// # D#B#A#C#
        /// # A#D#C#A#
        /// #########
        /// 
        /// #############
        /// # A........BD#
        /// ###B#C#.#.###
        /// # D#C#B#.#
        /// # D#B#A#C#
        /// # A#D#C#A#
        /// #########
        /// 
        /// #############
        /// # A......B.BD#
        /// ###B#C#.#.###
        /// # D#C#.#.#
        /// # D#B#A#C#
        /// # A#D#C#A#
        /// #########
        /// 
        /// #############
        /// # AA.....B.BD#
        /// ###B#C#.#.###
        /// # D#C#.#.#
        /// # D#B#.#C#
        /// # A#D#C#A#
        /// #########
        /// 
        /// #############
        /// # AA.....B.BD#
        /// ###B#.#.#.###
        /// # D#C#.#.#
        /// # D#B#C#C#
        /// # A#D#C#A#
        /// #########
        /// 
        /// #############
        /// # AA.....B.BD#
        /// ###B#.#.#.###
        /// # D#.#C#.#
        /// # D#B#C#C#
        /// # A#D#C#A#
        /// #########
        /// 
        /// #############
        /// # AA...B.B.BD#
        /// ###B#.#.#.###
        /// # D#.#C#.#
        /// # D#.#C#C#
        /// # A#D#C#A#
        /// #########
        /// 
        /// #############
        /// # AA.D.B.B.BD#
        /// ###B#.#.#.###
        /// # D#.#C#.#
        /// # D#.#C#C#
        /// # A#.#C#A#
        /// #########
        /// 
        /// #############
        /// # AA.D...B.BD#
        /// ###B#.#.#.###
        /// # D#.#C#.#
        /// # D#.#C#C#
        /// # A#B#C#A#
        /// #########
        /// 
        /// #############
        /// # AA.D.....BD#
        /// ###B#.#.#.###
        /// # D#.#C#.#
        /// # D#B#C#C#
        /// # A#B#C#A#
        /// #########
        /// 
        /// #############
        /// # AA.D......D#
        /// ###B#.#.#.###
        /// # D#B#C#.#
        /// # D#B#C#C#
        /// # A#B#C#A#
        /// #########
        /// 
        /// #############
        /// # AA.D......D#
        /// ###B#.#C#.###
        /// # D#B#C#.#
        /// # D#B#C#.#
        /// # A#B#C#A#
        /// #########
        /// 
        /// #############
        /// # AA.D.....AD#
        /// ###B#.#C#.###
        /// # D#B#C#.#
        /// # D#B#C#.#
        /// # A#B#C#.#
        /// #########
        /// 
        /// #############
        /// # AA.......AD#
        /// ###B#.#C#.###
        /// # D#B#C#.#
        /// # D#B#C#.#
        /// # A#B#C#D#
        /// #########
        /// 
        /// #############
        /// # AA.......AD#
        /// ###.#B#C#.###
        /// # D#B#C#.#
        /// # D#B#C#.#
        /// # A#B#C#D#
        /// #########
        /// 
        /// #############
        /// # AA.......AD#
        /// ###.#B#C#.###
        /// #.#B#C#.#
        /// # D#B#C#D#
        /// # A#B#C#D#
        /// #########
        /// 
        /// #############
        /// # AA.D.....AD#
        /// ###.#B#C#.###
        /// #.#B#C#.#
        /// #.#B#C#D#
        /// # A#B#C#D#
        /// #########
        /// 
        /// #############
        /// # A..D.....AD#
        /// ###.#B#C#.###
        /// #.#B#C#.#
        /// # A#B#C#D#
        /// # A#B#C#D#
        /// #########
        /// 
        /// #############
        /// #...D.....AD#
        /// ###.#B#C#.###
        /// # A#B#C#.#
        /// # A#B#C#D#
        /// # A#B#C#D#
        /// #########
        /// 
        /// #############
        /// #.........AD#
        /// ###.#B#C#.###
        /// # A#B#C#D#
        /// # A#B#C#D#
        /// # A#B#C#D#
        /// #########
        /// 
        /// #############
        /// #..........D#
        /// ###A#B#C#.###
        /// # A#B#C#D#
        /// # A#B#C#D#
        /// # A#B#C#D#
        /// #########
        /// 
        /// #############
        /// #...........#
        /// ###A#B#C#D###
        /// # A#B#C#D#
        /// # A#B#C#D#
        /// # A#B#C#D#
        /// #########
        /// Using the initial configuration from the full diagram, what is the least energy required to organize the amphipods?
        /// </summary>        
        [Benchmark]
        public int PartTwo() => PartTwo0(data!);

        private static int PartTwo0(List<string> input0)
        {
            string input = string.Concat(input0);
            char[] initialWorld = input.Where(c => c is '.' or >= 'A' and <= 'D').ToArray();
            int hallwaySize = initialWorld.Where(c => c == '.').Count();

            int[] cost = [1, 10, 100, 1000];
            int[] directions = [-1, 1];

            string extras = @"
#D#C#B#A#
#D#B#A#C#";

            char[] extraChars = extras.Where(c => c >= 'A' && c <= 'D').ToArray();
            char[] deepWorld = initialWorld.Take(hallwaySize + 4).Concat(extraChars).Concat(initialWorld.Skip(hallwaySize + 4)).ToArray();

            return Organize(new GameState(deepWorld, 0), hallwaySize, cost, directions);
        }

        private static int Organize(GameState initialState, int hallwaySize, int[] cost, int[] directions)
        {
            int depth = (initialState.World.Length - hallwaySize) / 4;
            PriorityQueue<GameState, int> frontier = new();
            frontier.Enqueue(initialState, 0);
            HashSet<string> visited = [];
            while (frontier.Count > 0)
            {
                GameState node = frontier.Dequeue();
                string worldString = new(node.World);
                if (visited.Contains(worldString)) continue;
                if (IsTarget(node, depth, hallwaySize)) return node.Energy;

                visited.Add(worldString);
                frontier.EnqueueRange(GetNeighbors(depth, node, hallwaySize, cost, directions).Select(n => (n, n.Energy)));
            }

            throw new Exception("Impossible to organize");
        }

        private static bool IsTarget(GameState state, int depth, int hallwaySize)
        {
            for (int i = 0; i < hallwaySize; i++)
            {
                if (state.World[i] != '.') return false;
            }

            for (int r = 0; r < 4; r++)
            {
                if (!IsRoomOrganized(state.World, depth, r, hallwaySize)) return false;
            }

            return true;
        }

        private static List<GameState> GetNeighbors(int depth, GameState state, int hallwaySize, int[] cost, int[] directions)
        {
            List<GameState> neighbors = [];

            for (int i = 0; i < hallwaySize; i++)
            {
                if (state.World[i] == '.') continue;

                char picked = state.World[i];
                int pickedIndex = picked - 'A';

                bool canMoveToRoom = IsRoomOrganized(state.World, depth, pickedIndex, hallwaySize);
                if (!canMoveToRoom) continue;

                int targetPosition = 2 + 2 * pickedIndex;

                int direction = targetPosition > i ? 1 : -1;
                for (int j = direction; Math.Abs(j) <= Math.Abs(targetPosition - i); j += direction)
                {
                    if (state.World[i + j] != '.')
                    {
                        canMoveToRoom = false;
                        break;
                    }
                }

                if (!canMoveToRoom) continue;

                char[] newWorld = new char[state.World.Length];
                state.World.CopyTo(newWorld, 0);

                newWorld[i] = '.';
                PushRoom(newWorld, depth, pickedIndex, picked, hallwaySize);

                int newEnergy = state.Energy + (Math.Abs(targetPosition - i) + (depth - RoomCount(state.World, depth, pickedIndex, hallwaySize))) * cost[pickedIndex];
                neighbors.Add(new GameState(newWorld, newEnergy));
            }

            if (neighbors.Count > 0) return neighbors;

            for (int r = 0; r < 4; r++)
            {
                if (IsRoomOrganized(state.World, depth, r, hallwaySize)) continue;

                char picked = PeekRoom(state.World, depth, r, hallwaySize);
                int pickedIndex = picked - 'A';

                int energy = state.Energy + (depth - RoomCount(state.World, depth, r, hallwaySize) + 1) * cost[pickedIndex];
                int roomPosition = 2 + 2 * r;
                foreach (int direction in directions)
                {
                    int distance = direction;
                    while (roomPosition + distance >= 0 && roomPosition + distance < hallwaySize && state.World[roomPosition + distance] == '.')
                    {
                        if (roomPosition + distance == 2 || roomPosition + distance == 4 || roomPosition + distance == 6 || roomPosition + distance == 8)
                        {
                            distance += direction;
                            continue;
                        }

                        char[] newWorld = new char[state.World.Length];
                        state.World.CopyTo(newWorld, 0);

                        newWorld[roomPosition + distance] = picked;
                        PopRoom(newWorld, depth, r, hallwaySize);

                        neighbors.Add(new GameState(newWorld, energy + Math.Abs(distance) * cost[pickedIndex]));

                        distance += direction;
                    }
                }
            }

            return neighbors;
        }

        private static bool IsRoomOrganized(char[] world, int depth, int r, int hallwaySize)
        {
            for (int i = depth - 1; i >= 0; i--)
            {
                char c = world[hallwaySize + i * 4 + r];
                if (c == '.') return true;
                if (c != 'A' + r) return false;
            }

            return true;
        }

        private static int RoomCount(char[] world, int depth, int r, int hallwaySize)
        {
            int count = 0;
            for (int i = depth - 1; i >= 0; i--)
            {
                char c = world[hallwaySize + i * 4 + r];
                if (c == '.') return count;

                count++;
            }

            return count;
        }

        private static char PeekRoom(char[] world, int depth, int r, int hallwaySize)
        {
            for (int i = 0; i < depth; i++)
            {
                int index = hallwaySize + i * 4 + r;
                if (world[index] != '.') return world[index];
            }
            throw new Exception("Cannot peek at empty room");
        }

        private static void PopRoom(char[] world, int depth, int r, int hallwaySize)
        {
            for (int i = 0; i < depth; i++)
            {
                int index = hallwaySize + i * 4 + r;
                if (world[index] != '.')
                {
                    world[index] = '.';
                    return;
                }
            }
            throw new Exception("Cannot pop from empty room");
        }

        private static void PushRoom(char[] world, int depth, int r, char c, int hallwaySize)
        {
            for (int i = depth - 1; i >= 0; i--)
            {
                int index = hallwaySize + i * 4 + r;
                if (world[index] == '.')
                {
                    world[index] = c;
                    return;
                }
            }
            throw new Exception("Cannot push into full room");
        }

        private record struct GameState(char[] World, int Energy) { }
        #endregion

        #region UnitTest
        public static int PartOne_Test(List<string> data) => PartOne0(data);

        public static int PartTwo_Test(List<string> data) => PartTwo0(data);
        #endregion

        #region Host
        private readonly IRftAdventOfCodeHostData? RftAdventOfCodeHostData;

        public _23_Amphipod(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_23_Amphipod));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}