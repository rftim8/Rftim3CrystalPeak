using Rftim3Convoy.Temp.Construct.Terminal;
using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _00113_PathSum2
    {
        /// <summary>
        /// Given the root of a binary tree and an integer targetSum, return all root-to-leaf paths where the sum of the node values in the path equals targetSum. 
        /// Each path should be returned as a list of the node values, not node references.
        /// A root-to-leaf path is a path starting from the root and ending at any leaf node.A leaf is a node with no children.
        /// </summary>
        public _00113_PathSum2()
        {
            TreeNode0 a9 = new(1, null, null);
            TreeNode0 a8 = new(5, null, null);
            TreeNode0 a7 = new(2, null, null);
            TreeNode0 a6 = new(7, null, null);
            TreeNode0 a5 = new(4, a8, a9);
            TreeNode0 a4 = new(13, null, null);
            TreeNode0 a3 = new(11, a6, a7);
            TreeNode0 a2 = new(8, a4, a5);
            TreeNode0 a1 = new(4, a3, null);
            TreeNode0 a0 = new(5, a1, a2);

            IList<IList<int>> x = PathSum(a0, 22);

            RftTerminal.RftReadResult(x);
        }

        private static List<IList<int>> PathSum(TreeNode0 root, int targetSum)
        {
            List<IList<int>> x = [];
            if (root is null) return x;

            Dfs(root, targetSum, [], x);

            return x;
        }

        private static void Dfs(TreeNode0? root, int target, List<int> list, List<IList<int>> x)
        {
            if (root is null) return;

            list.Add(root.val);
            if (root.val == target && root.left is null && root.right is null)
            {
                x.Add(new List<int>(list));
            }

            Dfs(root.left, target - root.val, list, x);
            Dfs(root.right, target - root.val, list, x);

            list.RemoveAt(list.Count - 1);
        }
    }
}
