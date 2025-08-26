using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using Rftim3AdventOfCode.Refactor;

namespace Rftim3xUnitAdventOfCode.Unit
{
    public class _04_HighEntropyPassphrases_Test
    {
        // Arrange
        private static readonly List<string> Input = RftAdventOfCodeStaticData.Input_Test(problemName: nameof(_04_HighEntropyPassphrases))!;
        private static readonly int ExpectedPartOne = int.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_04_HighEntropyPassphrases))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_04_HighEntropyPassphrases))![1]);

        public static TheoryData<List<string>, int> _04_HighEntropyPassphrasesPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _04_HighEntropyPassphrasesPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_04_HighEntropyPassphrasesPartOne_Data))]
        public void RftPartOne(List<string> input, int expected)
        {
            // Act
            int actual = _04_HighEntropyPassphrases.PartOne_Test(input);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_04_HighEntropyPassphrasesPartTwo_Data))]
        public void RftPartTwo(List<string> input, int expected)
        {
            // Act
            int actual = _04_HighEntropyPassphrases.PartTwo_Test(input);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
