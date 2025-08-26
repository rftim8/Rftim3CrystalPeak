using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _03106_LexicographicallySmallestStringAfterOperationsWithConstraint_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_03106_LexicographicallySmallestStringAfterOperationsWithConstraint))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_03106_LexicographicallySmallestStringAfterOperationsWithConstraint))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_03106_LexicographicallySmallestStringAfterOperationsWithConstraint))![1]);

        public static TheoryData<List<string>, int> _03106_LexicographicallySmallestStringAfterOperationsWithConstraintPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _03106_LexicographicallySmallestStringAfterOperationsWithConstraintPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_03106_LexicographicallySmallestStringAfterOperationsWithConstraintPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _03106_LexicographicallySmallestStringAfterOperationsWithConstraint.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_03106_LexicographicallySmallestStringAfterOperationsWithConstraintPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _03106_LexicographicallySmallestStringAfterOperationsWithConstraint.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
