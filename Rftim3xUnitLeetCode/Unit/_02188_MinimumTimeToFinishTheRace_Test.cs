using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _02188_MinimumTimeToFinishTheRace_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_02188_MinimumTimeToFinishTheRace))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02188_MinimumTimeToFinishTheRace))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02188_MinimumTimeToFinishTheRace))![1]);

        public static TheoryData<List<string>, int> _02188_MinimumTimeToFinishTheRacePartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _02188_MinimumTimeToFinishTheRacePartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_02188_MinimumTimeToFinishTheRacePartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _02188_MinimumTimeToFinishTheRace.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02188_MinimumTimeToFinishTheRacePartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _02188_MinimumTimeToFinishTheRace.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
