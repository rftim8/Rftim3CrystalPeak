using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using Rftim3AdventOfCode.Refactor;

namespace Rftim3xUnitAdventOfCode.Unit
{
    public class _03_SpiralMemory_Test
    {
        // Arrange
        private static readonly List<string> Input = RftAdventOfCodeStaticData.Input_Test(problemName: nameof(_03_SpiralMemory))!;
        private static readonly int ExpectedPartOne = int.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_03_SpiralMemory))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_03_SpiralMemory))![1]);

        public static TheoryData<List<string>, int> _03_SpiralMemoryPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };
        public static TheoryData<List<string>, int> _03_SpiralMemoryPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_03_SpiralMemoryPartOne_Data))]
        public void RftPartOne(List<string> input, int expected)
        {
            // Act
            int actual = _03_SpiralMemory.PartOne_Test(input);

            // Assert
            Assert.Equivalent(expected, actual, true);
        }

        [Theory]
        [MemberData(nameof(_03_SpiralMemoryPartTwo_Data))]
        public void RftPartTwo(List<string> input, int expected)
        {
            // Act
            int actual = _03_SpiralMemory.PartTwo_Test(input);

            // Assert
            Assert.Equivalent(expected, actual, true);
        }
    }
}
