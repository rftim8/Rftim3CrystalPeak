using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00285_InorderSuccessorInBST_Test
    {
        // Arrange
        private static readonly int[] a0 = [];
        private static readonly int ar = 0;

        public static TheoryData<int[], int> _00285_InorderSuccessorInBST_Data =>
            new()
            {
                { a0, ar }
            };


        [Theory]
        [MemberData(nameof(_00285_InorderSuccessorInBST_Data))]
        public void InorderSuccessorInBST0(int[] a0, int expected)
        {
            // Act
            int actual = _00285_InorderSuccessorInBST.InorderSuccessorInBST0(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}