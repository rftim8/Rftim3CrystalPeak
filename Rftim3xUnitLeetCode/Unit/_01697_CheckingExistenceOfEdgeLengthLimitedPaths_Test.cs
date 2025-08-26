using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _01697_CheckingExistenceOfEdgeLengthLimitedPaths_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_01697_CheckingExistenceOfEdgeLengthLimitedPaths))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01697_CheckingExistenceOfEdgeLengthLimitedPaths))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01697_CheckingExistenceOfEdgeLengthLimitedPaths))![1]);

        public static TheoryData<List<string>, int> _01697_CheckingExistenceOfEdgeLengthLimitedPathsPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _01697_CheckingExistenceOfEdgeLengthLimitedPathsPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_01697_CheckingExistenceOfEdgeLengthLimitedPathsPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _01697_CheckingExistenceOfEdgeLengthLimitedPaths.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01697_CheckingExistenceOfEdgeLengthLimitedPathsPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _01697_CheckingExistenceOfEdgeLengthLimitedPaths.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
