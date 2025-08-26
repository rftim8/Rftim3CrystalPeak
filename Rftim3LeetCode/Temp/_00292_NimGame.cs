namespace Rftim3LeetCode.Temp
{
    public class _00292_NimGame
    {
        /// <summary>
        /// You are playing the following Nim Game with your friend:
        /// Initially, there is a heap of stones on the table.
        /// You and your friend will alternate taking turns, and you go first.
        /// On each turn, the person whose turn it is will remove 1 to 3 stones from the heap.
        /// The one who removes the last stone is the winner.
        /// Given n, the number of stones in the heap, return true if you can win the game assuming both you and your friend play optimally, otherwise return false.
        /// </summary>
        public _00292_NimGame()
        {
            Console.WriteLine(CanWinNim0(4));
            Console.WriteLine(CanWinNim0(1));
            Console.WriteLine(CanWinNim0(2));
        }

        public static bool CanWinNim0(int a0) => RftCanWinNim0(a0);

        public static bool CanWinNim1(int a0) => RftCanWinNim1(a0);

        private static bool RftCanWinNim0(int n)
        {
            return n % 4 != 0;
        }

        private static bool RftCanWinNim1(int n)
        {
            return (n & 3) != 0;
        }
    }
}
