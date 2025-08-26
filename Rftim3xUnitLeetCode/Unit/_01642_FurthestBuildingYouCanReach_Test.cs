using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _01642_FurthestBuildingYouCanReach_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_01642_FurthestBuildingYouCanReach))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01642_FurthestBuildingYouCanReach))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01642_FurthestBuildingYouCanReach))![1]);

        public static TheoryData<List<string>, int> _01642_FurthestBuildingYouCanReachPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _01642_FurthestBuildingYouCanReachPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_01642_FurthestBuildingYouCanReachPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _01642_FurthestBuildingYouCanReach.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01642_FurthestBuildingYouCanReachPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _01642_FurthestBuildingYouCanReach.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
