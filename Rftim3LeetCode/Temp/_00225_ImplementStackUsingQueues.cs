using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00225_ImplementStackUsingQueues
    {
        /// <summary>
        /// Implement a last-in-first-out (LIFO) stack using only two queues. 
        /// The implemented stack should support all the functions of a normal stack (push, top, pop, and empty).
        /// Implement the MyStack class:
        /// void push(int x) Pushes element x to the top of the stack.
        /// int pop() Removes the element on the top of the stack and returns it.
        /// int top() Returns the element on the top of the stack.
        /// boolean empty() Returns true if the stack is empty, false otherwise.
        /// Notes:
        /// You must use only standard operations of a queue, which means that only push to back, peek/pop from front, size and is empty operations are valid.
        /// Depending on your language, the queue may not be supported natively.
        /// You may simulate a queue using a list or deque(double-ended queue) as long as you use only a queue's standard operations.
        /// </summary>
        public _00225_ImplementStackUsingQueues()
        {
            List<object?> x = ImplementStackUsingQueues0(
                ["push", "push", "top", "pop", "empty"],
                [1, 2, null, null]
                );
            RftTerminal.RftReadResult(x);
        }

        public static List<object?> ImplementStackUsingQueues0(List<string> a0, List<int?> a1) => RftImplementStackUsingQueues0(a0, a1);

        public static List<object?> ImplementStackUsingQueues1(List<string> a0, List<int?> a1) => RftImplementStackUsingQueues1(a0, a1);

        private static List<object?> RftImplementStackUsingQueues0(List<string> a, List<int?> b)
        {
            List<object?> actual = [];

            MyStack obj = new();
            for (int i = 0; i < a.Count; i++)
            {
                switch (a[i])
                {
                    case "push":
                        obj.Push((int)b[i]!);
                        actual.Add(null);
                        break;
                    case "top":
                        int param0 = obj.Top();
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

        private static List<object?> RftImplementStackUsingQueues1(List<string> a, List<int?> b)
        {
            List<object?> actual = [];

            MyStack0 obj = new();
            for (int i = 0; i < a.Count; i++)
            {
                switch (a[i])
                {
                    case "push":
                        obj.Push((int)b[i]!);
                        actual.Add(null);
                        break;
                    case "top":
                        int param0 = obj.Top();
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

        private class MyStack
        {
            private Queue<int> _firstQueue = new();
            private Queue<int> _secondQueue = new();

            public void Push(int x)
            {
                _secondQueue.Enqueue(x);

                while (_firstQueue.Count > 0)
                {
                    int number = _firstQueue.Dequeue();
                    _secondQueue.Enqueue(number);
                }

                (_firstQueue, _secondQueue) = (_secondQueue, _firstQueue);
            }

            public int Pop() => _firstQueue.Dequeue();

            public int Top() => _firstQueue.Peek();

            public bool Empty() => _firstQueue.Count == 0;
        }

        private class MyStack0
        {
            private Queue<int> q;
            private int c = 0;

            public MyStack0()
            {
                q = new();
            }

            public void Push(int x)
            {
                if (c > 0)
                {
                    List<int> y = [.. q];
                    y.Add(x);
                    q = new Queue<int>(y);
                }
                else q.Enqueue(x);
                c++;
            }

            public int Pop()
            {
                int t = -1;
                if (c > 0)
                {
                    List<int> y = [.. q];
                    t = y.Last();
                    y.RemoveAt(c - 1);
                    q = new Queue<int>(y);
                    c--;
                }

                return t;
            }

            public int Top()
            {
                return c > 0 ? q.Last() : -1;
            }

            public bool Empty()
            {
                return c == 0;
            }
        }
    }
}
