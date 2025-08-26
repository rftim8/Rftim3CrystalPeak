namespace Rftim3LeetCode.Temp
{
    public class _02336_SmallestNumberInInfiniteSet
    {
        /// <summary>
        /// You have a set which contains all positive integers [1, 2, 3, 4, 5, ...].
        /// Implement the SmallestInfiniteSet class:
        /// SmallestInfiniteSet() Initializes the SmallestInfiniteSet object to contain all positive integers.
        /// int popSmallest() Removes and returns the smallest integer contained in the infinite set.
        /// void addBack(int num) Adds a positive integer num back into the infinite set, if it is not already in the infinite set.
        /// </summary>
        public _02336_SmallestNumberInInfiniteSet()
        {
            SmallestInfiniteSet obj = new();
            obj.AddBack(2);
            int param_1 = obj.PopSmallest();
            Console.WriteLine(param_1);
            int param_2 = obj.PopSmallest();
            Console.WriteLine(param_2);
            int param_3 = obj.PopSmallest();
            Console.WriteLine(param_3);
            obj.AddBack(1);
            int param_4 = obj.PopSmallest();
            Console.WriteLine(param_4);
            int param_5 = obj.PopSmallest();
            Console.WriteLine(param_5);
            int param_6 = obj.PopSmallest();
            Console.WriteLine(param_6);
        }

        private class SmallestInfiniteSet
        {
            private readonly int[] x = Enumerable.Repeat(1, 1001).ToArray();

            public SmallestInfiniteSet()
            {

            }

            public int PopSmallest()
            {
                for (int i = 1; i < x.Length; i++)
                {
                    if (x[i] == 1)
                    {
                        x[i] = 0;
                        return i;
                    }
                }

                return -1;
            }

            public void AddBack(int num)
            {
                if (x[num] == 0) x[num] = 1;
            }
        }

        private class SmallestInfiniteSet0
        {
            private readonly SortedSet<int> numberSet;
            private int CurrentNumber;

            public SmallestInfiniteSet0()
            {
                numberSet = [];
                CurrentNumber = 1;
            }

            public int PopSmallest()
            {
                int answer;
                if (numberSet.Count > 0)
                {
                    answer = numberSet.First();
                    numberSet.Remove(answer);
                }
                else
                {
                    answer = CurrentNumber;
                    CurrentNumber++;
                }
                return answer;
            }

            public void AddBack(int num)
            {
                if (num >= CurrentNumber) return;

                numberSet.Add(num);
            }
        }
    }
}
