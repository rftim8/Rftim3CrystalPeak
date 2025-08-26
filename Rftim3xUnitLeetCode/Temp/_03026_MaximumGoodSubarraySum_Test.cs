using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _03026_MaximumGoodSubarraySum_Test
    {
        // Arrange
        private static readonly int[] a0 = [];
        private static readonly int ar = 0;

        public static TheoryData<int[], int> _03026_MaximumGoodSubarraySum_Data =>
            new()
            {
                { a0, ar }
            };


        [Theory]
        [MemberData(nameof(_03026_MaximumGoodSubarraySum_Data))]
        public void MaximumGoodSubarraySum0(int[] a0, int expected)
        {
            // Act
            int actual = _03026_MaximumGoodSubarraySum.MaximumGoodSubarraySum0(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}