namespace Rftim3xUnitLeetCode.Temp
{
    public class _01846_MaximumElementAfterDecreasingAndRearranging_Test
    {
        // Arrange
        private static readonly int[] a0 = [2, 2, 1, 2, 1];
        private static readonly int ar = 2;

        private static readonly int[] b0 = [100, 1, 1000];
        private static readonly int br = 3;

        private static readonly int[] c0 = [1, 2, 3, 4, 5];
        private static readonly int cr = 5;

        public static TheoryData<int[], int> _01846_MaximumElementAfterDecreasingAndRearranging_Data =>
            new()
            {
                { a0, ar },
                { b0, br },
                { c0, cr }
            };

        [Theory]
        [MemberData(nameof(_01846_MaximumElementAfterDecreasingAndRearranging_Data))]
        public void MaximumElementAfterDecrementingAndRearranging0(int[] arr, int expected)
        {
            // Act
            //int actual = _01846_MaximumElementAfterDecreasingAndRearranging.MaximumElementAfterDecrementingAndRearranging0(arr);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
