namespace Rftim3LeetCode.Temp
{
    public class _01535_FindTheWinnerOfAnArrayGame
    {
        /// <summary>
        /// Given an integer array arr of distinct integers and an integer k.
        /// 
        /// A game will be played between the first two elements of the array(i.e.arr[0] and arr[1]). 
        /// In each round of the game, we compare arr[0] with arr[1], the larger integer wins and remains at position 0, and the smaller integer moves to the end of the array.
        /// The game ends when an integer wins k consecutive rounds.
        /// Return the integer which will win the game.
        /// It is guaranteed that there will be a winner of the game.
        /// </summary>
        public _01535_FindTheWinnerOfAnArrayGame()
        {
            Console.WriteLine(GetWinner0([2, 1, 3, 5, 4, 6, 7], 2));
            Console.WriteLine(GetWinner0([3, 2, 1], 10));
        }

        public static int GetWinner0(int[] a0, int a1) => RftGetWinner0(a0, a1);

        public static int GetWinner1(int[] a0, int a1) => RftGetWinner1(a0, a1);

        private static int RftGetWinner0(int[] arr, int k)
        {
            int max = arr.Max();
            int l = 0, r = 1;

            int c = 0, crt = 0;
            while (c <= k)
            {
                if (arr[l] > arr[r])
                {
                    if (crt != arr[l])
                    {
                        crt = arr[l];
                        c = 0;
                    }

                    r++;
                }
                else
                {
                    if (crt != arr[r])
                    {
                        crt = arr[r];
                        c = 0;
                    }

                    l = r;
                    r++;
                }
                c++;
                if (c == k) return crt;

                if (crt == max) return max;
            }

            return -1;
        }

        private static int RftGetWinner1(int[] arr, int k)
        {
            int n = arr.Length;
            int count = 0;
            int currWinner = arr[0];
            if (n < k)
            {
                int max = 0;
                foreach (int i in arr)
                {
                    max = Math.Max(max, i);
                }

                return max;
            }

            for (int i = 1; i < n; i++)
            {
                if (count == k) break;
                if (currWinner > arr[i]) { count++; }
                else
                {
                    count = 1;
                    currWinner = arr[i];
                }
            }

            return currWinner;
        }
    }
}
