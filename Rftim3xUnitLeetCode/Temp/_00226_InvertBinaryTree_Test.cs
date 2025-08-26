using Rftim3Convoy.Temp.Construct.Trees;
using Rftim3LeetCode.Temp;
using Rftim3Atlas.Models;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00226_InvertBinaryTree_Test
    {
        // Arrange
        private static readonly int[] a0 = [4, 2, 7, 1, 3, 6, 9];
        private static readonly int[] ar = [4, 7, 2, 9, 6, 3, 1];

        private static readonly int[] b0 = [2, 1, 3];
        private static readonly int[] br = [2, 3, 1];

        private static readonly int[] c0 = [];
        private static readonly int[] cr = [];

        public static TheoryData<int[], int[]> _00226_InvertBinaryTree_Data =>
            new()
            {
                { a0, ar },
                { b0, br },
                { c0, cr }
            };

        [Theory]
        [MemberData(nameof(_00226_InvertBinaryTree_Data))]
        public void InvertTree(int[] list0, int[] expected)
        {
            // Arrange
            TreeNode0? l0 = RftTreeNodesBuilder.RftCreateListOfBinaryTreeNodes(list0);

            // Act
            TreeNode0? root = _00226_InvertBinaryTree.InvertTree0(l0);

            List<int> r = [];
            Queue<TreeNode0?> q = new();
            q.Enqueue(root);

            while (q.Count != 0)
            {
                int n = q.Count;

                while (n != 0)
                {
                    TreeNode0? c = q.Dequeue();
                    if (c is not null) r.Add(c.val);

                    if (c?.left is not null) q.Enqueue(c.left);
                    if (c?.right is not null) q.Enqueue(c.right);
                    n--;
                }
            }
            int[] actual = [.. r];

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
