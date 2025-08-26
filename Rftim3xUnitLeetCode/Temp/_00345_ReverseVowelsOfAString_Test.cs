using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00345_ReverseVowelsOfAString_Test
    {
        // Arrange
        private static readonly string a0 = "hello";
        private static readonly string ar = "holle";

        private static readonly string b0 = "leetcode";
        private static readonly string br = "leotcede";

        public static TheoryData<string, string> _00345_ReverseVowelsOfAString_Data =>
            new()
            {
                { a0, ar },
                { b0, br }
            };

        [Theory]
        [MemberData(nameof(_00345_ReverseVowelsOfAString_Data))]
        public void ReverseVowels0(string s, string expected)
        {
            // Act
            string actual = _00345_ReverseVowelsOfAString.ReverseVowels0(s);

            // Assert
            //Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00345_ReverseVowelsOfAString_Data))]
        public void ReverseVowels1(string s, string expected)
        {
            // Act
            string actual = _00345_ReverseVowelsOfAString.ReverseVowels1(s);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
