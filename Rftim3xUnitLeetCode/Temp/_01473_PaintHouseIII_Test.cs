using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _01473_PaintHouseIII_Test
    {
        // Arrange
        private static readonly int[] a0 = [0, 0, 0, 0, 0];
        private static readonly int[][] a1 = [[1, 10], [10, 1], [10, 1], [1, 10], [5, 1]];
        private static readonly int a2 = 5, a3 = 2, a4 = 3, ar = 9;

        private static readonly int[] b0 = [0, 2, 1, 2, 0];
        private static readonly int[][] b1 = [[1, 10], [10, 1], [10, 1], [1, 10], [5, 1]];
        private static readonly int b2 = 5, b3 = 2, b4 = 3, br = 11;

        private static readonly int[] c0 = [3, 1, 2, 3];
        private static readonly int[][] c1 = [[1, 1, 1], [1, 1, 1], [1, 1, 1], [1, 1, 1]];
        private static readonly int c2 = 4, c3 = 3, c4 = 3, cr = -1;

        public static TheoryData<int[], int[][], int, int, int, int> _01473_PaintHouseIII_Data =>
            new()
            {
                { a0, a1, a2, a3, a4, ar }
            };

        [Theory]
        [MemberData(nameof(_01473_PaintHouseIII_Data))]
        public void PaintHouseIII0(int[] a0, int[][] a1, int a2, int a3, int a4, int expected)
        {
            // Act
            int actual = _01473_PaintHouseIII.PaintHouseIII0(a0, a1, a2, a3, a4);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01473_PaintHouseIII_Data))]
        public void PaintHouseIII1(int[] a0, int[][] a1, int a2, int a3, int a4, int expected)
        {
            // Act
            int actual = _01473_PaintHouseIII.PaintHouseIII1(a0, a1, a2, a3, a4);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01473_PaintHouseIII_Data))]
        public void PaintHouseIII2(int[] a0, int[][] a1, int a2, int a3, int a4, int expected)
        {
            // Act
            int actual = _01473_PaintHouseIII.PaintHouseIII2(a0, a1, a2, a3, a4);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}