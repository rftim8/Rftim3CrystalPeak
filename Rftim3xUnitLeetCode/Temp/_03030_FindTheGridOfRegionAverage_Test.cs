using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _03030_FindTheGridOfRegionAverage_Test
    {
        // Arrange
        private static readonly int[] a0 = [];
        private static readonly int ar = 0;

        public static TheoryData<int[], int> _03030_FindTheGridOfRegionAverage_Data =>
            new()
            {
                { a0, ar }
            };


        [Theory]
        [MemberData(nameof(_03030_FindTheGridOfRegionAverage_Data))]
        public void FindTheGridOfRegionAverage0(int[] a0, int expected)
        {
            // Act
            int actual = _03030_FindTheGridOfRegionAverage.FindTheGridOfRegionAverage0(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}