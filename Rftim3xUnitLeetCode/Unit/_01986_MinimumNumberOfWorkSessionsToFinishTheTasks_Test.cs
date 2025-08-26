using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _01986_MinimumNumberOfWorkSessionsToFinishTheTasks_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_01986_MinimumNumberOfWorkSessionsToFinishTheTasks))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01986_MinimumNumberOfWorkSessionsToFinishTheTasks))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01986_MinimumNumberOfWorkSessionsToFinishTheTasks))![1]);

        public static TheoryData<List<string>, int> _01986_MinimumNumberOfWorkSessionsToFinishTheTasksPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _01986_MinimumNumberOfWorkSessionsToFinishTheTasksPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_01986_MinimumNumberOfWorkSessionsToFinishTheTasksPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _01986_MinimumNumberOfWorkSessionsToFinishTheTasks.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01986_MinimumNumberOfWorkSessionsToFinishTheTasksPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _01986_MinimumNumberOfWorkSessionsToFinishTheTasks.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
