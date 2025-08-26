using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using Rftim3AdventOfCode.Refactor;

namespace Rftim3xUnitAdventOfCode.Unit
{
    public class _07_BridgeRepair_Test
    {
        // Arrange
        private static readonly List<string> Input = RftAdventOfCodeStaticData.Input_Test(problemName: nameof(_07_BridgeRepair))!;
        private static readonly long ExpectedPartOne = long.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_07_BridgeRepair))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_07_BridgeRepair))![1]);

        public static TheoryData<List<string>, long> _07_BridgeRepairPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _07_BridgeRepairPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_07_BridgeRepairPartOne_Data))]
        public void RftPartOne(List<string> a0, long expected)
        {
            // Act
            long actual = _07_BridgeRepair.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_07_BridgeRepairPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _07_BridgeRepair.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
