using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _01968_ArrayWithElementsNotEqualToAverageofNeighbors_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_01968_ArrayWithElementsNotEqualToAverageofNeighbors))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01968_ArrayWithElementsNotEqualToAverageofNeighbors))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01968_ArrayWithElementsNotEqualToAverageofNeighbors))![1]);

        public static TheoryData<List<string>, int> _01968_ArrayWithElementsNotEqualToAverageofNeighborsPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _01968_ArrayWithElementsNotEqualToAverageofNeighborsPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_01968_ArrayWithElementsNotEqualToAverageofNeighborsPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _01968_ArrayWithElementsNotEqualToAverageofNeighbors.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01968_ArrayWithElementsNotEqualToAverageofNeighborsPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _01968_ArrayWithElementsNotEqualToAverageofNeighbors.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
