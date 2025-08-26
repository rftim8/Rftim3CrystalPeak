using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _03032_CountNumbersWithUniqueDigitsII_Test
    {
        // Arrange
        private static readonly int[] a0 = [];
        private static readonly int ar = 0;

        public static TheoryData<int[], int> _03032_CountNumbersWithUniqueDigitsII_Data =>
            new()
            {
                { a0, ar }
            };


        [Theory]
        [MemberData(nameof(_03032_CountNumbersWithUniqueDigitsII_Data))]
        public void CountNumbersWithUniqueDigitsII0(int[] a0, int expected)
        {
            // Act
            int actual = _03032_CountNumbersWithUniqueDigitsII.CountNumbersWithUniqueDigitsII0(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}