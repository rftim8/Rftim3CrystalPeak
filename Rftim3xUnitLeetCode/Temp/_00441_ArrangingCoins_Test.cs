namespace Rftim3xUnitLeetCode.Temp
{
    public class _00441_ArrangingCoins_Test
    {
        // Arrange
        private static readonly int a0 = 5;
        private static readonly int ar = 2;

        private static readonly int b0 = 8;
        private static readonly int br = 3;

        public static TheoryData<int, int> _00441_ArrangingCoins_Data =>
            new()
            {
                { a0, ar },
                { b0, br }
            };

        [Theory]
        [MemberData(nameof(_00441_ArrangingCoins_Data))]
        public void ArrangeCoins0(int n, int expected)
        {
            // Act
            //int actual = _00441_ArrangingCoins.ArrangeCoins0(n);

            // Assert
            //Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00441_ArrangingCoins_Data))]
        public void ArrangeCoins1(int n, int expected)
        {
            // Act
            //int actual = _00441_ArrangingCoins.ArrangeCoins1(n);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
