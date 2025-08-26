using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _02711_DifferenceOfNumberOfDistinctValuesOnDiagonals_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_02711_DifferenceOfNumberOfDistinctValuesOnDiagonals))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02711_DifferenceOfNumberOfDistinctValuesOnDiagonals))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02711_DifferenceOfNumberOfDistinctValuesOnDiagonals))![1]);

        public static TheoryData<List<string>, int> _02711_DifferenceOfNumberOfDistinctValuesOnDiagonalsPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _02711_DifferenceOfNumberOfDistinctValuesOnDiagonalsPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_02711_DifferenceOfNumberOfDistinctValuesOnDiagonalsPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _02711_DifferenceOfNumberOfDistinctValuesOnDiagonals.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02711_DifferenceOfNumberOfDistinctValuesOnDiagonalsPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _02711_DifferenceOfNumberOfDistinctValuesOnDiagonals.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
