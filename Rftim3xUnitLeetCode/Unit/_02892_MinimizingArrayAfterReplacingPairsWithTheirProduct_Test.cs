using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _02892_MinimizingArrayAfterReplacingPairsWithTheirProduct_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_02892_MinimizingArrayAfterReplacingPairsWithTheirProduct))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02892_MinimizingArrayAfterReplacingPairsWithTheirProduct))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02892_MinimizingArrayAfterReplacingPairsWithTheirProduct))![1]);

        public static TheoryData<List<string>, int> _02892_MinimizingArrayAfterReplacingPairsWithTheirProductPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _02892_MinimizingArrayAfterReplacingPairsWithTheirProductPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_02892_MinimizingArrayAfterReplacingPairsWithTheirProductPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _02892_MinimizingArrayAfterReplacingPairsWithTheirProduct.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02892_MinimizingArrayAfterReplacingPairsWithTheirProductPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _02892_MinimizingArrayAfterReplacingPairsWithTheirProduct.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
