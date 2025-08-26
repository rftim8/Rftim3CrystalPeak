using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00186_ReverseWordsInAStringII_Test
    {
        // Arrange
        private static readonly char[] a0 = [], ar = [];

        private static readonly char[] b0 = [], br = [];

        public static TheoryData<char[], char[]> _00186_ReverseWordsInAStringII_Data =>
            new()
            {
                { a0, ar },
                { b0, br }
            };


        [Theory]
        [MemberData(nameof(_00186_ReverseWordsInAStringII_Data))]
        public void ReverseWordsInAStringII0(char[] a0, char[] expected)
        {
            // Act
            char[] actual = _00186_ReverseWordsInAStringII.ReverseWordsInAStringII0(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00186_ReverseWordsInAStringII_Data))]
        public void ReverseWordsInAStringII1(char[] a0, char[] expected)
        {
            // Act
            char[] actual = _00186_ReverseWordsInAStringII.ReverseWordsInAStringII1(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}