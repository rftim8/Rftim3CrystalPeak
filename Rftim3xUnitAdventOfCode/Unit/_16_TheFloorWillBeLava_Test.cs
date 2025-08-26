using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using Rftim3AdventOfCode.Refactor;

namespace Rftim3xUnitAdventOfCode.Unit
{
    public class _16_TheFloorWillBeLava_Test
    {
        // Arrange
        private static readonly List<string> Input = RftAdventOfCodeStaticData.Input_Test(problemName: nameof(_16_TheFloorWillBeLava))!;
        private static readonly long ExpectedPartOne = long.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_16_TheFloorWillBeLava))![0]);
        private static readonly long ExpectedPartTwo = long.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_16_TheFloorWillBeLava))![1]);

        public static TheoryData<List<string>, long> _16_TheFloorWillBeLavaPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, long> _16_TheFloorWillBeLavaPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_16_TheFloorWillBeLavaPartOne_Data))]
        public void PartOne(List<string> a0, long expected)
        {
            // Act
            long actual = _16_TheFloorWillBeLava.PartOne_Test(a0);

            // Assert
            Assert.Equivalent(expected, actual, true);
        }

        [Theory]
        [MemberData(nameof(_16_TheFloorWillBeLavaPartTwo_Data))]
        public void PartTwo(List<string> a0, long expected)
        {
            // Act
            long actual = _16_TheFloorWillBeLava.PartTwo_Test(a0);

            // Assert
            Assert.Equivalent(expected, actual, true);
        }
    }
}
