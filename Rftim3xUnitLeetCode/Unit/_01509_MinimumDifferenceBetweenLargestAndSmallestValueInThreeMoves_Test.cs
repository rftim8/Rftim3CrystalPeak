using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _01509_MinimumDifferenceBetweenLargestAndSmallestValueInThreeMoves_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_01509_MinimumDifferenceBetweenLargestAndSmallestValueInThreeMoves))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01509_MinimumDifferenceBetweenLargestAndSmallestValueInThreeMoves))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01509_MinimumDifferenceBetweenLargestAndSmallestValueInThreeMoves))![1]);

        public static TheoryData<List<string>, int> _01509_MinimumDifferenceBetweenLargestAndSmallestValueInThreeMovesPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _01509_MinimumDifferenceBetweenLargestAndSmallestValueInThreeMovesPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_01509_MinimumDifferenceBetweenLargestAndSmallestValueInThreeMovesPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _01509_MinimumDifferenceBetweenLargestAndSmallestValueInThreeMoves.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01509_MinimumDifferenceBetweenLargestAndSmallestValueInThreeMovesPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _01509_MinimumDifferenceBetweenLargestAndSmallestValueInThreeMoves.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
