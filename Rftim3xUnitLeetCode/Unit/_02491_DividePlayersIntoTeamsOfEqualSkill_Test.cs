using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _02491_DividePlayersIntoTeamsOfEqualSkill_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_02491_DividePlayersIntoTeamsOfEqualSkill))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02491_DividePlayersIntoTeamsOfEqualSkill))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02491_DividePlayersIntoTeamsOfEqualSkill))![1]);

        public static TheoryData<List<string>, int> _02491_DividePlayersIntoTeamsOfEqualSkillPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _02491_DividePlayersIntoTeamsOfEqualSkillPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_02491_DividePlayersIntoTeamsOfEqualSkillPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _02491_DividePlayersIntoTeamsOfEqualSkill.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02491_DividePlayersIntoTeamsOfEqualSkillPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _02491_DividePlayersIntoTeamsOfEqualSkill.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
