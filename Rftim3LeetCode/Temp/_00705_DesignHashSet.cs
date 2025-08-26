using System.Collections;

namespace Rftim3LeetCode.Temp
{
    public class _00705_DesignHashSet
    {
        /// <summary>
        /// Design a HashSet without using any built-in hash table libraries.
        /// Implement MyHashSet class:
        /// void add(key) Inserts the value key into the HashSet.
        /// bool contains(key) Returns whether the value key exists in the HashSet or not.
        /// void remove(key) Removes the value key in the HashSet. 
        /// If key does not exist in the HashSet, do nothing.
        /// </summary>
        public _00705_DesignHashSet()
        {
            MyHashSet obj = new();
            obj.Add(1);
            obj.Remove(2);
            bool param_3 = obj.Contains(1);
            Console.WriteLine(param_3);
        }

        private class MyHashSet
        {
            private readonly HashSet<object> x = [];

            public MyHashSet()
            {

            }

            public void Add(int key)
            {
                x.Add(key);
            }

            public void Remove(int key)
            {
                if (x.Contains(key)) x.Remove(key);
            }

            public bool Contains(int key)
            {
                return x.Contains(key);
            }
        }

        private class MyHashSet0
        {
            private readonly BitArray contains = new(1_000_001);

            public void Add(int key) => contains[key] = true;

            public void Remove(int key) => contains[key] = false;

            public bool Contains(int key) => contains[key];
        }
    }
}
