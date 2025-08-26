using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00344_ReverseString_Test
    {
        // Arrange
        private static readonly char[] a0 = ['h', 'e', 'l', 'l', 'o'];
        private static readonly char[] ar = ['o', 'l', 'l', 'e', 'h'];

        private static readonly char[] b0 = ['H', 'a', 'n', 'n', 'a', 'h'];
        private static readonly char[] br = ['h', 'a', 'n', 'n', 'a', 'H'];

        public static TheoryData<char[], char[]> _00344_ReverseString_Data =>
            new()
            {
                { a0, ar },
                { b0, br }
            };

        [Theory]
        [MemberData(nameof(_00344_ReverseString_Data))]
        public void ReverseString0(char[] s, char[] expected)
        {
            // Act
            char[] actual = _00344_ReverseString.ReverseString0(s);

            // Assert
            //Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00344_ReverseString_Data))]
        public void ReverseString1(char[] s, char[] expected)
        {
            // Act
            char[] actual = _00344_ReverseString.ReverseString1(s);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
