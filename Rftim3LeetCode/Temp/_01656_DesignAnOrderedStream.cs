namespace Rftim3LeetCode.Temp
{
    public class _01656_DesignAnOrderedStream
    {
        /// <summary>
        /// There is a stream of n (idKey, value) pairs arriving in an arbitrary order, where idKey is an integer between 1 and n and value is a string. 
        /// No two pairs have the same id.
        /// Design a stream that returns the values in increasing order of their IDs by returning a chunk(list) of values after each insertion.
        /// The concatenation of all the chunks should result in a list of the sorted values.
        /// Implement the OrderedStream class:
        /// OrderedStream(int n) Constructs the stream to take n values.
        /// String[] insert(int idKey, String value) Inserts the pair(idKey, value) into the stream, 
        /// then returns the largest possible chunk of currently inserted values that appear next in the order.
        /// </summary>
        public _01656_DesignAnOrderedStream()
        {
            OrderedStream obj = new(5);
            obj.Insert(3, "ccccc");
            obj.Insert(1, "aaaaa");
            obj.Insert(2, "bbbbb");
            obj.Insert(5, "eeeee");
            obj.Insert(4, "ddddd");
        }

        private class OrderedStream
        {
            private readonly string[] r;

            public OrderedStream(int n)
            {
                r = new string[n + 1];
                r[0] = "a";
            }

            public IList<string> Insert(int idKey, string value)
            {
                r[idKey] = value;
                List<string> x = [];

                bool q = true;
                int j = idKey;
                while (j > -1)
                {
                    if (string.IsNullOrEmpty(r[j]))
                    {
                        q = false;
                        break;
                    }
                    j--;
                }

                if (q)
                {
                    for (int i = idKey; i < r.Length; i++)
                    {
                        if (!string.IsNullOrEmpty(r[i])) x.Add(r[i]);
                        else break;
                    }
                }

                return x;
            }
        }
    }
}
