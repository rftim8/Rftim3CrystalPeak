using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _02339_AllTheMatchesOfTheLeague_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_02339_AllTheMatchesOfTheLeague))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02339_AllTheMatchesOfTheLeague))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02339_AllTheMatchesOfTheLeague))![1]);

        public static TheoryData<List<string>, int> _02339_AllTheMatchesOfTheLeaguePartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _02339_AllTheMatchesOfTheLeaguePartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_02339_AllTheMatchesOfTheLeaguePartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _02339_AllTheMatchesOfTheLeague.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02339_AllTheMatchesOfTheLeaguePartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _02339_AllTheMatchesOfTheLeague.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
