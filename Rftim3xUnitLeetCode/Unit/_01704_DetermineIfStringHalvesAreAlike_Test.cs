using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _01704_DetermineIfStringHalvesAreAlike_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_01704_DetermineIfStringHalvesAreAlike))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01704_DetermineIfStringHalvesAreAlike))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01704_DetermineIfStringHalvesAreAlike))![1]);

        public static TheoryData<List<string>, int> _01704_DetermineIfStringHalvesAreAlikePartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _01704_DetermineIfStringHalvesAreAlikePartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_01704_DetermineIfStringHalvesAreAlikePartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _01704_DetermineIfStringHalvesAreAlike.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01704_DetermineIfStringHalvesAreAlikePartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _01704_DetermineIfStringHalvesAreAlike.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
