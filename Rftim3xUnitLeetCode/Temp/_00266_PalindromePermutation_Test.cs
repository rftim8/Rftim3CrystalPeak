using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00266_PalindromePermutation_Test
    {
        // Arrange
        private static readonly string a0 = "code";
        private static readonly bool ar = false;

        private static readonly string b0 = "aab";
        private static readonly bool br = true;

        private static readonly string c0 = "carerac";
        private static readonly bool cr = true;

        public static TheoryData<string, bool> _00266_PalindromePermutation_Data =>
            new()
            {
                { a0, ar },
                { b0, br },
                { c0, cr }
            };

        [Theory]
        [MemberData(nameof(_00266_PalindromePermutation_Data))]
        public void PalindromePermutation0(string a0, bool expected)
        {
            // Act
            bool actual = _00266_PalindromePermutation.PalindromePermutation0(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00266_PalindromePermutation_Data))]
        public void PalindromePermutation1(string a0, bool expected)
        {
            // Act
            bool actual = _00266_PalindromePermutation.PalindromePermutation1(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}