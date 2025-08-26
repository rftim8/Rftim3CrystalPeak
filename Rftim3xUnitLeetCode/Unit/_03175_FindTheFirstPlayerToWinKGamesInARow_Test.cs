using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _03175_FindTheFirstPlayerToWinKGamesInARow_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_03175_FindTheFirstPlayerToWinKGamesInARow))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_03175_FindTheFirstPlayerToWinKGamesInARow))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_03175_FindTheFirstPlayerToWinKGamesInARow))![1]);

        public static TheoryData<List<string>, int> _03175_FindTheFirstPlayerToWinKGamesInARowPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _03175_FindTheFirstPlayerToWinKGamesInARowPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_03175_FindTheFirstPlayerToWinKGamesInARowPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _03175_FindTheFirstPlayerToWinKGamesInARow.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_03175_FindTheFirstPlayerToWinKGamesInARowPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _03175_FindTheFirstPlayerToWinKGamesInARow.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
