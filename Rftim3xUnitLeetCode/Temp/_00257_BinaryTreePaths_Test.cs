using Rftim3Convoy.Temp.Construct.Trees;
using Rftim3LeetCode.Temp;
using Rftim3Atlas.Models;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00257_BinaryTreePaths_Test
    {
        // Arrange
        private static readonly int[] a0 = [1, 2, 3, 0, 5];
        private static readonly string[] ar = ["1->2->5", "1->3"];

        private static readonly int[] b0 = [1];
        private static readonly string[] br = ["1"];

        public static TheoryData<int[], string[]> _00257_BinaryTreePaths_Data =>
            new()
            {
                { a0, ar },
                { b0, br }
            };

        [Theory]
        [MemberData(nameof(_00257_BinaryTreePaths_Data))]
        public void BinaryTreePaths0(int[] list0, string[] expected)
        {
            // Arrange
            TreeNode0? l0 = RftTreeNodesBuilder.RftCreateListOfBinaryTreeNodes(list0);

            // Act
            IList<string> actual = _00257_BinaryTreePaths.BinaryTreePaths0(l0);

            // Assert
            Assert.Equivalent(expected, actual, true);
        }
    }
}
