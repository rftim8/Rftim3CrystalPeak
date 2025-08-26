using Rftim3Atlas.Models;

namespace Rftim3Convoy.Temp.Construct.Trees
{
    public class RftTreeNodesBuilder
    {
        public static TreeNode0? RftCreateListOfBinaryTreeNodes(int[] a)
        {
            if (a is null || a.Length == 0) return null;

            Queue<TreeNode0> queue = new();
            TreeNode0 root = new(a[0]);
            queue.Enqueue(root);

            for (int i = 1; i < a.Length; i += 2)
            {
                TreeNode0 parent = queue.Dequeue();

                if (a[i] != 0)
                {
                    parent.left = new TreeNode0(a[i]);
                    queue.Enqueue(parent.left);
                }

                if (i + 1 < a.Length && a[i + 1] != 0)
                {
                    parent.right = new TreeNode0(a[i + 1]);
                    queue.Enqueue(parent.right);
                }
            }

            return root;
        }

        public static TreeNode? RftCreateListOfBinaryNullableTreeNodes(int?[] a)
        {
            if (a is null || a.Length == 0) return null;

            Queue<TreeNode> queue = new();
            TreeNode root = new(a[0]);
            queue.Enqueue(root);

            for (int i = 1; i < a.Length; i += 2)
            {
                TreeNode parent = queue.Dequeue();

                if (a[i] != 0)
                {
                    parent.left = new TreeNode(a[i]);
                    queue.Enqueue(parent.left);
                }

                if (i + 1 < a.Length && a[i + 1] != 0)
                {
                    parent.right = new TreeNode(a[i + 1]);
                    queue.Enqueue(parent.right);
                }
            }

            return root;
        }
    }
}
