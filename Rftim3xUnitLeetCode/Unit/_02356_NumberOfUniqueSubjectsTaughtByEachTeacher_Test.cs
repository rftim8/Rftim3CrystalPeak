using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _02356_NumberOfUniqueSubjectsTaughtByEachTeacher_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_02356_NumberOfUniqueSubjectsTaughtByEachTeacher))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02356_NumberOfUniqueSubjectsTaughtByEachTeacher))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02356_NumberOfUniqueSubjectsTaughtByEachTeacher))![1]);

        public static TheoryData<List<string>, int> _02356_NumberOfUniqueSubjectsTaughtByEachTeacherPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _02356_NumberOfUniqueSubjectsTaughtByEachTeacherPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_02356_NumberOfUniqueSubjectsTaughtByEachTeacherPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _02356_NumberOfUniqueSubjectsTaughtByEachTeacher.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02356_NumberOfUniqueSubjectsTaughtByEachTeacherPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _02356_NumberOfUniqueSubjectsTaughtByEachTeacher.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
