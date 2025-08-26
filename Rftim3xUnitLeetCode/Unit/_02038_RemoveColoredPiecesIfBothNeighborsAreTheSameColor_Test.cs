using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _02038_RemoveColoredPiecesIfBothNeighborsAreTheSameColor_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_02038_RemoveColoredPiecesIfBothNeighborsAreTheSameColor))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02038_RemoveColoredPiecesIfBothNeighborsAreTheSameColor))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02038_RemoveColoredPiecesIfBothNeighborsAreTheSameColor))![1]);

        public static TheoryData<List<string>, int> _02038_RemoveColoredPiecesIfBothNeighborsAreTheSameColorPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _02038_RemoveColoredPiecesIfBothNeighborsAreTheSameColorPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_02038_RemoveColoredPiecesIfBothNeighborsAreTheSameColorPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _02038_RemoveColoredPiecesIfBothNeighborsAreTheSameColor.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02038_RemoveColoredPiecesIfBothNeighborsAreTheSameColorPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _02038_RemoveColoredPiecesIfBothNeighborsAreTheSameColor.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
