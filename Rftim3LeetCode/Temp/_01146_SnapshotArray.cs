namespace Rftim3LeetCode.Temp
{
    public class _01146_SnapshotArray
    {
        /// <summary>
        /// Implement a SnapshotArray that supports the following interface:
        /// - SnapshotArray(int length) initializes an array-like data structure with the given length.
        /// Initially, each element equals 0.
        /// - void set(index, val) sets the element at the given index to be equal to val.
        /// - int snap() takes a snapshot of the array and returns the snap_id: the total number of times we called snap() minus 1.
        /// - int get(index, snap_id) returns the value at the given index, at the time we took the snapshot with the given snap_id
        /// </summary>
        public _01146_SnapshotArray()
        {
            SnapshotArray x = new(3);
            x.Set(0, 5);
            int param_2 = x.Snap();
            Console.WriteLine(param_2);
            x.Set(0, 6);
            int param_3 = x.Get(0, 0);
            Console.WriteLine(param_3);
        }

        private class SnapshotArray
        {
            private int snapId = 0;
            private readonly SortedList<int, int>[] historyRecords;

            public SnapshotArray(int length)
            {
                historyRecords = new SortedList<int, int>[length];
                for (int i = 0; i < length; i++)
                {
                    historyRecords[i] = new SortedList<int, int>
                    {
                        { 0, 0 }
                    };
                }
            }

            public void Set(int index, int val)
            {
                int x = historyRecords[index].IndexOfKey(snapId);
                if (x != -1)
                {
                    historyRecords[index].RemoveAt(x);
                }
                historyRecords[index].Add(snapId, val);
            }

            public int Snap()
            {
                return snapId++;
            }

            public int Get(int index, int snapId)
            {
                int l = 0;
                int r = historyRecords[index].Keys.Count - 1;

                int x = 0;

                while (l <= r)
                {
                    int mid = l + (r - l) / 2;

                    if (historyRecords[index].Keys[mid] > snapId) r = mid - 1;
                    else
                    {
                        x = historyRecords[index].Values[mid];
                        l = mid + 1;
                    }
                }

                return x;
            }
        }
    }
}
