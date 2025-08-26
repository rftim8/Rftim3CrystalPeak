namespace Rftim3LeetCode.Temp
{
    public class _00146_LRUCache
    {
        /// <summary>
        /// Design a data structure that follows the constraints of a Least Recently Used (LRU) cache.
        /// Implement the LRUCache class:
        /// - LRUCache(int capacity) Initialize the LRU cache with positive size capacity.
        /// - int get(int key) Return the value of the key if the key exists, otherwise return -1.
        /// - void put(int key, int value) Update the value of the key if the key exists.
        /// Otherwise, add the key-value pair to the cache.If the number of keys exceeds the capacity from this operation, evict the least recently used key.
        /// The functions get and put must each run in O(1) average time complexity.
        /// </summary>
        public _00146_LRUCache()
        {
            LRUCache obj = new(2);
            obj.Put(1, 1);
            obj.Put(2, 2);
            int a0 = obj.Get(1);
            Console.WriteLine(a0);
            obj.Put(3, 3);
            int a1 = obj.Get(2);
            Console.WriteLine(a1);
            obj.Put(4, 4);
            int a2 = obj.Get(1);
            Console.WriteLine(a2);
            int a3 = obj.Get(3);
            Console.WriteLine(a3);
            int a4 = obj.Get(4);
            Console.WriteLine(a4);
        }

        private class LRUCache(int capacity)
        {
            private readonly int capacity = capacity;
            private readonly LinkedList<int[]>? x = new();
            private readonly Dictionary<int, LinkedListNode<int[]>> y = [];

            public int Get(int key)
            {
                if (!y.TryGetValue(key, out LinkedListNode<int[]>? value)) return -1;

                Sort(value);

                return value.Value[1];
            }

            public void Put(int key, int value0)
            {
                if (y.TryGetValue(key, out LinkedListNode<int[]>? value)) value.Value[1] = value0;
                else
                {
                    if (y.Count == capacity)
                    {
                        y.Remove(x!.Last!.Value[0]);
                        x.RemoveLast();
                    }

                    y.Add(key, new LinkedListNode<int[]>([key, value0]));
                }

                Sort(y[key]);
            }

            private void Sort(LinkedListNode<int[]> node)
            {
                if (node.Previous is not null) x?.Remove(node);
                if (x?.First != node) x?.AddFirst(node);
            }
        }
    }
}
