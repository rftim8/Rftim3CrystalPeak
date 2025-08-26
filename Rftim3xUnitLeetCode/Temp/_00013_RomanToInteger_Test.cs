namespace Rftim3xUnitLeetCode.Temp
{
    public class _00013_RomanToInteger_Test
    {
        // Arrange
        private static readonly string a0 = "III";
        private static readonly int ar = 3;

        private static readonly string b0 = "LVIII";
        private static readonly int br = 58;

        private static readonly string c0 = "MCMXCIV";
        private static readonly int cr = 1994;

        public static TheoryData<string, int> _00013_RomanToInteger_Data =>
            new()
            {
                { a0, ar },
                { b0, br },
                { c0, cr }
            };


        [Theory]
        [MemberData(nameof(_00013_RomanToInteger_Data))]
        public void RomanToInteger0(string a0, int expected)
        {
            // Act
            //int actual = _00013_RomanToInteger.RomanToInteger0(a0);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}