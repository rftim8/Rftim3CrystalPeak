using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00459_RepeatedSubstringPattern_Test
    {
        // Arrange
        private static readonly string a0 = "abab";
        private static readonly bool ar = true;

        private static readonly string b0 = "aba";
        private static readonly bool br = false;

        private static readonly string c0 = "abcabcabcabc";
        private static readonly bool cr = true;

        public static TheoryData<string, bool> _00459_RepeatedSubstringPattern_Data =>
            new()
            {
                { a0, ar },
                { b0, br },
                { c0, cr }
            };

        [Theory]
        [MemberData(nameof(_00459_RepeatedSubstringPattern_Data))]
        public void RepeatedSubstringPattern0(string s, bool expected)
        {
            // Act
            bool actual = _00459_RepeatedSubstringPattern.RepeatedSubstringPattern0(s);

            // Assert
            //Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00459_RepeatedSubstringPattern_Data))]
        public void RepeatedSubstringPattern1(string s, bool expected)
        {
            // Act
            bool actual = _00459_RepeatedSubstringPattern.RepeatedSubstringPattern1(s);

            // Assert
            //Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00459_RepeatedSubstringPattern_Data))]
        public void RepeatedSubstringPattern2(string s, bool expected)
        {
            // Act
            bool actual = _00459_RepeatedSubstringPattern.RepeatedSubstringPattern2(s);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
