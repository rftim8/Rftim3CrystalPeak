using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00256_PaintHouse_Test
    {
        // Arrange
        private static readonly int[][] a0 = [[17, 2, 17], [16, 16, 5], [14, 3, 19]];
        private static readonly int ar = 10;

        private static readonly int[][] b0 = [[7, 6, 2]];
        private static readonly int br = 2;

        public static TheoryData<int[][], int> _00256_PaintHouse_Data =>
            new()
            {
                { a0, ar },
                { b0, br }
            };

        [Theory]
        [MemberData(nameof(_00256_PaintHouse_Data))]
        public void PaintHouse0(int[][] a0, int expected)
        {
            // Act
            int actual = _00256_PaintHouse.PaintHouse0(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00256_PaintHouse_Data))]
        public void PaintHouse1(int[][] a0, int expected)
        {
            // Act
            int actual = _00256_PaintHouse.PaintHouse1(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00256_PaintHouse_Data))]
        public void PaintHouse2(int[][] a0, int expected)
        {
            // Act
            int actual = _00256_PaintHouse.PaintHouse2(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}