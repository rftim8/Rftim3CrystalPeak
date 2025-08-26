using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _01593_SplitaStringIntoTheMaxNumberOfUniqueSubstrings_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_01593_SplitaStringIntoTheMaxNumberOfUniqueSubstrings))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01593_SplitaStringIntoTheMaxNumberOfUniqueSubstrings))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01593_SplitaStringIntoTheMaxNumberOfUniqueSubstrings))![1]);

        public static TheoryData<List<string>, int> _01593_SplitaStringIntoTheMaxNumberOfUniqueSubstringsPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _01593_SplitaStringIntoTheMaxNumberOfUniqueSubstringsPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_01593_SplitaStringIntoTheMaxNumberOfUniqueSubstringsPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _01593_SplitaStringIntoTheMaxNumberOfUniqueSubstrings.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01593_SplitaStringIntoTheMaxNumberOfUniqueSubstringsPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _01593_SplitaStringIntoTheMaxNumberOfUniqueSubstrings.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
