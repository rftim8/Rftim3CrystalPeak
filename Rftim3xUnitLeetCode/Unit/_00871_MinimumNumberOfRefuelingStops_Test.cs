using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _00871_MinimumNumberOfRefuelingStops_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_00871_MinimumNumberOfRefuelingStops))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_00871_MinimumNumberOfRefuelingStops))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_00871_MinimumNumberOfRefuelingStops))![1]);

        public static TheoryData<List<string>, int> _00871_MinimumNumberOfRefuelingStopsPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _00871_MinimumNumberOfRefuelingStopsPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_00871_MinimumNumberOfRefuelingStopsPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _00871_MinimumNumberOfRefuelingStops.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00871_MinimumNumberOfRefuelingStopsPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _00871_MinimumNumberOfRefuelingStops.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
