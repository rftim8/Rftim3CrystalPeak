using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _02432_TheEmployeeThatWorkedOnTheLongestTask_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_02432_TheEmployeeThatWorkedOnTheLongestTask))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02432_TheEmployeeThatWorkedOnTheLongestTask))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02432_TheEmployeeThatWorkedOnTheLongestTask))![1]);

        public static TheoryData<List<string>, int> _02432_TheEmployeeThatWorkedOnTheLongestTaskPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _02432_TheEmployeeThatWorkedOnTheLongestTaskPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_02432_TheEmployeeThatWorkedOnTheLongestTaskPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _02432_TheEmployeeThatWorkedOnTheLongestTask.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02432_TheEmployeeThatWorkedOnTheLongestTaskPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _02432_TheEmployeeThatWorkedOnTheLongestTask.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
