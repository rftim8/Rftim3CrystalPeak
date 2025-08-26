using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00242_ValidAnagram_Test
    {
        // Arrange
        private static readonly string a0 = "anagram";
        private static readonly string a1 = "nagaram";
        private static readonly bool ar = true;

        private static readonly string b0 = "rat";
        private static readonly string b1 = "cat";
        private static readonly bool br = false;

        public static TheoryData<string, string, bool> _00242_ValidAnagram_Data =>
            new()
            {
                { a0, a1, ar },
                { b0, b1, br }
            };

        [Theory]
        [MemberData(nameof(_00242_ValidAnagram_Data))]
        public void IsAnagram0(string s, string t, bool expected)
        {
            // Act
            bool actual = _00242_ValidAnagram.IsAnagram0(s, t);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
