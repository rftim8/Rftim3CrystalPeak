using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using Rftim3AdventOfCode.Refactor;

namespace Rftim3xUnitAdventOfCode.Unit
{
    public class _25_TheHaltingProblem_Test
    {
        // Arrange
        private static readonly List<string> Input = RftAdventOfCodeStaticData.Input_Test(problemName: nameof(_25_TheHaltingProblem))!;
        private static readonly int ExpectedPartOne = int.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_25_TheHaltingProblem))![0]);

        public static TheoryData<List<string>, int> _25_TheHaltingProblemPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        [Theory(Skip = "Incomplete")]
        [MemberData(nameof(_25_TheHaltingProblemPartOne_Data))]
        public void RftPartOne(List<string> input, int expected)
        {
            // Act
            int actual = _25_TheHaltingProblem.PartOne_Test(input);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
