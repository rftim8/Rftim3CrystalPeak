using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00383_RansomNote_Test
    {
        // Arrange
        private static readonly string a0 = "a";
        private static readonly string a1 = "b";
        private static readonly bool ar = false;

        private static readonly string b0 = "aa";
        private static readonly string b1 = "ab";
        private static readonly bool br = false;

        private static readonly string c0 = "aa";
        private static readonly string c1 = "aab";
        private static readonly bool cr = true;

        public static TheoryData<string, string, bool> _00383_RansomNote_Data =>
            new()
            {
                { a0, a1, ar },
                { b0, b1, br },
                { c0, c1, cr }
            };

        [Theory]
        [MemberData(nameof(_00383_RansomNote_Data))]
        public void CanConstruct0(string ransomNote, string magazine, bool expected)
        {
            // Act
            bool actual = _00383_RansomNote.CanConstruct0(ransomNote, magazine);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
