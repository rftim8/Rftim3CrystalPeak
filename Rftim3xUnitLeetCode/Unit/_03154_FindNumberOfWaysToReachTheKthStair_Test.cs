using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _03154_FindNumberOfWaysToReachTheKthStair_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_03154_FindNumberOfWaysToReachTheKthStair))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_03154_FindNumberOfWaysToReachTheKthStair))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_03154_FindNumberOfWaysToReachTheKthStair))![1]);

        public static TheoryData<List<string>, int> _03154_FindNumberOfWaysToReachTheKthStairPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _03154_FindNumberOfWaysToReachTheKthStairPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_03154_FindNumberOfWaysToReachTheKthStairPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _03154_FindNumberOfWaysToReachTheKthStair.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_03154_FindNumberOfWaysToReachTheKthStairPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _03154_FindNumberOfWaysToReachTheKthStair.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
