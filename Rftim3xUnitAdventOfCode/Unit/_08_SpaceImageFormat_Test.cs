using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using Rftim3AdventOfCode.Refactor;

namespace Rftim3xUnitAdventOfCode.Unit
{
    public class _08_SpaceImageFormat_Test
    {
        // Arrange
        private static readonly List<string> Input = RftAdventOfCodeStaticData.Input_Test(problemName: nameof(_08_SpaceImageFormat))!;
        private static readonly int ExpectedPartOne = int.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_08_SpaceImageFormat))![0]);
        private static readonly string ExpectedPartTwo = RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_08_SpaceImageFormat))![1];

        public static TheoryData<List<string>, int> _08_SpaceImageFormatPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, string> _08_SpaceImageFormatPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory(Skip = "Incomplete")]
        [MemberData(nameof(_08_SpaceImageFormatPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _08_SpaceImageFormat.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory(Skip = "Incomplete")]
        [MemberData(nameof(_08_SpaceImageFormatPartTwo_Data))]
        public void RftPartTwo(List<string> a0, string expected)
        {
            // Act
            string actual = _08_SpaceImageFormat.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
