using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00415_AddStrings_Test
    {
        // Arrange
        private static readonly string a0 = "11";
        private static readonly string a1 = "123";
        private static readonly string ar = "134";

        private static readonly string b0 = "456";
        private static readonly string b1 = "77";
        private static readonly string br = "533";

        private static readonly string c0 = "0";
        private static readonly string c1 = "0";
        private static readonly string cr = "0";

        public static TheoryData<string, string, string> _00415_AddStrings_Data =>
            new()
            {
                { a0, a1, ar },
                { b0, b1, br },
                { c0, c1 ,cr }
            };

        [Theory]
        [MemberData(nameof(_00415_AddStrings_Data))]
        public void AddStrings0(string num1, string num2, string expected)
        {
            // Act
            string actual = _00415_AddStrings.AddStrings0(num1, num2);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
