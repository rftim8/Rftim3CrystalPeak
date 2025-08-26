using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _02604_MinimumTimeToEatAllGrains_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_02604_MinimumTimeToEatAllGrains))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02604_MinimumTimeToEatAllGrains))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02604_MinimumTimeToEatAllGrains))![1]);

        public static TheoryData<List<string>, int> _02604_MinimumTimeToEatAllGrainsPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _02604_MinimumTimeToEatAllGrainsPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_02604_MinimumTimeToEatAllGrainsPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _02604_MinimumTimeToEatAllGrains.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02604_MinimumTimeToEatAllGrainsPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _02604_MinimumTimeToEatAllGrains.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
