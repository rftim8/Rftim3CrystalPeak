using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _01621_NumberOfSetsOfKNonOverlappingLineSegments_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_01621_NumberOfSetsOfKNonOverlappingLineSegments))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01621_NumberOfSetsOfKNonOverlappingLineSegments))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01621_NumberOfSetsOfKNonOverlappingLineSegments))![1]);

        public static TheoryData<List<string>, int> _01621_NumberOfSetsOfKNonOverlappingLineSegmentsPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _01621_NumberOfSetsOfKNonOverlappingLineSegmentsPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_01621_NumberOfSetsOfKNonOverlappingLineSegmentsPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _01621_NumberOfSetsOfKNonOverlappingLineSegments.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01621_NumberOfSetsOfKNonOverlappingLineSegmentsPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _01621_NumberOfSetsOfKNonOverlappingLineSegments.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
