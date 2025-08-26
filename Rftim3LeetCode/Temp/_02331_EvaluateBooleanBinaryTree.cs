using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _02331_EvaluateBooleanBinaryTree
    {
        /// <summary>
        /// You are given the root of a full binary tree with the following properties:
        /// Leaf nodes have either the value 0 or 1, where 0 represents False and 1 represents True.
        /// Non-leaf nodes have either the value 2 or 3, where 2 represents the boolean OR and 3 represents the boolean AND.
        /// The evaluation of a node is as follows:
        /// If the node is a leaf node, the evaluation is the value of the node, i.e.True or False.
        /// Otherwise, evaluate the node's two children and apply the boolean operation of its value with the children's evaluations.
        /// Return the boolean result of evaluating the root node.
        /// A full binary tree is a binary tree where each node has either 0 or 2 children.
        /// A leaf node is a node that has zero children.
        /// </summary>
        public _02331_EvaluateBooleanBinaryTree()
        {
            TreeNode0 a4 = new(1);
            TreeNode0 a3 = new(0);
            TreeNode0 a2 = new(3, a3, a4);
            TreeNode0 a1 = new(1);
            TreeNode0 a0 = new(2, a1, a2);

            Console.WriteLine(EvaluateTree0(a0));
        }

        private static bool EvaluateTree(TreeNode0? root)
        {
            if (root?.left is null && root?.right is null) return root?.val == 1;

            bool l = EvaluateTree(root.left),
                 r = EvaluateTree(root.right);

            return root.val == 2 ? l || r : l && r;
        }

        private static bool EvaluateTree0(TreeNode0? node) => node?.val switch
        {
            0 => false,
            1 => true,
            2 => EvaluateTree0(node.left) || EvaluateTree0(node.right),
            3 => EvaluateTree0(node.left) && EvaluateTree0(node.right),
            _ => throw new NotImplementedException(),
        };
    }
}
