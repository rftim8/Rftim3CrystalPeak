using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using Rftim3AdventOfCode.Refactor;

namespace Rftim3xUnitAdventOfCode.Unit
{
    public class _22_ReactorReboot_Test
    {
        // Arrange
        private static readonly List<string> Input = RftAdventOfCodeStaticData.Input_Test(problemName: nameof(_22_ReactorReboot))!;
        private static readonly int ExpectedPartOne = int.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_22_ReactorReboot))![0]);
        private static readonly long ExpectedPartTwo = long.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_22_ReactorReboot))![1]);

        public static TheoryData<List<string>, int> _22_ReactorRebootPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, long> _22_ReactorRebootPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_22_ReactorRebootPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _22_ReactorReboot.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_22_ReactorRebootPartTwo_Data))]
        public void RftPartTwo(List<string> a0, long expected)
        {
            // Act
            long actual = _22_ReactorReboot.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
