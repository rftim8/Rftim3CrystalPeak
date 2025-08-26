using Rftim3Convoy.Services.Static.CP.CodinGame.Data;
using Rftim3CodinGame.Refactor;

namespace Rftim3xUnitCodinGame.Unit
{
    public class _FoldingPaper_Test
    {
        // Arrange
        private static readonly List<string> Input = RftCodinGameStaticData.Input_Test(problemName: nameof(_FoldingPaper))!;
        private static readonly int ExpectedPartOne = int.Parse(RftCodinGameStaticData.Output_Test(problemName: nameof(_FoldingPaper))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftCodinGameStaticData.Output_Test(problemName: nameof(_FoldingPaper))![1]);

        public static TheoryData<List<string>, int> _FoldingPaperPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _FoldingPaperPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_FoldingPaperPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _FoldingPaper.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_FoldingPaperPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _FoldingPaper.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
