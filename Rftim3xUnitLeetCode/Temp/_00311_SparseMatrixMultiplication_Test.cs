using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00311_SparseMatrixMultiplication_Test
    {
        // Arrange
        private static readonly int[][] a0 = [[1, 0, 0], [-1, 0, 3]];
        private static readonly int[][] a1 = [[7, 0, 0], [0, 0, 0], [0, 0, 1]];
        private static readonly int[][] ar = [[7, 0, 0], [-7, 0, 3]];

        private static readonly int[][] b0 = [[0]];
        private static readonly int[][] b1 = [[0]];
        private static readonly int[][] br = [[0]];

        public static TheoryData<int[][], int[][], int[][]> _00311_SparseMatrixMultiplication_Data =>
            new()
            {
                { a0, a1, ar },
                { b0, b1, br }
            };


        [Theory]
        [MemberData(nameof(_00311_SparseMatrixMultiplication_Data))]
        public void SparseMatrixMultiplication0(int[][] a0, int[][] a1, int[][] expected)
        {
            // Act
            int[][] actual = _00311_SparseMatrixMultiplication.SparseMatrixMultiplication0(a0, a1);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00311_SparseMatrixMultiplication_Data))]
        public void SparseMatrixMultiplication1(int[][] a0, int[][] a1, int[][] expected)
        {
            // Act
            int[][] actual = _00311_SparseMatrixMultiplication.SparseMatrixMultiplication1(a0, a1);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}