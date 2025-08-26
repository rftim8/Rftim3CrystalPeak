namespace Rftim3xUnitLeetCode.Temp
{
    public class _01930_UniqueLength3PalindromicSubsequences_Test
    {
        // Arrange
        private static readonly string a0 = "aabca";
        private static readonly int ar = 3;

        private static readonly string b0 = "adc";
        private static readonly int br = 0;

        private static readonly string c0 = "bbcbaba";
        private static readonly int cr = 4;

        public static TheoryData<string, int> _01930_UniqueLength3PalindromicSubsequences_Data =>
            new()
            {
                { a0, ar },
                { b0, br },
                { c0, cr }
            };

        [Theory]
        [MemberData(nameof(_01930_UniqueLength3PalindromicSubsequences_Data))]
        public void CountPalindromicSubsequence0(string s, int expected)
        {
            // Act
            //int actual = _01930_UniqueLength3PalindromicSubsequences.CountPalindromicSubsequence0(s);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
