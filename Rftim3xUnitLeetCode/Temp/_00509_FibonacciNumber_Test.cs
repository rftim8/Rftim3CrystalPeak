namespace Rftim3xUnitLeetCode.Temp
{
    public class _00509_FibonacciNumber_Test
    {
        // Arrange
        private static readonly int a0 = 2;
        private static readonly int ar = 1;

        private static readonly int b0 = 3;
        private static readonly int br = 2;

        private static readonly int c0 = 4;
        private static readonly int cr = 3;

        public static TheoryData<int, int> _00509_FibonacciNumber_Data =>
            new()
            {
                { a0, ar },
                { b0, br },
                { c0, cr }
            };

        [Theory]
        [MemberData(nameof(_00509_FibonacciNumber_Data))]
        public void Fib0(int num, int expected)
        {
            // Act
            //int actual = _00509_FibonacciNumber.Fib0(num);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
