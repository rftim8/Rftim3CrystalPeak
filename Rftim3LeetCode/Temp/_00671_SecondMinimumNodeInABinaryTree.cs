using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _00671_SecondMinimumNodeInABinaryTree
    {
        /// <summary>
        /// Given a non-empty special binary tree consisting of nodes with the non-negative value, where each node in this tree has exactly two or zero sub-node. 
        /// If the node has two sub-nodes, then this node's value is the smaller value among its two sub-nodes. 
        /// More formally, the property root.val = min(root.left.val, root.right.val) always holds.
        /// Given such a binary tree, you need to output the second minimum value in the set made of all the nodes' value in the whole tree.
        /// If no such second minimum value exists, output -1 instead.
        /// </summary>
        public _00671_SecondMinimumNodeInABinaryTree()
        {
            TreeNode0 a4 = new(7);
            TreeNode0 a3 = new(5);
            TreeNode0 a2 = new(5, a3, a4);
            TreeNode0 a1 = new(2);
            TreeNode0 a0 = new(2, a1, a2);

            Console.WriteLine(FindSecondMinimumValue(a0));
        }

        private static int FindSecondMinimumValue(TreeNode0 root)
        {
            Stack<TreeNode0> s = new();
            s.Push(root);
            List<int> r = [];

            while (s.Count != 0)
            {
                TreeNode0 t = s.Pop();

                if (!r.Contains(t.val)) r.Add(t.val);

                if (t.left is not null) s.Push(t.left);
                if (t.right is not null) s.Push(t.right);
            }
            r.Sort();

            return r.Count > 1 ? r[1] : -1;
        }
    }
}
