namespace Rftim3xUnitLeetCode.Temp
{
    public class _01877_MinimizeMaximumPairSumInArray_Test
    {
        // Arrange
        private static readonly int[] a0 = [3, 5, 2, 3];
        private static readonly int ar = 7;

        private static readonly int[] b0 = [3, 5, 4, 2, 4, 6];
        private static readonly int br = 8;

        private static readonly int[] c0 = [4, 1, 5, 1, 2, 5, 1, 5, 5, 4];
        private static readonly int cr = 8;

        public static TheoryData<int[], int> _01877_MinimizeMaximumPairSumInArray_Data =>
            new()
            {
                { a0, ar },
                { b0, br },
                { c0, cr }
            };

        [Theory]
        [MemberData(nameof(_01877_MinimizeMaximumPairSumInArray_Data))]
        public void MinPairSum0(int[] arr, int expected)
        {
            // Act
            //int actual = _01877_MinimizeMaximumPairSumInArray.MinPairSum0(arr);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
