namespace Rftim3xUnitLeetCode.Temp
{
    public class _00069_SqrtX_Test
    {
        // Arrange
        private static readonly int a0 = 4;
        private static readonly int ar = 2;

        private static readonly int b0 = 8;
        private static readonly int br = 2;

        public static TheoryData<int, int> _00069_SqrtX_Data =>
            new()
            {
                { a0, ar },
                { b0, br }
            };

        [Theory]
        [MemberData(nameof(_00069_SqrtX_Data))]
        public void MySqrt0(int a0, int expected)
        {
            // Act
            //int actual = _00069_SqrtX.MySqrt0(a0);

            // Assert
            //Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00069_SqrtX_Data))]
        public void MySqrt1(int x, int expected)
        {
            // Act
            //int actual = _00069_SqrtX.MySqrt1(x);

            // Assert
            //Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00069_SqrtX_Data))]
        public void MySqrt2(int x, int expected)
        {
            // Act
            //int actual = _00069_SqrtX.MySqrt2(x);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
