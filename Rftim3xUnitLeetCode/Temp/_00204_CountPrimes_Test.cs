namespace Rftim3xUnitLeetCode.Temp
{
    public class _00204_CountPrimes_Test
    {
        // Arrange
        private static readonly int a0 = 10;
        private static readonly int ar = 4;

        private static readonly int b0 = 0;
        private static readonly int br = 0;

        private static readonly int c0 = 1;
        private static readonly int cr = 0;

        private static readonly int d0 = 461465;
        private static readonly int dr = 38571;

        public static TheoryData<int, int> _00204_CountPrimes_Data =>
            new()
            {
                { a0, ar },
                { b0, br },
                { c0, cr },
                { d0, dr }
            };

        [Theory]
        [MemberData(nameof(_00204_CountPrimes_Data))]
        public void CountPrimes0(int a0, int expected)
        {
            // Act
            //int actual = _00204_CountPrimes.CountPrimes0(a0);

            // Assert
            //Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00204_CountPrimes_Data))]
        public void CountPrimes1(int a0, int expected)
        {
            // Act
            //int actual = _00204_CountPrimes.CountPrimes1(a0);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
