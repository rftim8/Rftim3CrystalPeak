using Rftim3Convoy.Temp.Construct.Terminal;
using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _00637_AverageOfLevelsInBinaryTree
    {
        /// <summary>
        /// Given the root of a binary tree, return the average value of the nodes on each level in the form of an array. 
        /// Answers within 10-5 of the actual answer will be accepted.
        /// </summary>
        public _00637_AverageOfLevelsInBinaryTree()
        {
            TreeNode0 a4 = new(7);
            TreeNode0 a3 = new(15);
            TreeNode0 a2 = new(20, a3, a4);
            TreeNode0 a1 = new(9);
            TreeNode0 a0 = new(3, a1, a2);

            IList<double> x = AverageOfLevels(a0);

            RftTerminal.RftReadResult(x);
        }

        private static List<double> AverageOfLevels(TreeNode0? root)
        {
            if (root is null) return [];

            List<double> r = [];
            Queue<TreeNode0> q = new();
            q.Enqueue(root);

            while (q.Count != 0)
            {
                int n = q.Count;
                List<double> y = [];

                while (n != 0)
                {
                    TreeNode0 c = q.Dequeue();
                    if (c.left is not null) q.Enqueue(c.left);
                    if (c.right is not null) q.Enqueue(c.right);

                    y.Add(c.val);
                    n--;
                }

                r.Add(y.Sum() / y.Count);
            }

            return r;
        }

        private static List<double> AverageOfLevels0(TreeNode0? root)
        {
            List<double> answers = [];
            if (root is null) return answers;

            Queue<TreeNode0> queue = new();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                int count = queue.Count;
                double sum = 0.0;

                for (int i = 0; i < count; i++)
                {
                    TreeNode0 node = queue.Dequeue();
                    sum += node.val;

                    if (node.left is not null) queue.Enqueue(node.left);
                    if (node.right is not null) queue.Enqueue(node.right);
                }

                answers.Add(sum / count);
            }

            return answers;
        }
    }
}
