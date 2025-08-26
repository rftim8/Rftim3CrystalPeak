using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00293_FlipGame_Test
    {
        // Arrange
        private static readonly string a0 = "++++";
        private static readonly List<string> ar = ["--++", "+--+", "++--"];

        private static readonly string b0 = "+";
        private static readonly List<string> br = [];

        public static TheoryData<string, List<string>> _00293_FlipGame_Data =>
            new()
            {
                { a0, ar },
                { b0, br }
            };

        [Theory]
        [MemberData(nameof(_00293_FlipGame_Data))]
        public void FlipGame0(string a0, List<string> expected)
        {
            // Act
            IList<string> actual = _00293_FlipGame.FlipGame0(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00293_FlipGame_Data))]
        public void FlipGame1(string a0, List<string> expected)
        {
            // Act
            IList<string> actual = _00293_FlipGame.FlipGame1(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}