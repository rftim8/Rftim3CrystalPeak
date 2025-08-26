using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _03029_MinimumTimeToRevertWordToInitialStateI_Test
    {
        // Arrange
        private static readonly int[] a0 = [];
        private static readonly int ar = 0;

        public static TheoryData<int[], int> _03029_MinimumTimeToRevertWordToInitialStateI_Data =>
            new()
            {
                { a0, ar }
            };


        [Theory]
        [MemberData(nameof(_03029_MinimumTimeToRevertWordToInitialStateI_Data))]
        public void MinimumTimeToRevertWordToInitialStateI0(int[] a0, int expected)
        {
            // Act
            int actual = _03029_MinimumTimeToRevertWordToInitialStateI.MinimumTimeToRevertWordToInitialStateI0(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}