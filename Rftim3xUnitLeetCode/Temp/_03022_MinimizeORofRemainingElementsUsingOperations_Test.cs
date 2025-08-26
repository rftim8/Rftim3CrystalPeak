using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _03022_MinimizeORofRemainingElementsUsingOperations_Test
    {
        // Arrange
        private static readonly int[] a0 = [];
        private static readonly int ar = 0;

        public static TheoryData<int[], int> _03022_MinimizeORofRemainingElementsUsingOperations_Data =>
            new()
            {
                { a0, ar }
            };


        [Theory]
        [MemberData(nameof(_03022_MinimizeORofRemainingElementsUsingOperations_Data))]
        public void MinimizeORofRemainingElementsUsingOperations0(int[] a0, int expected)
        {
            // Act
            int actual = _03022_MinimizeORofRemainingElementsUsingOperations.MinimizeORofRemainingElementsUsingOperations0(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}