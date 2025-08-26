namespace Rftim3xUnitLeetCode.Temp
{
    public class _00409_LongestPalindrome_Test
    {
        // Arrange
        private static readonly string a0 = "abccccdd";
        private static readonly int ar = 7;

        private static readonly string b0 = "a";
        private static readonly int br = 1;

        public static TheoryData<string, int> _00409_LongestPalindrome_Data =>
            new()
            {
                { a0, ar },
                { b0, br }
            };

        [Theory]
        [MemberData(nameof(_00409_LongestPalindrome_Data))]
        public void LongestPalindrome0(string num, int expected)
        {
            // Act
            //int actual = _00409_LongestPalindrome.LongestPalindrome0(num);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
