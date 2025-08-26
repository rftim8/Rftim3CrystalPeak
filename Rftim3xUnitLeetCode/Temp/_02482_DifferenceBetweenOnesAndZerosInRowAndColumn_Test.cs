using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _02482_DifferenceBetweenOnesAndZerosInRowAndColumn_Test
    {
        // Arrange
        private static readonly int[][] a0 = [[0, 1, 1], [1, 0, 1], [0, 0, 1]];
        private static readonly int[][] ar = [[0, 0, 4], [0, 0, 4], [-2, -2, 2]];

        private static readonly int[][] b0 = [[1, 1, 1], [1, 1, 1]];
        private static readonly int[][] br = [[5, 5, 5], [5, 5, 5]];

        public static TheoryData<int[][], int[][]> _02482_DifferenceBetweenOnesAndZerosInRowAndColumn_Data =>
            new()
            {
                { a0, ar },
                { b0, br }
            };

        [Theory]
        [MemberData(nameof(_02482_DifferenceBetweenOnesAndZerosInRowAndColumn_Data))]
        public void OnesMinusZeros0(int[][] a0, int[][] expected)
        {
            // Act
            int[][] actual = _02482_DifferenceBetweenOnesAndZerosInRowAndColumn.OnesMinusZeros0(a0);

            // Assert
            //Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02482_DifferenceBetweenOnesAndZerosInRowAndColumn_Data))]
        public void OnesMinusZeros1(int[][] a0, int[][] expected)
        {
            // Act
            int[][] actual = _02482_DifferenceBetweenOnesAndZerosInRowAndColumn.OnesMinusZeros1(a0);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
