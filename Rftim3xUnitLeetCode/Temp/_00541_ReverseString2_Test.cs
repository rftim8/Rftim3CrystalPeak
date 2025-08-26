using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00541_ReverseString2_Test
    {
        // Arrange
        private static readonly string a0 = "abcdefg";
        private static readonly int a1 = 2;
        private static readonly string ar = "bacdfeg";

        private static readonly string b0 = "abcd";
        private static readonly int b1 = 2;
        private static readonly string br = "bacd";

        public static TheoryData<string, int, string> _00541_ReverseString2_Data =>
            new()
            {
                { a0, a1, ar },
                { b0, b1, br }
            };

        [Theory]
        [MemberData(nameof(_00541_ReverseString2_Data))]
        public void ReverseStr0(string s, int k, string expected)
        {
            // Act
            string actual = _00541_ReverseString2.ReverseStr0(s, k);

            // Assert
            //Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00541_ReverseString2_Data))]
        public void ReverseStr1(string s, int k, string expected)
        {
            // Act
            string actual = _00541_ReverseString2.ReverseStr1(s, k);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
