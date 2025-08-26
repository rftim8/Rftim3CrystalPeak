namespace Rftim3xUnitLeetCode.Temp
{
    public class _00463_IslandPerimeter_Test
    {
        // Arrange
        private static readonly int[][] a0 = [
            [0, 1, 0, 0],
            [1, 1, 1, 0],
            [0, 1, 0, 0],
            [1, 1, 0, 0]
            ];
        private static readonly int ar = 16;

        private static readonly int[][] b0 = [
                [1]
            ];
        private static readonly int br = 4;

        private static readonly int[][] c0 = [
                [1, 0]
            ];
        private static readonly int cr = 4;

        public static TheoryData<int[][], int> _00463_IslandPerimeter_Data =>
            new()
            {
                { a0, ar },
                { b0, br },
                { c0, cr }
            };

        [Theory]
        [MemberData(nameof(_00463_IslandPerimeter_Data))]
        public void IslandPerimeter0(int[][] grid, int expected)
        {
            // Act
            //int actual = _00463_IslandPerimeter.IslandPerimeter0(grid);

            // Assert
            //Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00463_IslandPerimeter_Data))]
        public void IslandPerimeter1(int[][] grid, int expected)
        {
            // Act
            //int actual = _00463_IslandPerimeter.IslandPerimeter1(grid);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
