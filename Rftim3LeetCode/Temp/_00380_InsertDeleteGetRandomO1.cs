using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00380_InsertDeleteGetRandomO1
    {
        /// <summary>
        /// Implement the RandomizedSet class:
        /// 
        /// RandomizedSet() Initializes the RandomizedSet object.
        /// bool insert(int val) Inserts an item val into the set if not present.
        /// Returns true if the item was not present, false otherwise.
        /// bool remove(int val) Removes an item val from the set if present.
        /// Returns true if the item was present, false otherwise.
        /// int getRandom() Returns a random element from the current set of elements 
        /// (it's guaranteed that at least one element exists when this method is called). 
        /// Each element must have the same probability of being returned.
        /// You must implement the functions of the class such that each function works in average O(1) time complexity.
        /// </summary>
        public _00380_InsertDeleteGetRandomO1()
        {
            string[] a0 = ["RandomizedSet", "insert", "remove", "insert", "getRandom", "remove", "insert", "getRandom"];
            int[][] a1 = [[], [1], [2], [2], [], [1], [2], []];

            List<object?> x0 = RandomizeSet0(a0, a1);
            RftTerminal.RftReadResult(x0);

            List<object?> x1 = RandomizeSet0(a0, a1);
            RftTerminal.RftReadResult(x1);
        }

        public static List<object?> RandomizeSet0(string[] a0, int[][] a1) => RftRandomizeSet0(a0, a1);

        public static List<object?> RandomizeSet1(string[] a0, int[][] a1) => RftRandomizeSet1(a0, a1);

        public static List<object?>? R { get; set; }

        private static List<object?> RftRandomizeSet0(string[] a0, int[][] a1)
        {
            R = [null];
            RandomizedSet obj = new();
            int n = a0.Length;
            for (int i = 1; i < n; i++)
            {
                switch (a0[i])
                {
                    case "insert":
                        R.Add(obj.Insert(a1[i][0]));
                        break;
                    case "remove":
                        R.Add(obj.Remove(a1[i][0]));
                        break;
                    case "getRandom":
                        R.Add(obj.GetRandom());
                        break;
                    default:
                        break;
                }
            }

            return R;
        }

        private static List<object?> RftRandomizeSet1(string[] a0, int[][] a1)
        {
            R = [null];
            RandomizedSet1 obj = new();
            int n = a0.Length;
            for (int i = 1; i < n; i++)
            {
                switch (a0[i])
                {
                    case "insert":
                        R.Add(obj.Insert(a1[i][0]));
                        break;
                    case "remove":
                        R.Add(obj.Remove(a1[i][0]));
                        break;
                    case "getRandom":
                        R.Add(obj.GetRandom());
                        break;
                    default:
                        break;
                }
            }

            return R;
        }

        private class RandomizedSet
        {
            private readonly List<int> r;

            public RandomizedSet()
            {
                r = [];
            }

            public bool Insert(int val)
            {
                if (r.Contains(val)) return false;
                else
                {
                    r.Add(val);
                    return true;
                }
            }

            public bool Remove(int val)
            {
                if (r.Count != 0 && r.Contains(val))
                {
                    r.Remove(val);
                    return true;
                }
                else return false;
            }

            public int GetRandom()
            {
                Random random = new();

                return r[random.Next(r.Count)];
            }
        }

        private class RandomizedSet1
        {

            private readonly Random _random;
            private readonly List<int> _list;
            private readonly Dictionary<int, int> _dictionary;
            private int _index;

            public RandomizedSet1()
            {
                _random = new Random();
                _list = [];
                _dictionary = [];
                _index = 0;
            }

            public bool Insert(int val)
            {
                if (_dictionary.ContainsKey(val)) return false;

                _dictionary.Add(val, _index++);
                _list.Add(val);

                return true;
            }

            public bool Remove(int val)
            {

                if (!_dictionary.TryGetValue(val, out int value)) return false;

                int indexToBeRemoved = value;
                int lastItem = _list[_index - 1];
                Swap(indexToBeRemoved, _index - 1);
                _dictionary[lastItem] = indexToBeRemoved;
                _list.RemoveAt(--_index);
                _dictionary.Remove(val);

                return true;
            }

            private void Swap(int i1, int i2)
            {
                (_list[i2], _list[i1]) = (_list[i1], _list[i2]);
            }

            public int GetRandom()
            {
                int randomIndex = _random.Next(_index);

                return _list[randomIndex];
            }
        }
    }
}
