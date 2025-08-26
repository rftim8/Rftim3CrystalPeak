using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00017_LetterCombinationsOfAPhoneNumber_Test
    {
        // Arrange
        private static readonly string a0 = "23";
        private static readonly List<string> ar = ["ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf"];

        private static readonly string b0 = "";
        private static readonly List<string> br = [];

        private static readonly string c0 = "2";
        private static readonly List<string> cr = ["a", "b", "c"];

        public static TheoryData<string, List<string>> _00017_LetterCombinationsOfAPhoneNumber_Data =>
            new()
            {
                { a0, ar },
                { b0, br },
                { c0, cr }
            };


        [Theory]
        [MemberData(nameof(_00017_LetterCombinationsOfAPhoneNumber_Data))]
        public void LetterCombinationsOfAPhoneNumber0(string a0, List<string> expected)
        {
            // Act
            IList<string> actual = _00017_LetterCombinationsOfAPhoneNumber.LetterCombinationsOfAPhoneNumber0(a0);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}