using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _01941_CheckIfAllCharactersHaveEqualNumberOfOccurrences_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_01941_CheckIfAllCharactersHaveEqualNumberOfOccurrences))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01941_CheckIfAllCharactersHaveEqualNumberOfOccurrences))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01941_CheckIfAllCharactersHaveEqualNumberOfOccurrences))![1]);

        public static TheoryData<List<string>, int> _01941_CheckIfAllCharactersHaveEqualNumberOfOccurrencesPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _01941_CheckIfAllCharactersHaveEqualNumberOfOccurrencesPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_01941_CheckIfAllCharactersHaveEqualNumberOfOccurrencesPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _01941_CheckIfAllCharactersHaveEqualNumberOfOccurrences.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01941_CheckIfAllCharactersHaveEqualNumberOfOccurrencesPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _01941_CheckIfAllCharactersHaveEqualNumberOfOccurrences.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
