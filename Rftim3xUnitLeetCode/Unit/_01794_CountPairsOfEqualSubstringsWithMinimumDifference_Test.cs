using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _01794_CountPairsOfEqualSubstringsWithMinimumDifference_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_01794_CountPairsOfEqualSubstringsWithMinimumDifference))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01794_CountPairsOfEqualSubstringsWithMinimumDifference))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01794_CountPairsOfEqualSubstringsWithMinimumDifference))![1]);

        public static TheoryData<List<string>, int> _01794_CountPairsOfEqualSubstringsWithMinimumDifferencePartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _01794_CountPairsOfEqualSubstringsWithMinimumDifferencePartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_01794_CountPairsOfEqualSubstringsWithMinimumDifferencePartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _01794_CountPairsOfEqualSubstringsWithMinimumDifference.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01794_CountPairsOfEqualSubstringsWithMinimumDifferencePartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _01794_CountPairsOfEqualSubstringsWithMinimumDifference.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
