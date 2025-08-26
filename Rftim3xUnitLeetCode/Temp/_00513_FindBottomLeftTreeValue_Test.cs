using Rftim3Convoy.Temp.Construct.Trees;
using Rftim3LeetCode.Temp;
using Rftim3Atlas.Models;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00513_FindBottomLeftTreeValue_Test
    {
        // Arrange
        private static readonly int?[] a0 = [2, 1, 3];
        private static readonly int ar = 1;

        private static readonly int?[] b0 = [1, 2, 3, 4, null, 5, 6, null, null, 7];
        private static readonly int br = 7;

        public static TheoryData<int?[], int> _00513_FindBottomLeftTreeValue_Data =>
            new()
            {
                { a0, ar },
                { b0, br }
            };


        [Theory]
        [MemberData(nameof(_00513_FindBottomLeftTreeValue_Data))]
        public void FindBottomLeftTreeValue0(int?[] a0, int expected)
        {
            // Arrange
            TreeNode? a1 = RftTreeNodesBuilder.RftCreateListOfBinaryNullableTreeNodes(a0);

            // Act
            int actual = _00513_FindBottomLeftTreeValue.FindBottomLeftTreeValue0(a1);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00513_FindBottomLeftTreeValue_Data))]
        public void FindBottomLeftTreeValue1(int?[] a0, int expected)
        {
            // Arrange
            TreeNode? a1 = RftTreeNodesBuilder.RftCreateListOfBinaryNullableTreeNodes(a0);

            // Act
            int actual = _00513_FindBottomLeftTreeValue.FindBottomLeftTreeValue1(a1);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}