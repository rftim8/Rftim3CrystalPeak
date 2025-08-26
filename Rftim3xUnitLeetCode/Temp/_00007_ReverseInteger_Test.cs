namespace Rftim3xUnitLeetCode.Temp
{
    public class _00007_ReverseInteger_Test
    {
        // Arrange
        private static readonly int a0 = 123;
        private static readonly int ar = 321;

        private static readonly int b0 = -123;
        private static readonly int br = -321;

        private static readonly int c0 = 120;
        private static readonly int cr = 21;

        public static TheoryData<int, int> _00007_ReverseInteger_Data =>
            new()
            {
                { a0, ar },
                { b0, br },
                { c0, cr }
            };

        [Theory]
        [MemberData(nameof(_00007_ReverseInteger_Data))]
        public void ReverseInteger0(int a0, int expected)
        {
            // Act
            //int actual = _00007_ReverseInteger.ReverseInteger0(a0);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
