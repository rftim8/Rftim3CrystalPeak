using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _03023_FindPatternInInfiniteStreamI_Test
    {
        // Arrange
        private static readonly int[] a0 = [];
        private static readonly int ar = 0;

        public static TheoryData<int[], int> _03023_FindPatternInInfiniteStreamI_Data =>
            new()
            {
                { a0, ar }
            };


        [Theory]
        [MemberData(nameof(_03023_FindPatternInInfiniteStreamI_Data))]
        public void FindPatternInInfiniteStreamI0(int[] a0, int expected)
        {
            // Act
            int actual = _03023_FindPatternInInfiniteStreamI.FindPatternInInfiniteStreamI0(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}