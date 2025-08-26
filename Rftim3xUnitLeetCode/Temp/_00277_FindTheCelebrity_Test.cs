namespace Rftim3xUnitLeetCode.Temp
{
    public class _00277_FindTheCelebrity_Test
    {
        // Arrange
        private static readonly int[][] a0 = [[1, 1, 0], [0, 1, 0], [1, 1, 1]];
        private static readonly int ar = 1;

        private static readonly int[][] b0 = [[1, 0, 1], [1, 1, 0], [0, 1, 1]];
        private static readonly int br = -1;

        public static TheoryData<int[][], int> _00277_FindTheCelebrity_Data =>
            new()
            {
                { a0, ar },
                { b0, br }
            };

        [Theory]
        [MemberData(nameof(_00277_FindTheCelebrity_Data))]
        public void FindCelebrity1(int[][] a0, int expected)
        {
            // Act
            //int actual = _00277_FindTheCelebrity.FindCelebrity1(a0);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
