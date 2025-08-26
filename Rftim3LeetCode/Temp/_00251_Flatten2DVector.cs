using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00251_Flatten2DVector
    {
        /// <summary>
        /// Design an iterator to flatten a 2D vector. It should support the next and hasNext operations.
        /// 
        /// Implement the Vector2D class:
        /// Vector2D(int[][] vec) initializes the object with the 2D vector vec.
        /// next() returns the next element from the 2D vector and moves the pointer one step forward.
        /// You may assume that all the calls to next are valid.
        /// hasNext() returns true if there are still some elements in the vector, and false otherwise.
        /// </summary>
        public _00251_Flatten2DVector()
        {
            List<object?> x = Flatten2DVector0(
                ["Vector2D", "next", "next", "next", "hasNext", "hasNext", "next", "hasNext"],
                [new int[][] { [1, 2], [3], [4] }, 0, 0, 0, 0, 0, 0, 0]
                );
            RftTerminal.RftReadResult(x);
        }

        public static List<object?> Flatten2DVector0(string[] a0, object[] a1) => RftFlatten2DVector0(a0, a1);

        private static List<object?> RftFlatten2DVector0(string[] a0, object[] a1)
        {
            List<object?> res = [];

            Vector2D x = new((int[][])a1[0]);

            foreach (string item in a0)
            {
                switch (item)
                {
                    case "Vector2D":
                        res.Add(null);
                        break;
                    case "next":
                        int t = x.Next();
                        res.Add(t);
                        break;
                    case "hasNext":
                        res.Add(x.HasNext());
                        break;
                    default:
                        break;
                }
            }

            return res;
        }

        private class Vector2D
        {
            private readonly List<int> x = [];
            private int c;

            public Vector2D(int[][] vec)
            {
                c = 0;

                foreach (int[] item in vec)
                {
                    foreach (int item1 in item)
                    {
                        x.Add(item1);
                    }
                }
            }

            public int Next()
            {
                int t = x[c];
                c++;

                return t;
            }

            public bool HasNext()
            {
                return c < x.Count;
            }
        }
    }
}
