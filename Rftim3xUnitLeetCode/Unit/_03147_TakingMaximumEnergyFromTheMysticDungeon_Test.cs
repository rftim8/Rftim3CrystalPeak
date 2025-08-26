using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _03147_TakingMaximumEnergyFromTheMysticDungeon_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_03147_TakingMaximumEnergyFromTheMysticDungeon))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_03147_TakingMaximumEnergyFromTheMysticDungeon))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_03147_TakingMaximumEnergyFromTheMysticDungeon))![1]);

        public static TheoryData<List<string>, int> _03147_TakingMaximumEnergyFromTheMysticDungeonPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _03147_TakingMaximumEnergyFromTheMysticDungeonPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_03147_TakingMaximumEnergyFromTheMysticDungeonPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _03147_TakingMaximumEnergyFromTheMysticDungeon.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_03147_TakingMaximumEnergyFromTheMysticDungeonPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _03147_TakingMaximumEnergyFromTheMysticDungeon.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
