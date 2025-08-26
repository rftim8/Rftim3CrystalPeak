namespace Rftim3xUnitLeetCode.Temp
{
    public class _01814_CountNicePairsInAnArray_Test
    {
        // Arrange
        private static readonly int[] a0 = [42, 11, 1, 97];
        private static readonly int ar = 2;

        private static readonly int[] b0 = [13, 10, 35, 24, 76];
        private static readonly int br = 4;

        public static TheoryData<int[], int> _01814_CountNicePairsInAnArray_Data =>
            new()
            {
                { a0, ar },
                { b0, br }
            };

        [Theory]
        [MemberData(nameof(_01814_CountNicePairsInAnArray_Data))]
        public void CountNicePairs0(int[] arr, int expected)
        {
            // Act
            //int actual = _01814_CountNicePairsInAnArray.CountNicePairs0(arr);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
