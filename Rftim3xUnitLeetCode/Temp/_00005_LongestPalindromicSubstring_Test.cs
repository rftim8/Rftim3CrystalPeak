using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00005_LongestPalindromicSubstring_Test
    {
        // Arrange
        private static readonly string a0 = "babad";
        private static readonly string ar = "bab";

        private static readonly string b0 = "cbbd";
        private static readonly string br = "bb";

        public static TheoryData<string, string> _00005_LongestPalindromicSubstring_Data =>
            new()
            {
                { a0, ar },
                { b0, br }
            };

        [Theory]
        [MemberData(nameof(_00005_LongestPalindromicSubstring_Data))]
        public void LongestPalindromicSubstring0(string a0, string expected)
        {
            // Act
            string actual = _00005_LongestPalindromicSubstring.LongestPalindromicSubstring0(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00005_LongestPalindromicSubstring_Data))]
        public void LongestPalindromicSubstring1(string a0, string expected)
        {
            // Act
            string actual = _00005_LongestPalindromicSubstring.LongestPalindromicSubstring1(a0);

            int[] t0 = new int[26];
            foreach (char item in expected)
            {
                t0[item - 'a']++;
            }
            Array.Sort(t0);

            int[] t1 = new int[26];
            foreach (char item in actual)
            {
                t1[item - 'a']++;
            }
            Array.Sort(t1);

            bool seq = t0.SequenceEqual(t1);

            // Assert
            Assert.True(seq);
        }
    }
}
