using Rftim3Convoy.Services.Static.CP.CodinGame.Data;
using Rftim3CodinGame.Refactor;

namespace Rftim3xUnitCodinGame.Unit
{
    public class _SimplifiedMonopolyTurnsPrediction_Test
    {
        // Arrange
        private static readonly List<string> Input = RftCodinGameStaticData.Input_Test(problemName: nameof(_SimplifiedMonopolyTurnsPrediction))!;
        private static readonly int ExpectedPartOne = int.Parse(RftCodinGameStaticData.Output_Test(problemName: nameof(_SimplifiedMonopolyTurnsPrediction))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftCodinGameStaticData.Output_Test(problemName: nameof(_SimplifiedMonopolyTurnsPrediction))![1]);

        public static TheoryData<List<string>, int> _SimplifiedMonopolyTurnsPredictionPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _SimplifiedMonopolyTurnsPredictionPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_SimplifiedMonopolyTurnsPredictionPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _SimplifiedMonopolyTurnsPrediction.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_SimplifiedMonopolyTurnsPredictionPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _SimplifiedMonopolyTurnsPrediction.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
