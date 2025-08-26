namespace Rftim3xUnitLeetCode.Temp
{
    public class _00258_AddDigits_Test
    {
        // Arrange
        private static readonly int a0 = 38;
        private static readonly int ar = 2;

        private static readonly int b0 = 0;
        private static readonly int br = 0;

        public static TheoryData<int, int> _00258_AddDigits_Data =>
            new()
            {
                { a0, ar },
                { b0, br }
            };

        [Theory]
        [MemberData(nameof(_00258_AddDigits_Data))]
        public void AddDigits0(int num, int expected)
        {
            // Act
            //int actual = _00258_AddDigits.AddDigits0(num);

            // Assert
            //Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00258_AddDigits_Data))]
        public void AddDigits1(int num, int expected)
        {
            // Act
            //int actual = _00258_AddDigits.AddDigits1(num);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
