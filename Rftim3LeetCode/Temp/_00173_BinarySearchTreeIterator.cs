using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _00173_BinarySearchTreeIterator
    {
        /// <summary>
        /// Implement the BSTIterator class that represents an iterator over the in-order traversal of a binary search tree (BST):
        /// BSTIterator(TreeNode root) Initializes an object of the BSTIterator class. The root of the BST is given as part of the constructor.
        /// The pointer should be initialized to a non-existent number smaller than any element in the BST.
        /// boolean hasNext() Returns true if there exists a number in the traversal to the right of the pointer, otherwise returns false.
        /// int next() Moves the pointer to the right, then returns the number at the pointer.
        /// Notice that by initializing the pointer to a non-existent smallest number, the first call to next() will return the smallest element in the BST.
        /// You may assume that next() calls will always be valid. That is, there will be at least a next number in the in-order traversal when next() is called.
        /// </summary>
        public _00173_BinarySearchTreeIterator()
        {
            TreeNode0 a4 = new(20);
            TreeNode0 a3 = new(9);
            TreeNode0 a2 = new(15, a3, a4);
            TreeNode0 a1 = new(3);
            TreeNode0 a0 = new(7, a1, a2);

            BSTIterator obj = new(a0);
            int param_1 = obj.Next();
            bool param_2 = obj.HasNext();

            Console.WriteLine(param_1);
            Console.WriteLine(param_2);
        }

        private class BSTIterator
        {
            private readonly Stack<TreeNode0> s = new();

            public BSTIterator(TreeNode0 root)
            {
                if (root is not null) Dfs(root);
            }

            public int Next()
            {
                if (!HasNext()) return int.MinValue;

                TreeNode0 crt = s.Pop();

                if (crt.right is not null) Dfs(crt.right);

                return crt.val;
            }

            public bool HasNext()
            {
                return s.Count != 0;
            }

            private void Dfs(TreeNode0 node)
            {
                TreeNode0? crt = node;

                while (crt != null)
                {
                    s.Push(crt);
                    crt = crt.left;
                }
            }
        }

        private class BSTIterator0
        {
            private readonly Stack<TreeNode0> _stack;

            public BSTIterator0(TreeNode0 root)
            {
                _stack = new Stack<TreeNode0>();
                Min(root, _stack);
            }

            public int Next()
            {
                TreeNode0 node = _stack.Pop();
                int result = node.val;

                if (node.right is not null) Min(node.right, _stack);

                return result;
            }

            public bool HasNext() => _stack.Count > 0;

            private static void Min(TreeNode0 root, Stack<TreeNode0> stack)
            {
                stack.Push(root);
                while (root.left != null)
                {
                    root = root.left;
                    stack.Push(root);
                }
            }
        }
    }
}
