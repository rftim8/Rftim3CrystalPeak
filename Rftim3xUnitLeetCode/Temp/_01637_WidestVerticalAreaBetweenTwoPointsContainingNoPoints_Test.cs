namespace Rftim3xUnitLeetCode.Temp
{
    public class _01637_WidestVerticalAreaBetweenTwoPointsContainingNoPoints_Test
    {
        // Arrange
        private static readonly int[][] a0 = [[8, 7], [9, 9], [7, 4], [9, 7]];
        private static readonly int ar = 1;

        private static readonly int[][] b0 = [[3, 1], [9, 0], [1, 0], [1, 4], [5, 3], [8, 8]];
        private static readonly int br = 3;

        public static TheoryData<int[][], int> _01637_WidestVerticalAreaBetweenTwoPointsContainingNoPoints_Data() => new()
        {
            { a0, ar },
            { b0, br }
        };

        [Theory]
        [MemberData(nameof(_01637_WidestVerticalAreaBetweenTwoPointsContainingNoPoints_Data))]
        public void MaxWidthOfVerticalArea0(int[][] a0, int expected)
        {
            // Act
            //int actual = _01637_WidestVerticalAreaBetweenTwoPointsContainingNoPoints.MaxWidthOfVerticalArea0(a0);

            // Assert
            //Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01637_WidestVerticalAreaBetweenTwoPointsContainingNoPoints_Data))]
        public void MaxWidthOfVerticalArea1(int[][] a0, int expected)
        {
            // Act
            //int actual = _01637_WidestVerticalAreaBetweenTwoPointsContainingNoPoints.MaxWidthOfVerticalArea1(a0);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
