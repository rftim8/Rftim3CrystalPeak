using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00125_ValidPalindrome_Test
    {
        // Arrange
        private static readonly string a0 = "A man, a plan, a canal: Panama";
        private static readonly bool ar = true;

        private static readonly string b0 = "race a car";
        private static readonly bool br = false;

        private static readonly string c0 = " ";
        private static readonly bool cr = true;

        public static TheoryData<string, bool> _00125_ValidPalindrome_Data =>
            new()
            {
                { a0, ar },
                { b0, br },
                { c0, cr }
            };

        [Theory]
        [MemberData(nameof(_00125_ValidPalindrome_Data))]
        public void IsPalindrome0(string s, bool expected)
        {
            // Act
            bool actual = _00125_ValidPalindrome.IsPalindrome0(s);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
