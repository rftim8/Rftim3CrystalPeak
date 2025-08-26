using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _01743_RestoreTheArrayFromAdjacentPairs_Test
    {
        // Arrange
        private static readonly int[][] a0 = [[2, 1], [3, 4], [3, 2]];
        private static readonly int[] ar = [1, 2, 3, 4];

        private static readonly int[][] b0 = [[4, -2], [1, 4], [-3, 1]];
        private static readonly int[] br = [-2, 4, 1, -3];

        private static readonly int[][] c0 = [[100000, -100000]];
        private static readonly int[] cr = [100000, -100000];

        private static readonly int[][] d0 = [[4, -10], [-1, 3], [4, -3], [-3, 3]];
        private static readonly int[] dr = [-10, 4, -3, 3, -1];

        public static TheoryData<int[][], int[]> _01743_RestoreTheArrayFromAdjacentPairs_Data =>
            new()
            {
                { a0, ar },
                { b0, br },
                { c0, cr },
                { d0, dr }
            };

        [Theory]
        [MemberData(nameof(_01743_RestoreTheArrayFromAdjacentPairs_Data))]
        public void RestoreArray0(int[][] a0, int[] expected)
        {
            // Act
            int[] actual = _01743_RestoreTheArrayFromAdjacentPairs.RestoreArray0(a0);

            // Assert
            Assert.Equivalent(expected, actual, true);
        }
    }
}
