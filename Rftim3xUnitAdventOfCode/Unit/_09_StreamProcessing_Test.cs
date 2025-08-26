using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using Rftim3AdventOfCode.Refactor;

namespace Rftim3xUnitAdventOfCode.Unit
{
    public class _09_StreamProcessing_Test
    {
        // Arrange
        private static readonly List<string> Input = RftAdventOfCodeStaticData.Input_Test(problemName: nameof(_09_StreamProcessing))!;
        private static readonly int ExpectedPartOne = int.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_09_StreamProcessing))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_09_StreamProcessing))![1]);

        public static TheoryData<List<string>, int> _09_StreamProcessingPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _09_StreamProcessingPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_09_StreamProcessingPartOne_Data))]
        public void RftPartOne(List<string> input, int expected)
        {
            // Act
            int actual = _09_StreamProcessing.PartOne_Test(input);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_09_StreamProcessingPartTwo_Data))]
        public void RftPartTwo(List<string> input, int expected)
        {
            // Act
            int actual = _09_StreamProcessing.PartTwo_Test(input);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
