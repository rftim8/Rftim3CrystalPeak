using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _02446_DetermineIfTwoEventsHaveConflict_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_02446_DetermineIfTwoEventsHaveConflict))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02446_DetermineIfTwoEventsHaveConflict))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02446_DetermineIfTwoEventsHaveConflict))![1]);

        public static TheoryData<List<string>, int> _02446_DetermineIfTwoEventsHaveConflictPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _02446_DetermineIfTwoEventsHaveConflictPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_02446_DetermineIfTwoEventsHaveConflictPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _02446_DetermineIfTwoEventsHaveConflict.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02446_DetermineIfTwoEventsHaveConflictPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _02446_DetermineIfTwoEventsHaveConflict.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
