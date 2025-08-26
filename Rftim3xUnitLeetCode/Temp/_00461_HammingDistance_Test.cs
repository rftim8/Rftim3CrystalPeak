namespace Rftim3xUnitLeetCode.Temp
{
    public class _00461_HammingDistance_Test
    {
        // Arrange
        private static readonly int a0 = 1;
        private static readonly int a1 = 4;
        private static readonly int ar = 2;

        private static readonly int b0 = 3;
        private static readonly int b1 = 1;
        private static readonly int br = 1;

        public static TheoryData<int, int, int> _00461_HammingDistance_Data =>
            new()
            {
                { a0, a1, ar },
                { b0, b1, br }
            };

        [Theory]
        [MemberData(nameof(_00461_HammingDistance_Data))]
        public void HammingDistance0(int x, int y, int expected)
        {
            // Act
            //int actual = _00461_HammingDistance.HammingDistance0(x, y);

            // Assert
            //Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00461_HammingDistance_Data))]
        public void HammingDistance1(int x, int y, int expected)
        {
            // Act
            //int actual = _00461_HammingDistance.HammingDistance1(x, y);

            // Assert
            //Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00461_HammingDistance_Data))]
        public void HammingDistance2(int x, int y, int expected)
        {
            // Act
            //int actual = _00461_HammingDistance.HammingDistance2(x, y);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
