namespace Rftim3xUnitLeetCode.Temp
{
    public class _02908_MinimumSumOfMountainTriplets1_Test
    {
        // Arrange
        private static readonly int[] a0 = [8, 6, 1, 5, 3];
        private static readonly int ar = 9;

        private static readonly int[] b0 = [5, 4, 8, 7, 10, 2];
        private static readonly int br = 13;

        private static readonly int[] c0 = [6, 5, 4, 3, 4, 5];
        private static readonly int cr = -1;

        public static TheoryData<int[], int> _02908_MinimumSumOfMountainTriplets1_Data =>
            new()
            {
                { a0, ar },
                { b0, br },
                { c0, cr }
            };

        [Theory]
        [MemberData(nameof(_02908_MinimumSumOfMountainTriplets1_Data))]
        public void MinimumSum0(int[] a0, int expected)
        {
            // Act
            //int actual = _02908_MinimumSumOfMountainTriplets1.MinimumSum0(a0);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
