using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _02071_MaximumNumberOfTasksYouCanAssign_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_02071_MaximumNumberOfTasksYouCanAssign))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02071_MaximumNumberOfTasksYouCanAssign))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02071_MaximumNumberOfTasksYouCanAssign))![1]);

        public static TheoryData<List<string>, int> _02071_MaximumNumberOfTasksYouCanAssignPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _02071_MaximumNumberOfTasksYouCanAssignPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_02071_MaximumNumberOfTasksYouCanAssignPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _02071_MaximumNumberOfTasksYouCanAssign.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02071_MaximumNumberOfTasksYouCanAssignPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _02071_MaximumNumberOfTasksYouCanAssign.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
