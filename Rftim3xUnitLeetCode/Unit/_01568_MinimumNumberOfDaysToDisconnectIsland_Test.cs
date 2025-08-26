using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _01568_MinimumNumberOfDaysToDisconnectIsland_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_01568_MinimumNumberOfDaysToDisconnectIsland))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01568_MinimumNumberOfDaysToDisconnectIsland))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01568_MinimumNumberOfDaysToDisconnectIsland))![1]);

        public static TheoryData<List<string>, int> _01568_MinimumNumberOfDaysToDisconnectIslandPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _01568_MinimumNumberOfDaysToDisconnectIslandPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_01568_MinimumNumberOfDaysToDisconnectIslandPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _01568_MinimumNumberOfDaysToDisconnectIsland.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01568_MinimumNumberOfDaysToDisconnectIslandPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _01568_MinimumNumberOfDaysToDisconnectIsland.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
