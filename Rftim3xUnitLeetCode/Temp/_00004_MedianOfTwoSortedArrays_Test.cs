using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00004_MedianOfTwoSortedArrays_Test
    {
        // Arrange
        private static readonly int[] a0 = [1, 3];
        private static readonly int[] a1 = [2];
        private static readonly double ar = 2.00000;

        private static readonly int[] b0 = [1, 2];
        private static readonly int[] b1 = [3, 4];
        private static readonly double br = 2.50000;

        public static TheoryData<int[], int[], double> _00004_MedianOfTwoSortedArrays_Data =>
            new()
            {
                { a0, a1, ar },
                { b0, b1, br }
            };

        [Theory]
        [MemberData(nameof(_00004_MedianOfTwoSortedArrays_Data))]
        public void MedianOfTwoSortedArrays0(int[] a0, int[] a1, double expected)
        {
            // Act
            double actual = _00004_MedianOfTwoSortedArrays.MedianOfTwoSortedArrays0(a0, a1);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
