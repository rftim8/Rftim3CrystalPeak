namespace Rftim3xUnitLeetCode.Temp
{
    public class _01535_FindTheWinnerOfAnArrayGame_Test
    {
        // Arrange
        private static readonly int[] a0 = [2, 1, 3, 5, 4, 6, 7];
        private static readonly int a1 = 2;
        private static readonly int ar = 5;

        private static readonly int[] b0 = [3, 2, 1];
        private static readonly int b1 = 10;
        private static readonly int br = 3;

        public static TheoryData<int[], int, int> _01535_FindTheWinnerOfAnArrayGame_Data =>
            new()
            {
                { a0, a1, ar },
                { b0, b1, br }
            };

        [Theory]
        [MemberData(nameof(_01535_FindTheWinnerOfAnArrayGame_Data))]
        public void GetWinner0(int[] a0, int k, int expected)
        {
            // Act
            //int actual = _01535_FindTheWinnerOfAnArrayGame.GetWinner0(a0, k);

            // Assert
            //Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01535_FindTheWinnerOfAnArrayGame_Data))]
        public void GetWinner1(int[] a0, int k, int expected)
        {
            // Act
            //int actual = _01535_FindTheWinnerOfAnArrayGame.GetWinner1(a0, k);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
