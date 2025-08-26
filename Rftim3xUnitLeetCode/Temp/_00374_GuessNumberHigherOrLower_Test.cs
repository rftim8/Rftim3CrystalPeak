namespace Rftim3xUnitLeetCode.Temp
{
    public class _00374_GuessNumberHigherOrLower_Test
    {
        // Arrange
        private static readonly int a0 = 10;
        private static readonly int a1 = 6;
        private static readonly int ar = 6;

        private static readonly int b0 = 1;
        private static readonly int b1 = 1;
        private static readonly int br = 1;

        private static readonly int c0 = 2;
        private static readonly int c1 = 1;
        private static readonly int cr = 1;

        public static TheoryData<int, int, int> _00374_GuessNumberHigherOrLower_Data =>
            new()
            {
                { a0, a1, ar },
                { b0, b1, br },
                { c0, c1, cr }
            };

        [Theory]
        [MemberData(nameof(_00374_GuessNumberHigherOrLower_Data))]
        public void GuessNumber0(int n, int m, int expected)
        {
            // Act
            //int actual = _00374_GuessNumberHigherOrLower.GuessNumber0(n, m);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
