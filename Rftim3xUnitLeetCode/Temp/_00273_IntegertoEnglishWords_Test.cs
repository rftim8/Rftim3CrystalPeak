using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00273_IntegerToEnglishWords_Test
    {
        // Arrange
        private static readonly int a0 = 123;
        private static readonly string ar = "One Hundred Twenty Three";

        private static readonly int b0 = 12345;
        private static readonly string br = "Twelve Thousand Three Hundred Forty Five";

        private static readonly int c0 = 1234567;
        private static readonly string cr = "One Million Two Hundred Thirty Four Thousand Five Hundred Sixty Seven";

        public static TheoryData<int, string> _00273_IntegerToEnglishWords_Data =>
            new()
            {
                { a0, ar },
                { b0, br },
                { c0, cr }
            };


        [Theory]
        [MemberData(nameof(_00273_IntegerToEnglishWords_Data))]
        public void IntegerToEnglishWords0(int a0, string expected)
        {
            // Act
            string actual = _00273_IntegerToEnglishWords.IntegerToEnglishWords0(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00273_IntegerToEnglishWords_Data))]
        public void IntegerToEnglishWords1(int a0, string expected)
        {
            // Act
            string actual = _00273_IntegerToEnglishWords.IntegerToEnglishWords1(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}