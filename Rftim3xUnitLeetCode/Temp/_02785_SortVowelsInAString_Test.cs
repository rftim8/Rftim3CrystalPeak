using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _02785_SortVowelsInAString_Test
    {
        // Arrange
        private static readonly string a0 = "lEetcOde";
        private static readonly string ar = "lEOtcede";

        private static readonly string b0 = "lYmpH";
        private static readonly string br = "lYmpH";

        public static TheoryData<string, string> _02785_SortVowelsInAString_Data =>
            new()
            {
                { a0, ar },
                { b0, br }
            };

        [Theory]
        [MemberData(nameof(_02785_SortVowelsInAString_Data))]
        public void SortVowels0(string a0, string expected)
        {
            // Act
            string actual = _02785_SortVowelsInAString.SortVowels0(a0);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
