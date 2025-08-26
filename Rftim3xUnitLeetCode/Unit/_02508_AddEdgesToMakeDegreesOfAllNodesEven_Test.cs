using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _02508_AddEdgesToMakeDegreesOfAllNodesEven_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_02508_AddEdgesToMakeDegreesOfAllNodesEven))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02508_AddEdgesToMakeDegreesOfAllNodesEven))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02508_AddEdgesToMakeDegreesOfAllNodesEven))![1]);

        public static TheoryData<List<string>, int> _02508_AddEdgesToMakeDegreesOfAllNodesEvenPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _02508_AddEdgesToMakeDegreesOfAllNodesEvenPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_02508_AddEdgesToMakeDegreesOfAllNodesEvenPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _02508_AddEdgesToMakeDegreesOfAllNodesEven.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02508_AddEdgesToMakeDegreesOfAllNodesEvenPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _02508_AddEdgesToMakeDegreesOfAllNodesEven.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
