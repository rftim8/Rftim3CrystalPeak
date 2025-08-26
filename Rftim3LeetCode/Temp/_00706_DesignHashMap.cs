namespace Rftim3LeetCode.Temp
{
    public class _00706_DesignHashMap
    {
        /// <summary>
        /// Design a HashMap without using any built-in hash table libraries.
        /// Implement the MyHashMap class:
        /// MyHashMap() initializes the object with an empty map.
        /// void put(int key, int value) inserts a(key, value) pair into the HashMap.If the key already exists in the map, update the corresponding value.
        /// int get(int key) returns the value to which the specified key is mapped, or -1 if this map contains no mapping for the key.
        /// void remove(key) removes the key and its corresponding value if the map contains the mapping for the key.
        /// </summary>
        public _00706_DesignHashMap()
        {
            MyHashMap obj = new();
            obj.Put(1, 1);
            obj.Put(2, 2);
            obj.Get(1);
            obj.Get(3);
            obj.Put(2, 1);
            obj.Get(2);
            obj.Remove(2);
            obj.Get(2);
        }

        private class MyHashMap
        {
            private readonly Dictionary<int, int> x = [];

            public MyHashMap()
            {

            }

            public void Put(int key, int value)
            {
                if (!x.TryAdd(key, value)) x[key] = value;
            }

            public int Get(int key)
            {
                return x.TryGetValue(key, out int value) ? value : -1;
            }

            public void Remove(int key)
            {
                x.Remove(key);
            }
        }
    }
}
