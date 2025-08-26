using Rftim3LeetCode.Temp;
using Rftim3Atlas.Models;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00108_ConvertSortedArrayToBinarySearchTree_Test
    {
        // Arrange
        private static readonly int[] a0 = [-10, -3, 0, 5, 9];
        private static readonly int[] ar = [0, -3, 9, -10, 5];

        private static readonly int[] b0 = [1, 3];
        private static readonly int[] br = [3, 1];


        public static TheoryData<int[], int[]> _00108_ConvertSortedArrayToBinarySearchTree_Data =>
            new()
            {
                { a0, ar },
                { b0, br }
            };


        [Theory]
        [MemberData(nameof(_00108_ConvertSortedArrayToBinarySearchTree_Data))]
        public void ConvertSortedArrayToBinarySearchTree0(int[] a0, int[] expected)
        {
            // Act
            TreeNode0? ln = _00108_ConvertSortedArrayToBinarySearchTree.ConvertSortedArrayToBinarySearchTree0(a0);

            // Assert
            if (ln is null) Assert.Equal(expected, []);
            else
            {
                List<int> r = [];

                Queue<TreeNode0> q = new();
                q.Enqueue(ln);

                while (q.Count != 0)
                {
                    int n = q.Count;
                    for (int i = 0; i < n; i++)
                    {
                        TreeNode0 c = q.Dequeue();
                        r.Add(c.val);

                        if (c.left is not null) q.Enqueue(c.left);
                        if (c.right is not null) q.Enqueue(c.right);
                    }
                }

                int[] actual = [.. r];

                Assert.Equal(expected, actual);
            }
        }
    }
}