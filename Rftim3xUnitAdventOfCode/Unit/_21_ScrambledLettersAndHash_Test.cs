using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using Rftim3AdventOfCode;

namespace Rftim3xUnitAdventOfCode.Unit
{
    public class _21_ScrambledLettersAndHash_Test
    {
        // Arrange
        private static readonly List<string> Input = RftAdventOfCodeStaticData.Input_Test(problemName: nameof(_21_ScrambledLettersAndHash))!;
        private static readonly string ExpectedPartOne = RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_21_ScrambledLettersAndHash))![0];
        private static readonly string ExpectedPartTwo = RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_21_ScrambledLettersAndHash))![1];

        public static TheoryData<List<string>, string> _21_ScrambledLettersAndHashPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, string> _21_ScrambledLettersAndHashPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_21_ScrambledLettersAndHashPartOne_Data))]
        public static void RftPartOne(List<string> input, string expected)
        {
            // Act
            string actual = _21_ScrambledLettersAndHash.PartOne_Test(input);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_21_ScrambledLettersAndHashPartTwo_Data))]
        public static void RftPartTwo(List<string> input, string expected)
        {
            // Act
            string actual = _21_ScrambledLettersAndHash.PartTwo_Test(input);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
