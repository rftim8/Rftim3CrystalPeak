using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using Rftim3AdventOfCode.Refactor;

namespace Rftim3xUnitAdventOfCode.Unit
{
    public class _07_NoSpaceLeftOnDevice_Test
    {
        // Arrange
        private static readonly List<string> Input = RftAdventOfCodeStaticData.Input_Test(problemName: nameof(_07_NoSpaceLeftOnDevice))!;
        private static readonly int ExpectedPartOne = int.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_07_NoSpaceLeftOnDevice))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_07_NoSpaceLeftOnDevice))![1]);

        public static TheoryData<List<string>, int> _07_NoSpaceLeftOnDevicePartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _07_NoSpaceLeftOnDevicePartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_07_NoSpaceLeftOnDevicePartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _07_NoSpaceLeftOnDevice.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_07_NoSpaceLeftOnDevicePartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _07_NoSpaceLeftOnDevice.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
