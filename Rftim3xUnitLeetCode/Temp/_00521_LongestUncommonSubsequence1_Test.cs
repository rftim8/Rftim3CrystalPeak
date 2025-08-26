namespace Rftim3xUnitLeetCode.Temp
{
    public class _00521_LongestUncommonSubsequence1_Test
    {
        // Arrange
        private static readonly string a0 = "aba";
        private static readonly string a1 = "cdc";
        private static readonly int ar = 3;

        private static readonly string b0 = "aaa";
        private static readonly string b1 = "bbb";
        private static readonly int br = 3;

        private static readonly string c0 = "aaa";
        private static readonly string c1 = "aaa";
        private static readonly int cr = -1;

        public static TheoryData<string, string, int> _00521_LongestUncommonSubsequence1_Data =>
            new()
            {
                { a0, a1, ar },
                { b0, b1, br },
                { c0, c1, cr }
            };

        [Theory]
        [MemberData(nameof(_00521_LongestUncommonSubsequence1_Data))]
        public void FindLUSlength0(string a, string b, int expected)
        {
            // Act
            //int actual = _00521_LongestUncommonSubsequence1.FindLUSlength0(a, b);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
