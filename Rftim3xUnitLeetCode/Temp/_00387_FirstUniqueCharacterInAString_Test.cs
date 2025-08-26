namespace Rftim3xUnitLeetCode.Temp
{
    public class _00387_FirstUniqueCharacterInAString_Test
    {
        // Arrange
        private static readonly string a0 = "leetcode";
        private static readonly int ar = 0;

        private static readonly string b0 = "loveleetcode";
        private static readonly int br = 2;

        private static readonly string c0 = "aabb";
        private static readonly int cr = -1;

        public static TheoryData<string, int> _00387_FirstUniqueCharacterInAString_Data =>
            new()
            {
                { a0, ar },
                { b0, br },
                { c0, cr }
            };

        [Theory]
        [MemberData(nameof(_00387_FirstUniqueCharacterInAString_Data))]
        public void FirstUniqChar0(string s, int expected)
        {
            // Act
            //int actual = _00387_FirstUniqueCharacterInAString.FirstUniqChar0(s);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
