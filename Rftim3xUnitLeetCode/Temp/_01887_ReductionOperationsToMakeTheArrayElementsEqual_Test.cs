namespace Rftim3xUnitLeetCode.Temp
{
    public class _01887_ReductionOperationsToMakeTheArrayElementsEqual_Test
    {
        // Arrange
        private static readonly int[] a0 = [5, 1, 3];
        private static readonly int ar = 3;

        private static readonly int[] b0 = [1, 1, 1];
        private static readonly int br = 0;

        private static readonly int[] c0 = [1, 1, 2, 2, 3];
        private static readonly int cr = 4;

        public static TheoryData<int[], int> _01887_ReductionOperationsToMakeTheArrayElementsEqual_Data =>
            new()
            {
                { a0, ar },
                { b0, br },
                { c0, cr }
            };

        [Theory]
        [MemberData(nameof(_01887_ReductionOperationsToMakeTheArrayElementsEqual_Data))]
        public void ReductionOperations0(int[] arr, int expected)
        {
            // Act
            //int actual = _01887_ReductionOperationsToMakeTheArrayElementsEqual.ReductionOperations0(arr);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
