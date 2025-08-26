using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _03038_MaximumNumberOfOperationsWithTheSameScoreI_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_03038_MaximumNumberOfOperationsWithTheSameScoreI))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_03038_MaximumNumberOfOperationsWithTheSameScoreI))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_03038_MaximumNumberOfOperationsWithTheSameScoreI))![1]);

        public static TheoryData<List<string>, int> _03038_MaximumNumberOfOperationsWithTheSameScoreIPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _03038_MaximumNumberOfOperationsWithTheSameScoreIPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_03038_MaximumNumberOfOperationsWithTheSameScoreIPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _03038_MaximumNumberOfOperationsWithTheSameScoreI.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_03038_MaximumNumberOfOperationsWithTheSameScoreIPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _03038_MaximumNumberOfOperationsWithTheSameScoreI.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
