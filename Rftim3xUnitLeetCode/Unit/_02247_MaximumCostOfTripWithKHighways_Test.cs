using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _02247_MaximumCostOfTripWithKHighways_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_02247_MaximumCostOfTripWithKHighways))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02247_MaximumCostOfTripWithKHighways))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02247_MaximumCostOfTripWithKHighways))![1]);

        public static TheoryData<List<string>, int> _02247_MaximumCostOfTripWithKHighwaysPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _02247_MaximumCostOfTripWithKHighwaysPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_02247_MaximumCostOfTripWithKHighwaysPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _02247_MaximumCostOfTripWithKHighways.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02247_MaximumCostOfTripWithKHighwaysPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _02247_MaximumCostOfTripWithKHighways.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
