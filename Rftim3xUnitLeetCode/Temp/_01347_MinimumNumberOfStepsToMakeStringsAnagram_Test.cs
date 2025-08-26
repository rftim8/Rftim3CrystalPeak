namespace Rftim3xUnitLeetCode.Temp
{
    public class _01347_MinimumNumberOfStepsToMakeStringsAnagram_Test
    {
        // Arrange
        private static readonly string a0 = "bab";
        private static readonly string a1 = "aba";
        private static readonly int ar = 1;

        private static readonly string b0 = "leetcode";
        private static readonly string b1 = "practice";
        private static readonly int br = 5;

        private static readonly string c0 = "anagram";
        private static readonly string c1 = "mangaar";
        private static readonly int cr = 0;

        public static TheoryData<string, string, int> _01347_MinimumNumberOfStepsToMakeStringsAnagram_Data =>
            new()
            {
                { a0, a1, ar },
                { b0, b1, br },
                { c0, c1, cr }
            };

        [Theory]
        [MemberData(nameof(_01347_MinimumNumberOfStepsToMakeStringsAnagram_Data))]
        public void MinSteps0(string a0, string a1, int expected)
        {
            // Act
            //int actual = _01347_MinimumNumberOfStepsToMakeStringsAnagram.MinSteps0(a0, a1);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
