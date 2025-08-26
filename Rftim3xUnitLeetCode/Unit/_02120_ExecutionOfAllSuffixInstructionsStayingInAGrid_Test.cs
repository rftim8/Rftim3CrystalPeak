using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _02120_ExecutionOfAllSuffixInstructionsStayingInAGrid_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_02120_ExecutionOfAllSuffixInstructionsStayingInAGrid))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02120_ExecutionOfAllSuffixInstructionsStayingInAGrid))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02120_ExecutionOfAllSuffixInstructionsStayingInAGrid))![1]);

        public static TheoryData<List<string>, int> _02120_ExecutionOfAllSuffixInstructionsStayingInAGridPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _02120_ExecutionOfAllSuffixInstructionsStayingInAGridPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_02120_ExecutionOfAllSuffixInstructionsStayingInAGridPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _02120_ExecutionOfAllSuffixInstructionsStayingInAGrid.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02120_ExecutionOfAllSuffixInstructionsStayingInAGridPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _02120_ExecutionOfAllSuffixInstructionsStayingInAGrid.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
