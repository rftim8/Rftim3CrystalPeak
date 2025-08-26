using Rftim3Convoy.Temp.Construct.Trees;
using Rftim3LeetCode.Temp;
using Rftim3Atlas.Models;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00250_CountUnivalueSubtrees_Test
    {
        // Arrange
        private static readonly int?[] a0 = [5, 1, 5, 5, 5, null, 5];
        private static readonly int ar = 4;

        public static TheoryData<int?[], int> _00250_CountUnivalueSubtrees_Data =>
            new()
            {
                { a0, ar }
            };


        [Theory]
        [MemberData(nameof(_00250_CountUnivalueSubtrees_Data))]
        public void CountUnivalueSubtrees0(int?[] a0, int expected)
        {
            TreeNode? a1 = RftTreeNodesBuilder.RftCreateListOfBinaryNullableTreeNodes(a0);

            // Act
            int actual = _00250_CountUnivalueSubtrees.CountUnivalueSubtrees0(a1);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}