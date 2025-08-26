namespace Rftim3LeetCode.Temp
{
    public class _01026_MaximumDifferenceBetweenNodeAndAncestor
    {
        public _01026_MaximumDifferenceBetweenNodeAndAncestor()
        {
            TreeNode? x0 = RftCreateListOfBinaryTreeNodes([8, 3, 10, 1, 6, null, 14, null, null, 4, 7, 13]);
            Console.WriteLine(MaxAncestorDiff1(x0));

            TreeNode? x1 = RftCreateListOfBinaryTreeNodes([1, null, 2, null, 0, 3]);
            Console.WriteLine(MaxAncestorDiff1(x1));
        }

        public static int MaxAncestorDiff0(TreeNode? a0) => RftMaxAncestorDiff0(a0);

        public static int MaxAncestorDiff1(TreeNode? a0) => RftMaxAncestorDiff1(a0);

        private static int RftMaxAncestorDiff0(TreeNode? root)
        {
            if (root == null) return -1;

            return Math.Max(DFS(root, root), Math.Max(RftMaxAncestorDiff0(root.left), RftMaxAncestorDiff0(root.right)));
        }

        private static int DFS(TreeNode root, TreeNode? node)
        {
            if (node == null) return 0;

            return Math.Max(Math.Abs((root.val ?? 0) - (node.val ?? 0)), Math.Max(DFS(root, node.left), DFS(root, node.right)));
        }

        private static int result = 0;

        private static int RftMaxAncestorDiff1(TreeNode? root)
        {
            result = 0;
            if (root == null) return result;

            RftFindMaxAncestorDiff1(root, root.val, root.val);

            return result;
        }

        private static void RftFindMaxAncestorDiff1(TreeNode? root, int? min, int? max)
        {
            if (root == null) return;

            min = Math.Min((byte)min!, (byte)root.val!);
            max = Math.Max((byte)max!, (byte)root.val);
            result = (int)Math.Max(Math.Abs((decimal)(max - min)), result);

            RftFindMaxAncestorDiff1(root.left, min, max);
            RftFindMaxAncestorDiff1(root.right, min, max);

            return;
        }

        public class TreeNode(int? val = 0, TreeNode? left = null, TreeNode? right = null)
        {
            public int? val = val;
            public TreeNode? left = left;
            public TreeNode? right = right;
        }

        public static TreeNode? RftCreateListOfBinaryTreeNodes(int?[] a)
        {
            if (a is null || a.Length == 0) return null;

            Queue<TreeNode> queue = new();
            TreeNode root = new(a[0]);
            queue.Enqueue(root);

            for (int i = 1; i < a.Length; i += 2)
            {
                TreeNode parent = queue.Dequeue();

                if (a[i] is not null)
                {
                    parent.left = new TreeNode(a[i]);
                    queue.Enqueue(parent.left);
                }

                if (i + 1 < a.Length && a[i + 1] is not null)
                {
                    parent.right = new TreeNode(a[i + 1]);
                    queue.Enqueue(parent.right);
                }
            }

            return root;
        }
    }
}
