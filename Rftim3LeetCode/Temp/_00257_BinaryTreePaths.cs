using Rftim3Convoy.Temp.Construct.Terminal;
using Rftim3Convoy.Temp.Construct.Trees;
using Rftim3Atlas.Models;
using System.Text;

namespace Rftim3LeetCode.Temp
{
    public class _00257_BinaryTreePaths
    {
        /// <summary>
        /// Given the root of a binary tree, return all root-to-leaf paths in any order.
        /// A leaf is a node with no children.
        /// </summary>
        public _00257_BinaryTreePaths()
        {
            int[] a0 = [1, 2, 3, 0, 5];
            TreeNode0? l0 = RftTreeNodesBuilder.RftCreateListOfBinaryTreeNodes(a0);

            IList<string> x = BinaryTreePaths0(l0);
            RftTerminal.RftReadResult(x);
        }

        public static IList<string> BinaryTreePaths0(TreeNode0? a0) => RftBinaryTreePaths0(a0);

        private static List<string> RftBinaryTreePaths0(TreeNode0? root)
        {
            List<string> r = [];
            if (root?.left is null && root?.right is null)
            {
                r.Add($"{root?.val}");

                return r;
            }

            Stack<TreeNode0?> s = new();
            s.Push(root);

            List<List<TreeNode0>> l = [[root]];

            while (s.Count != 0)
            {
                TreeNode0? node = s.Pop();

                List<TreeNode0> temp = [];

                int e = -1;
                for (int i = 0; i < l.Count; i++)
                {
                    if (l[i].Last() == node)
                    {
                        temp = [.. l[i]];
                        e = i;
                    }
                }
                if (e != -1) l.RemoveAt(e);

                if (node?.left is not null)
                {
                    s.Push(node.left);
                    List<TreeNode0> a = [.. temp];
                    a.Add(node.left);
                    l.Add(a);
                }

                if (node?.right is not null)
                {
                    s.Push(node.right);
                    List<TreeNode0> a = [.. temp];
                    a.Add(node.right);
                    l.Add(a);
                }

                if (node?.left is null && node?.right is null)
                {
                    StringBuilder sb = new();
                    foreach (TreeNode0 item in temp)
                    {
                        sb.Append($"{item.val}->");
                    }

                    r.Add(sb.ToString()[..^2]);
                }
            }

            return r;
        }
    }
}
