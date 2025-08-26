namespace Rftim3LeetCode.Temp
{
    public class _00799_ChampagneTower
    {
        /// <summary>
        /// We stack glasses in a pyramid, where the first row has 1 glass, the second row has 2 glasses, and so on until the 100th row.  
        /// Each glass holds one cup of champagne.
        /// Then, some champagne is poured into the first glass at the top.When the topmost glass is full, 
        /// any excess liquid poured will fall equally to the glass immediately to the left and right of it.  
        /// When those glasses become full, any excess champagne will fall equally to the left and right of those glasses, and so on.  
        /// (A glass at the bottom row has its excess champagne fall on the floor.)
        /// For example, after one cup of champagne is poured, the top most glass is full.
        /// After two cups of champagne are poured, the two glasses on the second row are half full.
        /// After three cups of champagne are poured, those two cups become full - there are 3 full glasses total now.  
        /// After four cups of champagne are poured, the third row has the middle glass half full, and the two outside glasses are a quarter full, as pictured below.
        /// </summary>
        public _00799_ChampagneTower()
        {
            Console.WriteLine(ChampagneTower(1, 1, 1));
            Console.WriteLine(ChampagneTower(2, 1, 1));
            Console.WriteLine(ChampagneTower(100000009, 33, 17));
        }

        private static double ChampagneTower(int poured, int query_row, int query_glass)
        {
            int n = 102;
            double[][] r = new double[n][];

            for (int i = 0; i < n; i++)
            {
                r[i] = new double[n];
            }

            r[0][0] = poured;

            for (int i = 0; i <= query_row; ++i)
            {
                for (int j = 0; j <= i; ++j)
                {
                    double t = (r[i][j] - 1) / 2;
                    if (t > 0)
                    {
                        r[i + 1][j] += t;
                        r[i + 1][j + 1] += t;
                    }
                }
            }

            return Math.Min(1, r[query_row][query_glass]);
        }

        private static double ChampagneTower0(int poured, int query_row, int query_glass)
        {
            double[] r = [poured];

            while (query_row-- > 0)
            {
                double[] t = new double[r.Length + 1];
                t[0] = t[^1] = Math.Max((r[0] - 1) / 2, 0);

                for (int i = 1; i < t.Length - 1; i++)
                {
                    t[i] = Math.Max((r[i - 1] - 1) / 2, 0) + Math.Max((r[i] - 1) / 2, 0);
                }

                r = t;
            }

            return Math.Min(1, r[query_glass]);
        }
    }
}
