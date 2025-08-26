using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _01334_FindtheCityWiththeSmallestNumberOfNeighborsAtAThresholdDistance_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_01334_FindtheCityWiththeSmallestNumberOfNeighborsAtAThresholdDistance))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01334_FindtheCityWiththeSmallestNumberOfNeighborsAtAThresholdDistance))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01334_FindtheCityWiththeSmallestNumberOfNeighborsAtAThresholdDistance))![1]);

        public static TheoryData<List<string>, int> _01334_FindtheCityWiththeSmallestNumberOfNeighborsAtAThresholdDistancePartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _01334_FindtheCityWiththeSmallestNumberOfNeighborsAtAThresholdDistancePartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_01334_FindtheCityWiththeSmallestNumberOfNeighborsAtAThresholdDistancePartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _01334_FindtheCityWiththeSmallestNumberOfNeighborsAtAThresholdDistance.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01334_FindtheCityWiththeSmallestNumberOfNeighborsAtAThresholdDistancePartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _01334_FindtheCityWiththeSmallestNumberOfNeighborsAtAThresholdDistance.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
