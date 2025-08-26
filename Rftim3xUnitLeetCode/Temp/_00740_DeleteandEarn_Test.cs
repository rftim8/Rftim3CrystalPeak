using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00740_DeleteAndEarn_Test
    {
        // Arrange
        private static readonly int[] a0 = [];
        private static readonly int ar = 0;

        public static TheoryData<int[], int> _00740_DeleteAndEarn_Data =>
            new()
            {
                { a0, ar }
            };


        [Theory]
        [MemberData(nameof(_00740_DeleteAndEarn_Data))]
        public void DeleteAndEarn0(int[] a0, int expected)
        {
            // Act
            int actual = _00740_DeleteAndEarn.DeleteAndEarn0(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}