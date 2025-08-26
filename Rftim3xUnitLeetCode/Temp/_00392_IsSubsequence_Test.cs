using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00392_IsSubsequence_Test
    {
        // Arrange
        private static readonly string a0 = "abc";
        private static readonly string a1 = "ahbgdc";
        private static readonly bool ar = true;

        private static readonly string b0 = "axc";
        private static readonly string b1 = "ahbgdc";
        private static readonly bool br = false;

        public static TheoryData<string, string, bool> _00392_IsSubsequence_Data =>
            new()
            {
                { a0, a1, ar },
                { b0, b1, br }
            };

        [Theory]
        [MemberData(nameof(_00392_IsSubsequence_Data))]
        public void IsSubsequence0(string s, string t, bool expected)
        {
            // Act
            bool actual = _00392_IsSubsequence.IsSubsequence0(s, t);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
