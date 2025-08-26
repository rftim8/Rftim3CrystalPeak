using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using Rftim3AdventOfCode.Refactor;

namespace Rftim3xUnitAdventOfCode.Unit
{
    public class _05_DoesntHeHaveInternElvesForThis_Test
    {
        // Arrange
        private static readonly List<string> Input = RftAdventOfCodeStaticData.Input_Test(problemName: nameof(_05_DoesntHeHaveInternElvesForThis))!;
        private static readonly int ExpectedPartOne = int.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_05_DoesntHeHaveInternElvesForThis))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_05_DoesntHeHaveInternElvesForThis))![1]);

        public static TheoryData<List<string>, int> _05_DoesntHeHaveInternElvesForThisPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _05_DoesntHeHaveInternElvesForThisPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_05_DoesntHeHaveInternElvesForThisPartOne_Data))]
        public static void RftPartOne(List<string> input, int expected)
        {
            // Act
            int actual = _05_DoesntHeHaveInternElvesForThis.PartOne_Test(input);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_05_DoesntHeHaveInternElvesForThisPartTwo_Data))]
        public static void RftPartTwo(List<string> input, int expected)
        {
            // Act
            int actual = _05_DoesntHeHaveInternElvesForThis.PartTwo_Test(input);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
