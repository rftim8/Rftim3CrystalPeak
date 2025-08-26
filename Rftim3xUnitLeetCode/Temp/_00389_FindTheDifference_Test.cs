using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00389_FindTheDifference_Test
    {
        // Arrange
        private static readonly string a0 = "abcd";
        private static readonly string a1 = "abcde";
        private static readonly char ar = 'e';

        private static readonly string b0 = "";
        private static readonly string b1 = "y";
        private static readonly char br = 'y';

        public static TheoryData<string, string, char> _00389_FindTheDifference_Data =>
            new()
            {
                { a0, a1, ar },
                { b0, b1, br }
            };

        [Theory]
        [MemberData(nameof(_00389_FindTheDifference_Data))]
        public void FindTheDifference0(string s, string t, char expected)
        {
            // Act
            char actual = _00389_FindTheDifference.FindTheDifference0(s, t);

            // Assert
            //Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00389_FindTheDifference_Data))]
        public void FindTheDifference1(string s, string t, char expected)
        {
            // Act
            char actual = _00389_FindTheDifference.FindTheDifference1(s, t);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
