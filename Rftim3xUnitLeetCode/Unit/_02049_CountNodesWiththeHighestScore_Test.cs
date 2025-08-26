using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _02049_CountNodesWiththeHighestScore_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_02049_CountNodesWiththeHighestScore))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02049_CountNodesWiththeHighestScore))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02049_CountNodesWiththeHighestScore))![1]);

        public static TheoryData<List<string>, int> _02049_CountNodesWiththeHighestScorePartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _02049_CountNodesWiththeHighestScorePartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_02049_CountNodesWiththeHighestScorePartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _02049_CountNodesWiththeHighestScore.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02049_CountNodesWiththeHighestScorePartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _02049_CountNodesWiththeHighestScore.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
