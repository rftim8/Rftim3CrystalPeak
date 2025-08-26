namespace Rftim3xUnitLeetCode.Temp
{
    public class _00058_LengthOfLastWord_Test
    {
        // Arrange
        private static readonly string a0 = "Hello World";
        private static readonly int ar = 5;

        private static readonly string b0 = "   fly me   to   the moon  ";
        private static readonly int br = 4;

        private static readonly string c0 = "luffy is still joyboy";
        private static readonly int cr = 6;

        public static TheoryData<string, int> _00058_LengthOfLastWord_Data =>
            new()
            {
                { a0, ar },
                { b0, br },
                { c0, cr }
            };

        [Theory]
        [MemberData(nameof(_00058_LengthOfLastWord_Data))]
        public void LengthOfLastWord0(string s, int expected)
        {
            // Act
            //int actual = _00058_LengthOfLastWord.LengthOfLastWord0(s);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
