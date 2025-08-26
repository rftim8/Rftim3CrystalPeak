using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _02904_ShortestAndLexicographicallySmallestBeautifulString_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_02904_ShortestAndLexicographicallySmallestBeautifulString))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02904_ShortestAndLexicographicallySmallestBeautifulString))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02904_ShortestAndLexicographicallySmallestBeautifulString))![1]);

        public static TheoryData<List<string>, int> _02904_ShortestAndLexicographicallySmallestBeautifulStringPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _02904_ShortestAndLexicographicallySmallestBeautifulStringPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_02904_ShortestAndLexicographicallySmallestBeautifulStringPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _02904_ShortestAndLexicographicallySmallestBeautifulString.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02904_ShortestAndLexicographicallySmallestBeautifulStringPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _02904_ShortestAndLexicographicallySmallestBeautifulString.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
