using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00232_ImplementQueueUsingStacks
    {
        /// <summary>
        /// Implement a first in first out (FIFO) queue using only two stacks. 
        /// The implemented queue should support all the functions of a normal queue (push, peek, pop, and empty).
        /// Implement the MyQueue class:
        /// void push(int x) Pushes element x to the back of the queue.
        /// int pop() Removes the element from the front of the queue and returns it.
        /// int peek() Returns the element at the front of the queue.
        /// boolean empty() Returns true if the queue is empty, false otherwise.
        /// Notes:
        /// You must use only standard operations of a stack, which means only push to top, peek/pop from top, size, and is empty operations are valid.
        /// Depending on your language, the stack may not be supported natively.
        /// You may simulate a stack using a list or deque(double-ended queue) as long as you use only a stack's standard operations.
        /// </summary>
        public _00232_ImplementQueueUsingStacks()
        {
            List<object?> x = ImplementQueueUsingStacks0(
                ["push", "push", "peek", "pop", "empty"],
                [1, 2, null, null]
                );
            RftTerminal.RftReadResult(x);
        }

        public static List<object?> ImplementQueueUsingStacks0(List<string> a0, List<int?> a1) => RftImplementQueueUsingStacks0(a0, a1);

        private static List<object?> RftImplementQueueUsingStacks0(List<string> a, List<int?> b)
        {
            List<object?> actual = [];

            MyQueue obj = new();
            for (int i = 0; i < a.Count; i++)
            {
                switch (a[i])
                {
                    case "push":
                        obj.Push((int)b[i]!);
                        actual.Add(null);
                        break;
                    case "peek":
                        int param0 = obj.Peek();
                        actual.Add(param0);
                        break;
                    case "pop":
                        int param1 = obj.Pop();
                        actual.Add(param1);
                        break;
                    case "empty":
                        bool param2 = obj.Empty();
                        actual.Add(param2);
                        break;
                    default:
                        break;
                }
            }

            return actual;
        }

        private class MyQueue
        {
            private readonly List<int> y = [];

            public MyQueue()
            {

            }

            public void Push(int x) => y.Add(x);

            public int Pop()
            {
                int z = -1;

                if (y.Count != 0)
                {
                    z = y.First();
                    y.RemoveAt(0);
                }

                return z;
            }

            public int Peek() => y.Count != 0 ? y.First() : -1;

            public bool Empty() => y.Count == 0;
        }
    }
}
