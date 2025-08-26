using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _01217_MinimumCostToMoveChipsToTheSamePosition_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_01217_MinimumCostToMoveChipsToTheSamePosition))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01217_MinimumCostToMoveChipsToTheSamePosition))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01217_MinimumCostToMoveChipsToTheSamePosition))![1]);

        public static TheoryData<List<string>, int> _01217_MinimumCostToMoveChipsToTheSamePositionPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _01217_MinimumCostToMoveChipsToTheSamePositionPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_01217_MinimumCostToMoveChipsToTheSamePositionPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _01217_MinimumCostToMoveChipsToTheSamePosition.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01217_MinimumCostToMoveChipsToTheSamePositionPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _01217_MinimumCostToMoveChipsToTheSamePosition.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
