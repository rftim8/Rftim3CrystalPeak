namespace Rftim3LeetCode.Temp
{
    public class _00771_JewelsAndStones
    {
        /// <summary>
        /// You're given strings jewels representing the types of stones that are jewels, and stones representing the stones you have. 
        /// Each character in stones is a type of stone you have. 
        /// You want to know how many of the stones you have are also jewels.
        /// Letters are case sensitive, so "a" is considered a different type of stone from "A".
        /// </summary>
        public _00771_JewelsAndStones()
        {
            Console.WriteLine(NumJewelsInStones("aA", "aAAbbbb"));
            Console.WriteLine(NumJewelsInStones("z", "ZZ"));
        }

        private static int NumJewelsInStones(string jewels, string stones)
        {
            int n = jewels.Length;
            int m = stones.Length;
            int c = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (stones[j] == jewels[i]) c++;
                }
            }

            return c;
        }
    }
}
