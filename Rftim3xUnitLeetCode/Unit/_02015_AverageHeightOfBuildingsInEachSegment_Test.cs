using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _02015_AverageHeightOfBuildingsInEachSegment_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_02015_AverageHeightOfBuildingsInEachSegment))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02015_AverageHeightOfBuildingsInEachSegment))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02015_AverageHeightOfBuildingsInEachSegment))![1]);

        public static TheoryData<List<string>, int> _02015_AverageHeightOfBuildingsInEachSegmentPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _02015_AverageHeightOfBuildingsInEachSegmentPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_02015_AverageHeightOfBuildingsInEachSegmentPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _02015_AverageHeightOfBuildingsInEachSegment.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02015_AverageHeightOfBuildingsInEachSegmentPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _02015_AverageHeightOfBuildingsInEachSegment.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
