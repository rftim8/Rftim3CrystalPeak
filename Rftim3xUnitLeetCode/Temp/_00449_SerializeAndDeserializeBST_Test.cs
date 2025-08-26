using Rftim3Convoy.Temp.Construct.Trees;
using Rftim3LeetCode.Temp;
using Rftim3Atlas.Models;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00449_SerializeAndDeserializeBST_Test
    {
        // Arrange
        private static readonly int?[] a0 = [2, 1, 3];
        private static readonly List<int?> ar = [2, 3, 1];

        public static TheoryData<int?[], List<int?>> _00449_SerializeAndDeserializeBST_Data =>
            new()
            {
                { a0, ar }
            };


        [Theory]
        [MemberData(nameof(_00449_SerializeAndDeserializeBST_Data))]
        public void SerializeAndDeserializeBST0(int?[] a0, List<int?> expected)
        {
            TreeNode? t = RftTreeNodesBuilder.RftCreateListOfBinaryNullableTreeNodes(a0);

            // Act
            List<int?> actual = _00449_SerializeAndDeserializeBST.SerializeAndDeserializeBST0(t);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}