namespace Rftim3LeetCode.Temp
{
    public class _00904_FruitIntoBaskets
    {
        /// <summary>
        /// You are visiting a farm that has a single row of fruit trees arranged from left to right. The trees are represented by an integer array fruits where fruits[i] is the type of fruit the ith tree produces.
        /// You want to collect as much fruit as possible.However, the owner has some strict rules that you must follow:
        /// You only have two baskets, and each basket can only hold a single type of fruit.There is no limit on the amount of fruit each basket can hold.
        /// Starting from any tree of your choice, you must pick exactly one fruit from every tree(including the start tree) while moving to the right.The picked fruits must fit in one of your baskets.
        /// Once you reach a tree with fruit that cannot fit in your baskets, you must stop.
        /// Given the integer array fruits, return the maximum number of fruits you can pick.
        /// </summary>
        public _00904_FruitIntoBaskets()
        {
            Console.WriteLine(TotalFruit([3, 3, 3, 1, 2, 1, 1, 2, 3, 3, 4]));
            Console.WriteLine(TotalFruit([0, 1, 1, 2]));
        }

        private static int TotalFruit(int[] fruits)
        {
            List<int> x = [];
            int l = -1, r = fruits[0], c = 1;
            int fl = fruits.Length;

            if (fl == 1) return 1;

            for (int i = 1; i < fl; i++)
            {
                if (fruits[i] == r) c++;
                else if (fruits[i] != r && l == -1)
                {
                    l = r;
                    r = fruits[i];
                    c++;
                }
                else if (fruits[i] == l && fruits[i] != r && l != -1)
                {
                    l = r;
                    r = fruits[i];
                    c++;
                }
                else if (fruits[i] != l && fruits[i] != r && l != -1)
                {
                    x.Add(c);
                    c = 0;
                    int d = i - 1, t = -1;
                    while (fruits[d] == r)
                    {
                        t++;
                        d--;
                    }
                    x.Add(c + t);
                    c = t;
                    l = r;
                    r = fruits[i];
                    c += 2;
                }
                if (i == fl - 1) x.Add(c);
            }

            return x.Count > 0 ? x.Max() : 0;
        }
    }
}
