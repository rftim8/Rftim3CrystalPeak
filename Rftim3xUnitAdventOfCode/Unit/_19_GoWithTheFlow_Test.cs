using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using Rftim3AdventOfCode.Refactor;

namespace Rftim3xUnitAdventOfCode.Unit
{
    public class _19_GoWithTheFlow_Test
    {
        // Arrange
        private static readonly List<string> Input = RftAdventOfCodeStaticData.Input_Test(problemName: nameof(_19_GoWithTheFlow))!;
        private static readonly int ExpectedPartOne = int.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_19_GoWithTheFlow))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_19_GoWithTheFlow))![1]);

        public static TheoryData<List<string>, int> _19_GoWithTheFlowPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _19_GoWithTheFlowPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory(Skip = "Incomplete")]
        [MemberData(nameof(_19_GoWithTheFlowPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _19_GoWithTheFlow.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory(Skip = "Incomplete")]
        [MemberData(nameof(_19_GoWithTheFlowPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _19_GoWithTheFlow.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
