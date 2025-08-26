using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00647_PalindromicSubstrings_Test
    {
        // Arrange
        private static readonly string a0 = "abc";
        private static readonly int ar = 3;

        private static readonly string b0 = "aaa";
        private static readonly int br = 6;

        private static readonly string c0 = "aba";
        private static readonly int cr = 4;

        public static TheoryData<string, int> _00647_PalindromicSubstrings_Data =>
            new()
            {
                { a0, ar },
                { b0, br },
                { c0, cr }
            };

        [Theory]
        [MemberData(nameof(_00647_PalindromicSubstrings_Data))]
        public void PalindromicSubstrings0(string a0, int expected)
        {
            // Act
            int actual = _00647_PalindromicSubstrings.PalindromicSubstrings0(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00647_PalindromicSubstrings_Data))]
        public void PalindromicSubstrings1(string a0, int expected)
        {
            // Act
            int actual = _00647_PalindromicSubstrings.PalindromicSubstrings1(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}