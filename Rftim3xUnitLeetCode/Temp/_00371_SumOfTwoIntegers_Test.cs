using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00371_SumOfTwoIntegers_Test
    {
        // Arrange
        private static readonly int[] a0 = [];
        private static readonly int ar = 0;

        public static TheoryData<int[], int> _00371_SumOfTwoIntegers_Data =>
            new()
            {
                { a0, ar }
            };


        [Theory]
        [MemberData(nameof(_00371_SumOfTwoIntegers_Data))]
        public void SumOfTwoIntegers0(int[] a0, int expected)
        {
            // Act
            int actual = _00371_SumOfTwoIntegers.SumOfTwoIntegers0(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}