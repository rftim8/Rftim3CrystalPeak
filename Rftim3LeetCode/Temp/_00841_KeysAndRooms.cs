namespace Rftim3LeetCode.Temp
{
    public class _00841_KeysAndRooms
    {
        /// <summary>
        /// There are n rooms labeled from 0 to n - 1 and all the rooms are locked except for room 0. 
        /// Your goal is to visit all the rooms. 
        /// However, you cannot enter a locked room without having its key.
        /// When you visit a room, you may find a set of distinct keys in it.Each key has a number on it, denoting which room it unlocks, 
        /// and you can take all of them with you to unlock the other rooms.
        /// Given an array rooms where rooms[i] is the set of keys that you can obtain if you visited room i, 
        /// return true if you can visit all the rooms, or false otherwise.
        /// </summary>
        public _00841_KeysAndRooms()
        {
            Console.WriteLine(KeysAndRooms0([
                [1],
                [2],
                [3],
                []
            ]));

            Console.WriteLine(KeysAndRooms0([
                [1,3],
                [3,0,1],
                [2],
                [0]
            ]));
        }

        public static bool KeysAndRooms0(IList<IList<int>> a0) => RftKeysAndRooms0(a0);

        public static bool KeysAndRooms1(IList<IList<int>> a0) => RftKeysAndRooms1(a0);

        private static bool RftKeysAndRooms0(IList<IList<int>> rooms)
        {
            bool[] vis = new bool[rooms.Count];
            vis[0] = true;
            Stack<int> stack = new();
            stack.Push(0);

            while (stack.Count != 0)
            {
                int node = stack.Pop();
                foreach (int item in rooms[node])
                {
                    if (!vis[item])
                    {
                        vis[item] = true;
                        stack.Push(item);
                    }
                }
            }

            foreach (bool item in vis)
            {
                if (!item) return false;
            }

            return true;
        }

        private static bool RftKeysAndRooms1(IList<IList<int>> rooms)
        {
            int size = rooms.Count;
            bool[] visited = new bool[size];
            Queue<int> queue = new();
            queue.Enqueue(0);

            while (queue.Count != 0)
            {
                int room = queue.Dequeue();
                visited[room] = true;
                foreach (int key in rooms[room])
                {
                    if (!visited[key]) queue.Enqueue(key);
                }
            }

            return visited.All(v => v);
        }
    }
}