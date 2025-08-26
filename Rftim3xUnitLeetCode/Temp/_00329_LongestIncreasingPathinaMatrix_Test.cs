using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00329_LongestIncreasingPathInAMatrix_Test
    {
        // Arrange
        private static readonly int[][] a0 = [[9, 9, 4], [6, 6, 8], [2, 1, 1]];
        private static readonly int ar = 4;

        private static readonly int[][] b0 = [[3, 4, 5], [3, 2, 6], [2, 2, 1]];
        private static readonly int br = 4;

        private static readonly int[][] c0 = [[1]];
        private static readonly int cr = 1;

        public static TheoryData<int[][], int> _00329_LongestIncreasingPathInAMatrix_Data =>
            new()
            {
                { a0, ar },
                { b0, br },
                { c0, cr }
            };

        [Theory]
        [MemberData(nameof(_00329_LongestIncreasingPathInAMatrix_Data))]
        public void LongestIncreasingPathInAMatrix0(int[][] a0, int expected)
        {
            // Act
            int actual = _00329_LongestIncreasingPathInAMatrix.LongestIncreasingPathInAMatrix0(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00329_LongestIncreasingPathInAMatrix_Data))]
        public void LongestIncreasingPathInAMatrix1(int[][] a0, int expected)
        {
            // Act
            int actual = _00329_LongestIncreasingPathInAMatrix.LongestIncreasingPathInAMatrix1(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00329_LongestIncreasingPathInAMatrix_Data))]
        public void LongestIncreasingPathInAMatrix2(int[][] a0, int expected)
        {
            // Act
            int actual = _00329_LongestIncreasingPathInAMatrix.LongestIncreasingPathInAMatrix2(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}