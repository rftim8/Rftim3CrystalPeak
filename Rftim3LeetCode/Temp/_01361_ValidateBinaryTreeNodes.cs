namespace Rftim3LeetCode.Temp
{
    public class _01361_ValidateBinaryTreeNodes
    {
        /// <summary>
        /// You have n binary tree nodes numbered from 0 to n - 1 where node i has two children leftChild[i] and rightChild[i], 
        /// return true if and only if all the given nodes form exactly one valid binary tree.
        /// If node i has no left child then leftChild[i] will equal -1, similarly for the right child.
        /// Note that the nodes have no values and that we only use the node numbers in this problem.
        /// </summary>
        public _01361_ValidateBinaryTreeNodes()
        {
            Console.WriteLine(ValidateBinaryTreeNodes(4, [1, -1, 3, -1], [2, -1, -1, -1]));
            Console.WriteLine(ValidateBinaryTreeNodes(4, [1, -1, 3, -1], [2, 3, -1, -1]));
            Console.WriteLine(ValidateBinaryTreeNodes(2, [1, 0], [-1, -1]));
        }

        // DFS
        private static bool ValidateBinaryTreeNodes(int n, int[] leftChild, int[] rightChild)
        {
            int root = FindRoot(n, leftChild, rightChild);
            if (root == -1) return false;

            HashSet<int> seen = [];
            Stack<int> stack = new();
            seen.Add(root);
            stack.Push(root);

            while (stack.Count != 0)
            {
                int node = stack.Pop();
                int[] children = [leftChild[node], rightChild[node]];

                foreach (int child in children)
                {
                    if (child != -1)
                    {
                        if (seen.Contains(child)) return false;

                        stack.Push(child);
                        seen.Add(child);
                    }
                }
            }

            return seen.Count == n;
        }
        private static int FindRoot(int n, int[] left, int[] right)
        {
            HashSet<int> children = [.. left, .. right];

            for (int i = 0; i < n; i++)
            {
                if (!children.Contains(i)) return i;
            }

            return -1;
        }

        // BFS
        [System.Diagnostics.CodeAnalysis.SuppressMessage("CodeQuality", "IDE0051:Remove unused private members", Justification = "<Pending>")]
        private static bool ValidateBinaryTreeNodes0(int n, int[] leftChild, int[] rightChild)
        {
            int root = FindRoot0(n, leftChild, rightChild);
            if (root == -1) return false;

            HashSet<int> seen = [];
            Queue<int> queue = new();
            seen.Add(root);
            queue.Enqueue(root);

            while (queue.Count != 0)
            {
                int node = queue.Dequeue();
                int[] children = [leftChild[node], rightChild[node]];

                foreach (int child in children)
                {
                    if (child != -1)
                    {
                        if (seen.Contains(child)) return false;

                        queue.Enqueue(child);
                        seen.Add(child);
                    }
                }
            }

            return seen.Count == n;
        }
        private static int FindRoot0(int n, int[] left, int[] right)
        {
            HashSet<int> children = [.. left, .. right];

            for (int i = 0; i < n; i++)
            {
                if (!children.Contains(i)) return i;
            }

            return -1;
        }

        // Union Find
        [System.Diagnostics.CodeAnalysis.SuppressMessage("CodeQuality", "IDE0051:Remove unused private members", Justification = "<Pending>")]
        private static bool ValidateBinaryTreeNodes1(int n, int[] leftChild, int[] rightChild)
        {
            UnionFind uf = new(n);
            for (int node = 0; node < n; node++)
            {
                int[] children = [leftChild[node], rightChild[node]];
                foreach (int child in children)
                {
                    if (child == -1) continue;

                    if (!uf.Union(node, child)) return false;
                }
            }

            return uf.components == 1;
        }
        private class UnionFind
        {
            private readonly int[] parents;
            public int components;

            public UnionFind(int n)
            {
                parents = new int[n];
                components = n;

                for (int i = 0; i < n; i++)
                {
                    parents[i] = i;
                }
            }

            public bool Union(int parent, int child)
            {
                int parentParent = Find(parent);
                int childParent = Find(child);

                if (childParent != child || parentParent == childParent) return false;

                components--;
                parents[childParent] = parentParent;
                return true;
            }

            private int Find(int node)
            {
                if (parents[node] != node) parents[node] = Find(parents[node]);

                return parents[node];
            }
        }

        // DFS
        private static bool ValidateBinaryTreeNodes2(int n, int[] leftChild, int[] rightChild)
        {
            int[] ind = new int[n];
            for (int i = 0; i < n; i++)
            {
                int l = leftChild[i], r = rightChild[i];

                if (l > -1) ind[l]++;
                if (r > -1) ind[r]++;

                if (l > -1 && ind[l] > 1 || r > -1 && ind[r] > 1) return false;
            }

            if (ind.Count(i => i == 0) != 1) return false;

            int root = Array.IndexOf(ind, 0);

            int cnt = dfsCount(root);
            return cnt == n;

            int dfsCount(int i)
            {
                if (i == -1) return 0;
                return 1 + dfsCount(leftChild[i]) + dfsCount(rightChild[i]);
            }
        }
    }
}
