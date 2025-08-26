using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _01727_LargestSubmatrixWithRearrangements_Test
    {
        // Arrange
        private static readonly int[][] a0 = [[0, 0, 1], [1, 1, 1], [1, 0, 1]];
        private static readonly int ar = 4;

        private static readonly int[][] b0 = [[1, 0, 1, 0, 1]];
        private static readonly int br = 3;

        private static readonly int[][] c0 = [[1, 1, 0], [1, 0, 1]];
        private static readonly int cr = 2;

        public static TheoryData<int[][], int> _01727_LargestSubmatrixWithRearrangements_Data =>
            new()
            {
                { a0, ar },
                { b0, br },
                { c0, cr }
            };

        [Theory]
        [MemberData(nameof(_01727_LargestSubmatrixWithRearrangements_Data))]
        public void LargestSubmatrix0(int[][] a0, int expected)
        {
            // Act
            int actual = _01727_LargestSubmatrixWithRearrangements.LargestSubmatrix0(a0);

            // Assert
            Assert.Equivalent(expected, actual, true);
        }

        [Theory]
        [MemberData(nameof(_01727_LargestSubmatrixWithRearrangements_Data))]
        public void LargestSubmatrix1(int[][] a0, int expected)
        {
            // Act
            int actual = _01727_LargestSubmatrixWithRearrangements.LargestSubmatrix1(a0);

            // Assert
            Assert.Equivalent(expected, actual, true);
        }

        [Theory]
        [MemberData(nameof(_01727_LargestSubmatrixWithRearrangements_Data))]
        public void LargestSubmatrix2(int[][] a0, int expected)
        {
            // Act
            int actual = _01727_LargestSubmatrixWithRearrangements.LargestSubmatrix2(a0);

            // Assert
            Assert.Equivalent(expected, actual, true);
        }
    }
}
