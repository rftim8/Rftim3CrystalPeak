using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _01227_AirplaneSeatAssignmentProbability_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_01227_AirplaneSeatAssignmentProbability))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01227_AirplaneSeatAssignmentProbability))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01227_AirplaneSeatAssignmentProbability))![1]);

        public static TheoryData<List<string>, int> _01227_AirplaneSeatAssignmentProbabilityPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _01227_AirplaneSeatAssignmentProbabilityPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_01227_AirplaneSeatAssignmentProbabilityPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _01227_AirplaneSeatAssignmentProbability.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01227_AirplaneSeatAssignmentProbabilityPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _01227_AirplaneSeatAssignmentProbability.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
