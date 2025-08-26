using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using Rftim3AdventOfCode.Refactor;

namespace Rftim3xUnitAdventOfCode.Unit
{
    public class _03_GearRatios_Test
    {
        // Arrange
        private static readonly List<string> Input = RftAdventOfCodeStaticData.Input_Test(problemName: nameof(_03_GearRatios))!;
        private static readonly int ExpectedPartOne = int.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_03_GearRatios))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_03_GearRatios))![1]);

        public static TheoryData<List<string>, int> _03_GearRatiosPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _03_GearRatiosPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_03_GearRatiosPartOne_Data))]
        public void PartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _03_GearRatios.PartOne_Test(a0);

            // Assert
            Assert.Equivalent(expected, actual, true);
        }

        [Theory]
        [MemberData(nameof(_03_GearRatiosPartTwo_Data))]
        public void PartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _03_GearRatios.PartTwo_Test(a0);

            // Assert
            Assert.Equivalent(expected, actual, true);
        }
    }
}
