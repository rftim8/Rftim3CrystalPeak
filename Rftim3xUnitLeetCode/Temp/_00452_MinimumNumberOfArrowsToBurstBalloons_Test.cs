using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00452_MinimumNumberOfArrowsToBurstBalloons_Test
    {
        // Arrange
        private static readonly int[][] a0 = [[10, 16], [2, 8], [1, 6], [7, 12]];
        private static readonly int ar = 2;

        private static readonly int[][] b0 = [[1, 2], [3, 4], [5, 6], [7, 8]];
        private static readonly int br = 4;

        private static readonly int[][] c0 = [[1, 2], [2, 3], [3, 4], [4, 5]];
        private static readonly int cr = 2;

        public static TheoryData<int[][], int> _00452_MinimumNumberOfArrowsToBurstBalloons_Data =>
            new()
            {
                { a0, ar },
                { b0, br },
                { c0, cr }
            };


        [Theory]
        [MemberData(nameof(_00452_MinimumNumberOfArrowsToBurstBalloons_Data))]
        public void MinimumNumberOfArrowsToBurstBalloons0(int[][] a0, int expected)
        {
            // Act
            int actual = _00452_MinimumNumberOfArrowsToBurstBalloons.MinimumNumberOfArrowsToBurstBalloons0(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}