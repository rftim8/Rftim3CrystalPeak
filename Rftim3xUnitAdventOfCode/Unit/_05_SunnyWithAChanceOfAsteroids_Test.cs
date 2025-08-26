using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using Rftim3AdventOfCode.Refactor;

namespace Rftim3xUnitAdventOfCode.Unit
{
    public class _05_SunnyWithAChanceOfAsteroids_Test
    {
        // Arrange
        private static readonly List<string> Input = RftAdventOfCodeStaticData.Input_Test(problemName: nameof(_05_SunnyWithAChanceOfAsteroids))!;
        private static readonly int ExpectedPartOne = int.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_05_SunnyWithAChanceOfAsteroids))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_05_SunnyWithAChanceOfAsteroids))![1]);

        public static TheoryData<List<string>, int> _05_SunnyWithAChanceOfAsteroidsPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _05_SunnyWithAChanceOfAsteroidsPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_05_SunnyWithAChanceOfAsteroidsPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _05_SunnyWithAChanceOfAsteroids.PartOne_Test(a0, 1);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_05_SunnyWithAChanceOfAsteroidsPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _05_SunnyWithAChanceOfAsteroids.PartTwo_Test(a0, 5);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
