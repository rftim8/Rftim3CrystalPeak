using Rftim3Convoy.Temp.Construct.Terminal;
using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _00894_AllPossibleFullBinaryTrees
    {
        /// <summary>
        /// Given an integer n, return a list of all possible full binary trees with n nodes. 
        /// Each node of each tree in the answer must have Node.val == 0.
        /// Each element of the answer is the root node of one possible tree.
        /// You may return the final list of trees in any order.
        /// A full binary tree is a binary tree where each node has exactly 0 or 2 children.
        /// </summary>
        public _00894_AllPossibleFullBinaryTrees()
        {
            IList<TreeNode0> x = AllPossibleFBT(7);
            IList<TreeNode0> y = AllPossibleFBT(3);

            RftTerminal.RftReadResult(x);
            RftTerminal.RftReadResult(y);
        }

        // Iterative DP
        private static List<TreeNode0> AllPossibleFBT(int n)
        {
            if (n % 2 == 0) return [];

            List<List<TreeNode0>> dp = [];
            for (int i = 0; i <= n; i++)
            {
                dp.Add([]);
            }

            dp[1].Add(new TreeNode0(0));
            for (int count = 3; count <= n; count += 2)
            {
                for (int i = 1; i < count - 1; i += 2)
                {
                    int j = count - 1 - i;
                    foreach (TreeNode0 left in dp[i])
                    {
                        foreach (TreeNode0 right in dp[j])
                        {
                            TreeNode0 root = new(0, left, right);
                            dp[count].Add(root);
                        }
                    }
                }
            }

            return dp[n];
        }

        // Top-down DP: Recursion + Memoization
        private static readonly Dictionary<int, List<TreeNode0>> memo = [];

        private static IList<TreeNode0> AllPossibleFBT0(int n)
        {
            if (n % 2 == 0) return [];

            if (n == 1) return [new TreeNode0()];

            if (memo.TryGetValue(n, out List<TreeNode0>? value)) return value;

            List<TreeNode0> res = [];
            for (int i = 1; i < n; i += 2)
            {
                IList<TreeNode0> left = AllPossibleFBT(i);
                IList<TreeNode0> right = AllPossibleFBT(n - i - 1);

                foreach (TreeNode0 l in left)
                {
                    foreach (TreeNode0 r in right)
                    {
                        TreeNode0 root = new(0, l, r);
                        res.Add(root);
                    }
                }
            }

            memo.Add(n, res);

            return res;
        }
    }
}
