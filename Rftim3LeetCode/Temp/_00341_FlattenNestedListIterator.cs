using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00341_FlattenNestedListIterator
    {
        /// <summary>
        /// You are given a nested list of integers nestedList. 
        /// Each element is either an integer or a list whose elements may also be integers or other lists. 
        /// Implement an iterator to flatten it.
        /// Implement the NestedIterator class:
        /// NestedIterator(List < NestedInteger > nestedList) Initializes the iterator with the nested list nestedList.
        /// int next() Returns the next integer in the nested list.
        /// boolean hasNext() Returns true if there are still some integers in the nested list and false otherwise.
        /// Your code will be tested with the following pseudocode:
        /// initialize iterator with nestedList
        /// res = []
        /// while iterator.hasNext()
        /// append iterator.next() to the end of res
        /// return res
        /// If res matches the expected flattened list, then your code will be judged as correct.
        /// </summary>
        public _00341_FlattenNestedListIterator()
        {
            IList<int> x = FlattenNestedListIterator0();
            RftTerminal.RftReadResult(x);
        }

        public static IList<int> FlattenNestedListIterator0() => RftFlattenNestedListIterator0();

        private static List<int> RftFlattenNestedListIterator0()
        {
            List<int> r = [];

            IList<INestedInteger> x =
            [
                new RftNestedInteger() { t = [new List<object> { 1, 1 }, 2, new List<object> { 1, 1 }] }
            ];

            IList<INestedInteger> x0 =
            [
                new RftNestedInteger() { t = [new List<object> { 1, new List<object> { 4, new List<object> { 6 } } }] }
            ];

            NestedIterator i = new(x);
            while (i.HasNext())
            {
                int y = i.Next();
                r.Add(y);
            }

            return r;
        }

        private class NestedIterator
        {
            private readonly Queue<int> q = new();

            public NestedIterator(IList<INestedInteger> nestedList)
            {
                foreach (INestedInteger item in nestedList)
                {
                    DFS(item);
                }
            }

            public bool HasNext() => q.Count != 0;

            public int Next() => q.Count == 0 ? 0 : q.Dequeue();

            private void DFS(INestedInteger cur)
            {
                if (cur.IsInteger()) q.Enqueue(cur.GetInteger());
                else
                {
                    foreach (INestedInteger item in cur.GetList())
                    {
                        DFS(item);
                    }
                }
            }
        }

        private interface INestedInteger
        {
            bool IsInteger();

            int GetInteger();

            IList<INestedInteger> GetList();
        }

        private class RftNestedInteger : INestedInteger
        {
            public List<object>? t;

            public int GetInteger() => 0;

            public IList<INestedInteger> GetList() => [];

            public bool IsInteger() => t?.GetType() == typeof(int);
        }

        private class NestedIterator0(IList<INestedInteger> nestedList)
        {
            private readonly IList<int> integers = Fill(nestedList);
            private int index = -1;

            public static IList<int> Fill(IList<INestedInteger> nestedList)
            {
                ArgumentNullException.ThrowIfNull(nestedList);

                List<int> result = [];

                foreach (INestedInteger nestedInteger in nestedList)
                {
                    if (nestedInteger.IsInteger()) result.Add(nestedInteger.GetInteger());
                    else result.AddRange(Fill(nestedInteger.GetList()));
                }

                return result;
            }

            public bool HasNext() => index + 1 < integers.Count;

            public int Next() => integers[++index];
        }
    }
}
