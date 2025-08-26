using Rftim3Convoy.Services.Static.CP.CodinGame.Data;
using Rftim3CodinGame.Refactor;

namespace Rftim3xUnitCodinGame.Unit
{
    public class _CircularAutomationThePeriodOfChaos_Test
    {
        // Arrange
        private static readonly List<string> Input = RftCodinGameStaticData.Input_Test(problemName: nameof(_CircularAutomationThePeriodOfChaos))!;
        private static readonly int ExpectedPartOne = int.Parse(RftCodinGameStaticData.Output_Test(problemName: nameof(_CircularAutomationThePeriodOfChaos))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftCodinGameStaticData.Output_Test(problemName: nameof(_CircularAutomationThePeriodOfChaos))![1]);

        public static TheoryData<List<string>, int> _CircularAutomationThePeriodOfChaosPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _CircularAutomationThePeriodOfChaosPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_CircularAutomationThePeriodOfChaosPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _CircularAutomationThePeriodOfChaos.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_CircularAutomationThePeriodOfChaosPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _CircularAutomationThePeriodOfChaos.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
