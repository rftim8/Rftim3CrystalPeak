using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _03031_MinimumTimeToRevertWordToInitialStateII_Test
    {
        // Arrange
        private static readonly int[] a0 = [];
        private static readonly int ar = 0;

        public static TheoryData<int[], int> _03031_MinimumTimeToRevertWordToInitialStateII_Data =>
            new()
            {
                { a0, ar }
            };


        [Theory]
        [MemberData(nameof(_03031_MinimumTimeToRevertWordToInitialStateII_Data))]
        public void MinimumTimeToRevertWordToInitialStateII0(int[] a0, int expected)
        {
            // Act
            int actual = _03031_MinimumTimeToRevertWordToInitialStateII.MinimumTimeToRevertWordToInitialStateII0(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}