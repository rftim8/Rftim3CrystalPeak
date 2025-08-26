using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using Rftim3AdventOfCode.Refactor;

namespace Rftim3xUnitAdventOfCode.Unit
{
    public class _17_TwoStepsForward_Test
    {
        // Arrange
        private static readonly List<string> Input = RftAdventOfCodeStaticData.Input_Test(problemName: nameof(_17_TwoStepsForward))!;
        private static readonly string ExpectedPartOne = RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_17_TwoStepsForward))![0];
        private static readonly int ExpectedPartTwo = int.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_17_TwoStepsForward))![1]);

        public static TheoryData<List<string>, string> _17_TwoStepsForwardPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _17_TwoStepsForwardPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_17_TwoStepsForwardPartOne_Data))]
        public static void RftPartOne(List<string> input, string expected)
        {
            // Act
            string actual = _17_TwoStepsForward.PartOne_Test(input);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_17_TwoStepsForwardPartTwo_Data))]
        public static void RftPartTwo(List<string> input, int expected)
        {
            // Act
            int actual = _17_TwoStepsForward.PartTwo_Test(input);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
