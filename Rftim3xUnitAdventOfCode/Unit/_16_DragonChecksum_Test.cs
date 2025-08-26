using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using Rftim3AdventOfCode.Refactor;

namespace Rftim3xUnitAdventOfCode.Unit
{
    public class _16_DragonChecksum_Test
    {
        // Arrange
        private static readonly List<string> Input = RftAdventOfCodeStaticData.Input_Test(problemName: nameof(_16_DragonChecksum))!;
        private static readonly string ExpectedPartOne = RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_16_DragonChecksum))![0];
        private static readonly string ExpectedPartTwo = RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_16_DragonChecksum))![1];

        public static TheoryData<List<string>, string> _16_DragonChecksumPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, string> _16_DragonChecksumPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_16_DragonChecksumPartOne_Data))]
        public static void RftPartOne(List<string> input, string expected)
        {
            // Act
            string actual = _16_DragonChecksum.PartOne_Test(input);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_16_DragonChecksumPartTwo_Data))]
        public static void RftPartTwo(List<string> input, string expected)
        {
            // Act
            string actual = _16_DragonChecksum.PartTwo_Test(input);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
