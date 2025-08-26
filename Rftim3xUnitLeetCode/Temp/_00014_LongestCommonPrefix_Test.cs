using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00014_LongestCommonPrefix_Test
    {
        // Arrange
        private static readonly string[] a0 = ["flower", "flow", "flight"];
        private static readonly string ar = "fl";

        private static readonly string[] b0 = ["dog", "racecar", "car"];
        private static readonly string br = "";

        public static TheoryData<string[], string> _00014_LongestCommonPrefix_Data =>
            new()
            {
                { a0, ar },
                { b0, br }
            };

        [Theory]
        [MemberData(nameof(_00014_LongestCommonPrefix_Data))]
        public void LongestCommonPrefix0(string[] strs, string expected)
        {
            // Act
            string actual = _00014_LongestCommonPrefix.LongestCommonPrefix0(strs);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
