using Rftim3Atlas.Models;

namespace Rftim3Convoy.Temp.Construct.Maths.Algorithms.Tree
{
    public class RftTreeTraversal
    {
        /// <summary>
        /// Tree traversal:
        /// <para>Pre-order</para>
        /// <para>In-order</para>
        /// <para>Post-order</para>
        /// <para>Recursive/Iterative</para>
        /// <para>Level (BFS)</para>
        /// </summary>
        public RftTreeTraversal()
        {
            #region Asymmetric
            //                1
            //         2            3
            //      4     5            6
            //          7   8        9
            TreeNode0 a8 = new(9);
            TreeNode0 a7 = new(8);
            TreeNode0 a6 = new(7);
            TreeNode0 a5 = new(6, a8);
            TreeNode0 a4 = new(5, a6, a7);
            TreeNode0 a3 = new(4);
            TreeNode0 a2 = new(3, null, a5);
            TreeNode0 a1 = new(2, a3, a4);
            TreeNode0 a0 = new(1, a1, a2);

            Node na8 = new(9);
            Node na7 = new(8, null, null, na8);
            Node na6 = new(7, null, null, na7);
            Node na5 = new(6, na8);
            Node na4 = new(5, na6, na7, na5);
            Node na3 = new(4, null, null, na4);
            Node na2 = new(3, null, na5);
            Node na1 = new(2, na3, na4, na2);
            Node na0 = new(1, na1, na2);
            #endregion

            #region Symmetric - Translational
            //                1
            //         2            2
            //      3     4      3     4
            //   5            5
            TreeNode0 b8 = new(5);
            TreeNode0 b7 = new(5);
            TreeNode0 b6 = new(4);
            TreeNode0 b5 = new(4);
            TreeNode0 b4 = new(3, b8);
            TreeNode0 b3 = new(3, b7);
            TreeNode0 b2 = new(2, b4, b6);
            TreeNode0 b1 = new(2, b3, b5);
            TreeNode0 b0 = new(1, b1, b2);
            #endregion

            #region Symmetric - Mirror
            //                1
            //         2            2
            //      3     4      4     3
            //   5                        5
            TreeNode0 c8 = new(5);
            TreeNode0 c7 = new(5);
            TreeNode0 c6 = new(4);
            TreeNode0 c5 = new(4);
            TreeNode0 c4 = new(3, null, c8);
            TreeNode0 c3 = new(3, c7);
            TreeNode0 c2 = new(2, c6, c4);
            TreeNode0 c1 = new(2, c3, c5);
            TreeNode0 c0 = new(1, c1, c2);
            #endregion

            RftPreOrderTraversal(a0);
            Console.WriteLine("\n\n");

            RftInOrderTraversal(a0);
            Console.WriteLine("\n\n");

            RftPostOrderTraversal(a0);
            Console.WriteLine("\n\n");

            RftLevelOrderTraversal(a0);
            Console.WriteLine("\n\n");

            Console.WriteLine(RftNodesCount(a0));
            Console.WriteLine("\n\n");

            RftMaxDepthBFS(b0);
            Console.WriteLine("\n\n");

            Console.WriteLine(RftIsPathSumEqual(c0, 11));
            Console.WriteLine("\n\n");

            Console.WriteLine(RftIsSymmetricTree(c0));
            Console.WriteLine("\n\n");

            RftBuildTreeInOrderAndPostOrder(
                [9, 3, 15, 20, 7],
                [9, 15, 7, 20, 3]
            );
            Console.WriteLine("\n\n");

            RftBuildTreePreOrderAndInOrder(
                [9, 3, 15, 20, 7],
                [9, 15, 7, 20, 3]
            );
            Console.WriteLine("\n\n");

            RftNextRightPointerInEachNode(na0);
            Console.WriteLine("\n\n");

            RftNextRightPointerInEachNodeABT(na0);
        }

        // 1 -> 2 -> 4 -> 5 -> 7 -> 8 -> 3 -> 6 -> 9
        /// <summary>
        /// Root first, left then right
        /// </summary>
        private static List<int> RftPreOrderTraversal(TreeNode0? root)
        {
            List<int> x = [];
            Stack<TreeNode0?> s = new();
            s.Push(root);

            while (s.Count != 0)
            {
                TreeNode0? c = s.Pop();
                if (c is not null)
                {
                    x.Add(c.val);
                    s.Push(c.right);
                    s.Push(c.left);
                }
            }

            Console.WriteLine("ProOrder");
            foreach (int item in x)
            {
                Console.Write($"{item} ");
            }

            return x;
        }

        // 4 -> 2 -> 7 -> 5 -> 8 -> 1 -> 3 -> 9 -> 6
        /// <summary>
        /// Left-most subtree, root then right
        /// </summary>
        private static List<int> RftInOrderTraversal(TreeNode0? root)
        {
            List<int> x = [];
            Stack<TreeNode0?> s = new();
            TreeNode0? c = root;

            while (c is not null || s.Count != 0)
            {
                while (c is not null)
                {
                    s.Push(c);
                    c = c.left;
                }

                c = s.Pop();
                x.Add(c!.val);
                c = c.right;
            }

            Console.WriteLine("InOrder");
            foreach (int item in x)
            {
                Console.Write($"{item} ");
            }

            return x;
        }

        // 4 -> 7 -> 8 -> 5 -> 2 -> 9 -> 6 -> 3 -> 1 
        /// <summary>
        /// Left-most subtree, right then root
        /// </summary>
        private static List<int> RftPostOrderTraversal(TreeNode0? root)
        {
            if (root is null) return [];

            List<int> x = [];
            Stack<TreeNode0> s = new();

            s.Push(root);

            while (s.Count != 0)
            {
                TreeNode0 node = s.Pop();

                x.Add(node.val);

                if (node.left is not null) s.Push(node.left);
                if (node.right is not null) s.Push(node.right);
            }

            x.Reverse();

            Console.WriteLine("PostOrder");
            foreach (int item in x)
            {
                Console.Write($"{item} ");
            }

            return x;
        }

        // 1 -> 2 -> 3 -> 4 -> 5 -> 6 -> 7 -> 8 -> 9
        private static List<List<int>> RftLevelOrderTraversal(TreeNode0? root)
        {
            if (root is null) return [];
            Queue<TreeNode0> q = new();
            q.Enqueue(root);

            List<List<int>> x = [];
            while (q.Count != 0)
            {
                int n = q.Count;
                List<int> y = [];

                while (n != 0)
                {
                    TreeNode0 c = q.Dequeue();
                    if (c.left is not null) q.Enqueue(c.left);
                    if (c.right is not null) q.Enqueue(c.right);

                    y.Add(c.val);
                    n--;
                }

                x.Add(y);
            }

            Console.WriteLine("LevelOrder");
            foreach (IList<int> item in x)
            {
                foreach (int item1 in item)
                {
                    Console.Write($"{item1} ");
                }
                Console.WriteLine();
            }

            return x;
        }

        /// <summary>
        /// Counting nodes in tree
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        private static int RftNodesCount(TreeNode0 root)
        {
            if (root is null) return 0;

            int r = 0;
            Stack<TreeNode0?> s = new();
            s.Push(root);

            while (s.Count != 0)
            {
                r++;
                TreeNode0? t = s.Pop();

                if (t?.right is not null) s.Push(t?.right);
                if (t?.left is not null) s.Push(t?.left);
            }

            Console.WriteLine("Node Count");

            return r;
        }

        // 1 -> 2 -> 3 -> 4 -> 5 -> 6 -> 7 -> 8 -> 9
        private static int RftMaxDepthBFS(TreeNode0? root)
        {
            if (root is null) return 0;

            int x = 0;
            Queue<TreeNode0> q = new();
            q.Enqueue(root);

            while (q.Count != 0)
            {
                x++;
                int n = q.Count;
                for (int i = 0; i < n; i++)
                {
                    TreeNode0 c = q.Dequeue();

                    if (c.left is not null) q.Enqueue(c.left);
                    if (c.right is not null) q.Enqueue(c.right);
                }
            }

            Console.WriteLine("Max Depth");
            Console.WriteLine(x);

            return x;
        }

        /// <summary>
        /// Check if exists path with sum equal to target
        /// </summary>
        /// <param name="root"></param>
        /// <param name="targetSum"></param>
        /// <returns></returns>
        private static bool RftIsPathSumEqual(TreeNode0 root, int targetSum)
        {
            Console.WriteLine("Path sum equals target");
            if (root is null) return false;

            Stack<(TreeNode0, int)> s = new();
            s.Push((root, root.val));

            while (s.Count != 0)
            {
                (TreeNode0, int) t = s.Pop();
                TreeNode0 node = t.Item1;
                int tSum = t.Item2;

                if (node.right is not null) s.Push((node.right, node.right.val + tSum));
                if (node.left is not null) s.Push((node.left, node.left.val + tSum));

                Console.WriteLine($"{node.val} -> {tSum}");

                if (node.left is null && node.right is null && tSum == targetSum) return true;
            }

            return false;
        }

        // 1 -> 2 -> 2 -> 3 -> 3 -> 5 -> 5 -> 4 -> 4
        /// <summary>
        /// Mirror
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        private static bool RftIsSymmetricTree(TreeNode0 root)
        {
            Console.WriteLine("Symmetric - Mirror");

            return RftIsSymmetric(root.left, root.right);
        }

        /// <summary>
        /// Check if left-most equals right-most
        /// </summary>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        private static bool RftIsSymmetric(TreeNode0? l, TreeNode0? r)
        {
            if (l is null && r is null) return true;
            if (l is null || r is null) return false;
            if (l.val != r.val) return false;

            Console.WriteLine($"{l.val}: {r.val}");

            if (!RftIsSymmetric(l.left, r.right)) return false;
            if (!RftIsSymmetric(l.right, r.left)) return false;

            return true;
        }

        /// <summary>
        /// Building a tree inorder and postorder
        /// </summary>
        /// <param name="inorder"></param>
        /// <param name="postorder"></param>
        /// <returns></returns>
        private static TreeNode0? RftBuildTreeInOrderAndPostOrder(int[] inorder, int[] postorder)
        {
            Console.WriteLine("Build InOrder and PostOrder");
            if (inorder is null || inorder.Length == 0 || postorder is null || postorder.Length == 0) return null;

            return RftBuildInOrderPostOrder(inorder, 0, inorder.Length - 1, postorder, 0, postorder.Length - 1);
        }

        private static TreeNode0? RftBuildInOrderPostOrder(int[] inorder, int i, int j, int[] postorder, int k, int l)
        {
            if (i > j || k > l) return null;

            TreeNode0 node = new(postorder[l]);
            Console.WriteLine($"{node.val}");

            if (k != l)
            {
                int m = 0;

                for (int n = 0; n < inorder.Length; n++)
                {
                    m = n;
                    if (inorder[n] == postorder[l]) break;
                }

                node.left = RftBuildInOrderPostOrder(inorder, i, m - 1, postorder, k, k + m - i - 1);
                node.right = RftBuildInOrderPostOrder(inorder, m + 1, j, postorder, k + m - i, l - 1);
            }

            return node;
        }

        /// <summary>
        /// Building a tree preorder and inorder
        /// </summary>
        /// <param name="preorder"></param>
        /// <param name="inorder"></param>
        /// <returns></returns>
        private static TreeNode0? RftBuildTreePreOrderAndInOrder(int[] preorder, int[] inorder)
        {
            Console.WriteLine("Build PreOrder and InOrder");
            int n = preorder.Length;
            int m = inorder.Length;

            return RftBuildPreOrderInOrder(preorder, 0, n - 1, inorder, 0, m - 1);
        }

        private static TreeNode0? RftBuildPreOrderInOrder(int[] preorder, int i, int j, int[] inorder, int k, int l)
        {
            if (i > j || k > l) return null;

            TreeNode0 node = new(preorder[i]);
            Console.WriteLine(node.val);

            if (i != j)
            {
                int m = k;

                for (; m < inorder.Length; m++)
                {
                    if (inorder[m] == preorder[i]) break;
                }

                node.left = RftBuildPreOrderInOrder(preorder, i + 1, i + m - k, inorder, k, m - 1);
                node.right = RftBuildPreOrderInOrder(preorder, i + 1 + m - k, j, inorder, m + 1, l);
            }

            return node;
        }

        /// <summary>
        /// Check if next right pointer in each node is null
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        private static Node? RftNextRightPointerInEachNode(Node root)
        {
            Console.WriteLine("Next Right Pointer In Each Node");
            if (root is null) return root;

            Queue<Node> q = new();
            q.Enqueue(root);

            while (q.Count != 0)
            {
                int n = q.Count;

                Node? prev = null;
                for (int i = 0; i < n; i++)
                {
                    Node c = q.Dequeue();
                    Console.WriteLine(c.val);
                    if (prev is null) prev = c;
                    else
                    {
                        prev.next = c;
                        prev = c;
                    }

                    if (c.left is not null) q.Enqueue(c.left);
                    if (c.right is not null) q.Enqueue(c.right);
                }
                prev!.next = null;
                Console.WriteLine("null");
            }

            return root;
        }

        /// <summary>
        /// Check if next right pointer in each node is null in an asymmetric binary tree
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        private static Node? RftNextRightPointerInEachNodeABT(Node root)
        {
            Console.WriteLine("Next Right Pointer In Each Node ABT");
            if (root is null) return root;

            Queue<Node> q = new();
            q.Enqueue(root);

            while (q.Count != 0)
            {
                int c = q.Count;

                while (c > 0)
                {
                    Node x = q.Dequeue();
                    Console.WriteLine(x.val);

                    if (c != 1) x.next = q.Peek();
                    if (x.left is not null) q.Enqueue(x.left);
                    if (x.right is not null) q.Enqueue(x.right);

                    c--;
                }
                Console.WriteLine("null");
            }

            return root;
        }
    }
}