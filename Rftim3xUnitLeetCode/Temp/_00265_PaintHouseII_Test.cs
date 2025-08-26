using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00265_PaintHouseII_Test
    {
        // Arrange
        private static readonly int[][] a0 = [[1, 5, 3], [2, 9, 4]];
        private static readonly int ar = 5;

        private static readonly int[][] b0 = [[1, 3], [2, 4]];
        private static readonly int br = 5;

        public static TheoryData<int[][], int> _00265_PaintHouseII_Data =>
            new()
            {
                { a0, ar },
                { b0, br }
            };


        [Theory]
        [MemberData(nameof(_00265_PaintHouseII_Data))]
        public void PaintHouseII0(int[][] a0, int expected)
        {
            // Act
            int actual = _00265_PaintHouseII.PaintHouseII0(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00265_PaintHouseII_Data))]
        public void PaintHouseII1(int[][] a0, int expected)
        {
            // Act
            int actual = _00265_PaintHouseII.PaintHouseII1(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00265_PaintHouseII_Data))]
        public void PaintHouseII2(int[][] a0, int expected)
        {
            // Act
            int actual = _00265_PaintHouseII.PaintHouseII2(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}