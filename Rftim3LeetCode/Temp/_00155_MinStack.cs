namespace Rftim3LeetCode.Temp
{
    public class _00155_MinStack
    {
        /// <summary>
        /// Design a stack that supports push, pop, top, and retrieving the minimum element in constant time.
        /// Implement the MinStack class:
        /// MinStack() initializes the stack object.
        /// void push(int val) pushes the element val onto the stack.
        /// void pop() removes the element on the top of the stack.
        /// int top() gets the top element of the stack.
        /// int getMin() retrieves the minimum element in the stack.
        /// You must implement a solution with O(1) time complexity for each function.
        /// </summary>
        public _00155_MinStack()
        {
            MinStack obj = new();
            obj.Push(-2);
            obj.Push(0);
            obj.Push(-3);
            int param_1 = obj.GetMin();
            Console.WriteLine(param_1);
            obj.Pop();
            int param_2 = obj.Top();
            Console.WriteLine(param_2);
            int param_3 = obj.GetMin();
            Console.WriteLine(param_3);
        }

        public class MinStack
        {
            public Stack<(int, int)> stack = new();

            public MinStack()
            {

            }

            public void Push(int x)
            {
                stack.Push((x, stack.Count == 0 ? x : stack.Peek().Item2 > x ? x : stack.Peek().Item2));
            }

            public void Pop()
            {
                stack.Pop();
            }

            public int Top()
            {
                return stack.Peek().Item1;
            }

            public int GetMin()
            {
                return stack.Peek().Item2;
            }
        }
    }
}
