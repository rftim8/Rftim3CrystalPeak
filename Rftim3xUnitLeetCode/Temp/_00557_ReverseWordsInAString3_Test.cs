using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00557_ReverseWordsInAString3_Test
    {
        // Arrange
        private static readonly string a0 = "Let's take LeetCode contest";
        private static readonly string ar = "s'teL ekat edoCteeL tsetnoc";

        private static readonly string b0 = "God Ding";
        private static readonly string br = "doG gniD";

        public static TheoryData<string, string> _00557_ReverseWordsInAString3_Data =>
            new()
            {
                { a0, ar },
                { b0, br }
            };

        [Theory]
        [MemberData(nameof(_00557_ReverseWordsInAString3_Data))]
        public void ReverseWords0(string s, string expected)
        {
            // Act
            string actual = _00557_ReverseWordsInAString3.ReverseWords0(s);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
