using Rftim3Convoy.Services.Static.CP.CodinGame.Data;
using Rftim3CodinGame.Refactor;

namespace Rftim3xUnitCodinGame.Unit
{
    public class _ReverseMinesweeper_Test
    {
        // Arrange
        private static readonly List<string> Input = RftCodinGameStaticData.Input_Test(problemName: nameof(_ReverseMinesweeper))!;
        private static readonly int ExpectedPartOne = int.Parse(RftCodinGameStaticData.Output_Test(problemName: nameof(_ReverseMinesweeper))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftCodinGameStaticData.Output_Test(problemName: nameof(_ReverseMinesweeper))![1]);

        public static TheoryData<List<string>, int> _ReverseMinesweeperPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _ReverseMinesweeperPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_ReverseMinesweeperPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _ReverseMinesweeper.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_ReverseMinesweeperPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _ReverseMinesweeper.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
