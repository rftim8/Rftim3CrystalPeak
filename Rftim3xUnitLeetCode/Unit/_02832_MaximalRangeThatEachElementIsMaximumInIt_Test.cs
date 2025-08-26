using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _02832_MaximalRangeThatEachElementIsMaximumInIt_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_02832_MaximalRangeThatEachElementIsMaximumInIt))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02832_MaximalRangeThatEachElementIsMaximumInIt))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02832_MaximalRangeThatEachElementIsMaximumInIt))![1]);

        public static TheoryData<List<string>, int> _02832_MaximalRangeThatEachElementIsMaximumInItPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _02832_MaximalRangeThatEachElementIsMaximumInItPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_02832_MaximalRangeThatEachElementIsMaximumInItPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _02832_MaximalRangeThatEachElementIsMaximumInIt.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02832_MaximalRangeThatEachElementIsMaximumInItPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _02832_MaximalRangeThatEachElementIsMaximumInIt.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
