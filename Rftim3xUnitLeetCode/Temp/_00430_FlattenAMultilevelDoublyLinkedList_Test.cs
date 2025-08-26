using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00430_FlattenAMultilevelDoublyLinkedList_Test
    {
        // Arrange
        private static readonly int[] a0 = [];
        private static readonly int ar = 0;

        public static TheoryData<int[], int> _00430_FlattenAMultilevelDoublyLinkedList_Data =>
            new()
            {
                { a0, ar }
            };


        [Theory]
        [MemberData(nameof(_00430_FlattenAMultilevelDoublyLinkedList_Data))]
        public void FlattenAMultilevelDoublyLinkedList0(int[] a0, int expected)
        {
            // Act
            int actual = _00430_FlattenAMultilevelDoublyLinkedList.FlattenAMultilevelDoublyLinkedList0(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}