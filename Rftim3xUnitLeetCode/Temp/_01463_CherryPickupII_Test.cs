using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _01463_CherryPickupII_Test
    {
        // Arrange
        private static readonly int[][] a0 = [[3, 1, 1], [2, 5, 1], [1, 5, 5], [2, 1, 1]];
        private static readonly int ar = 24;

        private static readonly int[][] b0 = [[1, 0, 0, 0, 0, 0, 1], [2, 0, 0, 0, 0, 3, 0], [2, 0, 9, 0, 0, 0, 0], [0, 3, 0, 5, 4, 0, 0], [1, 0, 2, 3, 0, 0, 6]];
        private static readonly int br = 28;

        public static TheoryData<int[][], int> _01463_CherryPickupII_Data =>
            new()
            {
                { a0, ar },
                { b0, br }
            };


        [Theory]
        [MemberData(nameof(_01463_CherryPickupII_Data))]
        public void CherryPickupII0(int[][] a0, int expected)
        {
            // Act
            int actual = _01463_CherryPickupII.CherryPickupII0(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01463_CherryPickupII_Data))]
        public void CherryPickupII1(int[][] a0, int expected)
        {
            // Act
            int actual = _01463_CherryPickupII.CherryPickupII1(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01463_CherryPickupII_Data))]
        public void CherryPickupII2(int[][] a0, int expected)
        {
            // Act
            int actual = _01463_CherryPickupII.CherryPickupII2(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}