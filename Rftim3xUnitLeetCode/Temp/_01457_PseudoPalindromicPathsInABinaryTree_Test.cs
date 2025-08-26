using Rftim3Convoy.Temp.Construct.Trees;
using Rftim3LeetCode.Temp;
using Rftim3Atlas.Models;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _01457_PseudoPalindromicPathsInABinaryTree_Test
    {
        // Arrange
        private static readonly int[] a0 = [2, 3, 1, 3, 1, 0, 1];
        private static readonly int ar = 2;

        private static readonly int[] b0 = [2, 1, 1, 1, 3, 0, 0, 0, 0, 0, 1];
        private static readonly int br = 1;

        private static readonly int[] c0 = [9];
        private static readonly int cr = 1;

        public static TheoryData<int[], int> _01457_PseudoPalindromicPathsInABinaryTree_Data =>
            new()
            {
                { a0, ar },
                { b0, br },
                { c0, cr }
            };

        [Theory]
        [MemberData(nameof(_01457_PseudoPalindromicPathsInABinaryTree_Data))]
        public void PseudoPalindromicPaths0(int[] a0, int expected)
        {
            // Arrange
            TreeNode0? l0 = RftTreeNodesBuilder.RftCreateListOfBinaryTreeNodes(a0);

            // Act
            int ln = _01457_PseudoPalindromicPathsInABinaryTree.PseudoPalindromicPaths0(l0);

            // Assert
            //Assert.Equal(expected, ln);
        }

        [Theory]
        [MemberData(nameof(_01457_PseudoPalindromicPathsInABinaryTree_Data))]
        public void PseudoPalindromicPaths1(int[] a0, int expected)
        {
            // Arrange
            TreeNode0? l0 = RftTreeNodesBuilder.RftCreateListOfBinaryTreeNodes(a0);

            // Act
            int ln = _01457_PseudoPalindromicPathsInABinaryTree.PseudoPalindromicPaths1(l0);

            // Assert
            //Assert.Equal(expected, ln);
        }

        [Theory]
        [MemberData(nameof(_01457_PseudoPalindromicPathsInABinaryTree_Data))]
        public void PseudoPalindromicPaths2(int[] a0, int expected)
        {
            // Arrange
            TreeNode0? l0 = RftTreeNodesBuilder.RftCreateListOfBinaryTreeNodes(a0);

            // Act
            int ln = _01457_PseudoPalindromicPathsInABinaryTree.PseudoPalindromicPaths2(l0);

            // Assert
            //Assert.Equal(expected, ln);
        }
    }
}
