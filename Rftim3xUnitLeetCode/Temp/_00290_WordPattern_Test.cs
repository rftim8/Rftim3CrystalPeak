using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00290_WordPattern_Test
    {
        // Arrange
        private static readonly string a0 = "abba";
        private static readonly string a1 = "dog cat cat dog";
        private static readonly bool ar = true;

        private static readonly string b0 = "abba";
        private static readonly string b1 = "dog cat cat fish";
        private static readonly bool br = false;

        private static readonly string c0 = "aaaa";
        private static readonly string c1 = "dog cat cat dog";
        private static readonly bool cr = false;

        public static TheoryData<string, string, bool> _00290_WordPattern_Data =>
            new()
            {
                { a0, a1, ar },
                { b0, b1, br },
                { c0, c1, cr }
            };

        [Theory]
        [MemberData(nameof(_00290_WordPattern_Data))]
        public void WordPattern0(string pattern, string s, bool expected)
        {
            // Act
            bool actual = _00290_WordPattern.WordPattern0(pattern, s);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
