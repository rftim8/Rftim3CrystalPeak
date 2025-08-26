namespace Rftim3LeetCode.Temp
{
    public class _00703_KthLargestElementInAStream
    {
        /// <summary>
        /// Design a class to find the kth largest element in a stream. Note that it is the kth largest element in the sorted order, not the kth distinct element.
        /// Implement KthLargest class:
        /// KthLargest(int k, int[] nums) Initializes the object with the integer k and the stream of integers nums.
        /// int add(int val) Appends the integer val to the stream and returns the element representing the kth largest element in the stream.
        /// </summary>
        public _00703_KthLargestElementInAStream()
        {

            KthLargest obj = new(3, [4, 5, 8, 2]);
            Console.WriteLine(obj.Add(3));
            Console.WriteLine(obj.Add(5));
            Console.WriteLine(obj.Add(10));
            Console.WriteLine(obj.Add(9));
            Console.WriteLine(obj.Add(4));
        }

        private class KthLargest
        {
            private readonly int k;
            private readonly List<int> heap;

            public KthLargest(int k, int[] nums)
            {
                this.k = k;
                heap = [.. nums];
                heap.Sort();

                while (heap.Count > k)
                {
                    heap.RemoveAt(0);
                }
            }

            public int Add(int val)
            {
                heap.Add(val);
                heap.Sort();

                if (heap.Count > k) heap.RemoveAt(0);

                return heap[0];
            }
        }

        private class KthLargest0
        {
            private readonly int _k;
            private readonly PriorityQueue<int, int> _queue;

            public KthLargest0(int k, int[] nums)
            {
                _k = k;
                _queue = new PriorityQueue<int, int>(k);

                foreach (int num in nums)
                {
                    Add(num);
                }
            }

            public int Add(int val)
            {
                _queue.Enqueue(val, val);

                if (_queue.Count > _k) _queue.Dequeue();

                return _queue.Peek();
            }
        }
    }
}
