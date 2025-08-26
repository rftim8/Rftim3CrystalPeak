using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00500_KeyboardRow_Test
    {
        // Arrange
        private static readonly string[] a0 = ["Hello", "Alaska", "Dad", "Peace"];
        private static readonly string[] ar = ["Alaska", "Dad"];

        private static readonly string[] b0 = ["omk"];
        private static readonly string[] br = [];

        private static readonly string[] c0 = ["adsdf", "sfd"];
        private static readonly string[] cr = ["adsdf", "sfd"];

        public static TheoryData<string[], string[]> _00500_KeyboardRow_Data =>
            new()
            {
                { a0, ar },
                { b0, br },
                { c0, cr }
            };

        [Theory]
        [MemberData(nameof(_00500_KeyboardRow_Data))]
        public void FindWords0(string[] words, string[] expected)
        {
            // Act
            string[] actual = _00500_KeyboardRow.FindWords0(words);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
