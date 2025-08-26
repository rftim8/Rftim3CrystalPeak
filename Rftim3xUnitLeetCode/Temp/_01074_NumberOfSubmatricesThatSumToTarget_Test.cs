using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _01074_NumberOfSubmatricesThatSumToTarget_Test
    {
        // Arrange
        private static readonly int[][] a0 = [[0, 1, 0], [1, 1, 1], [0, 1, 0]];
        private static readonly int a1 = 0;
        private static readonly int ar = 4;

        private static readonly int[][] b0 = [[1, -1], [-1, 1]];
        private static readonly int b1 = 0;
        private static readonly int br = 5;

        private static readonly int[][] c0 = [[904]];
        private static readonly int c1 = 0;
        private static readonly int cr = 0;

        public static TheoryData<int[][], int, int> _01074_NumberOfSubmatricesThatSumToTarget_Data =>
            new()
            {
                { a0, a1, ar }
            };


        [Theory]
        [MemberData(nameof(_01074_NumberOfSubmatricesThatSumToTarget_Data))]
        public void NumberOfSubmatricesThatSumToTarget0(int[][] a0, int a1, int expected)
        {
            // Act
            int actual = _01074_NumberOfSubmatricesThatSumToTarget.NumberOfSubmatricesThatSumToTarget0(a0, a1);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01074_NumberOfSubmatricesThatSumToTarget_Data))]
        public void NumberOfSubmatricesThatSumToTarget1(int[][] a0, int a1, int expected)
        {
            // Act
            int actual = _01074_NumberOfSubmatricesThatSumToTarget.NumberOfSubmatricesThatSumToTarget1(a0, a1);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}