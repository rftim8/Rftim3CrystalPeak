using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _01900_TheEarliestAndLatestRoundsWherePlayers_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_01900_TheEarliestAndLatestRoundsWherePlayers))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01900_TheEarliestAndLatestRoundsWherePlayers))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01900_TheEarliestAndLatestRoundsWherePlayers))![1]);

        public static TheoryData<List<string>, int> _01900_TheEarliestAndLatestRoundsWherePlayersPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _01900_TheEarliestAndLatestRoundsWherePlayersPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_01900_TheEarliestAndLatestRoundsWherePlayersPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _01900_TheEarliestAndLatestRoundsWherePlayers.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01900_TheEarliestAndLatestRoundsWherePlayersPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _01900_TheEarliestAndLatestRoundsWherePlayers.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
