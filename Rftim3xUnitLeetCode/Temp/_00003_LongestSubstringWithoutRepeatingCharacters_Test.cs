namespace Rftim3xUnitLeetCode.Temp
{
    public class _00003_LongestSubstringWithoutRepeatingCharacters_Test
    {
        // Arrange
        private static readonly string a0 = "abcabcbb";
        private static readonly int ar = 3;

        private static readonly string b0 = "bbbbbb";
        private static readonly int br = 1;

        private static readonly string c0 = "pwwkew";
        private static readonly int cr = 3;

        public static TheoryData<string, int> _00003_LongestSubstringWithoutRepeatingCharacters_Data =>
            new()
            {
                { a0, ar },
                { b0, br },
                { c0, cr }
            };


        [Theory]
        [MemberData(nameof(_00003_LongestSubstringWithoutRepeatingCharacters_Data))]
        public void LongestSubstringWithoutRepeatingCharacters0(string a0, int expected)
        {
            // Act
            //int actual = _00003_LongestSubstringWithoutRepeatingCharacters.LongestSubstringWithoutRepeatingCharacters0(a0);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}