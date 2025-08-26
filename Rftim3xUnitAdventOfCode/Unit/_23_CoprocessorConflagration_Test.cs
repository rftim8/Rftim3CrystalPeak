using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using Rftim3AdventOfCode.Refactor;

namespace Rftim3xUnitAdventOfCode.Unit
{
    public class _23_CoprocessorConflagration_Test
    {
        // Arrange
        private static readonly List<string> Input = RftAdventOfCodeStaticData.Input_Test(problemName: nameof(_23_CoprocessorConflagration))!;
        private static readonly int ExpectedPartOne = int.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_23_CoprocessorConflagration))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_23_CoprocessorConflagration))![1]);

        public static TheoryData<List<string>, int> _23_CoprocessorConflagrationPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _23_CoprocessorConflagrationPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory(Skip = "Incomplete")]
        [MemberData(nameof(_23_CoprocessorConflagrationPartOne_Data))]
        public void RftPartOne(List<string> input, int expected)
        {
            // Act
            int actual = _23_CoprocessorConflagration.PartOne_Test(input);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory(Skip = "Incomplete")]
        [MemberData(nameof(_23_CoprocessorConflagrationPartTwo_Data))]
        public void RftPartTwo(List<string> input, int expected)
        {
            // Act
            int actual = _23_CoprocessorConflagration.PartTwo_Test(input);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
