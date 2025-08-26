using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using Rftim3AdventOfCode.Refactor;

namespace Rftim3xUnitAdventOfCode.Unit
{
    public class _15_ScienceForHungryPeople_Test
    {
        // Arrange
        private static readonly List<string> Input = RftAdventOfCodeStaticData.Input_Test(problemName: nameof(_15_ScienceForHungryPeople))!;
        private static readonly int ExpectedPartOne = int.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_15_ScienceForHungryPeople))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_15_ScienceForHungryPeople))![1]);

        public static TheoryData<List<string>, int> _15_ScienceForHungryPeoplePartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _15_ScienceForHungryPeoplePartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_15_ScienceForHungryPeoplePartOne_Data))]
        public static void RftPartOne(List<string> file, int expected)
        {
            // Act
            int actual = _15_ScienceForHungryPeople.PartOne_Test(file);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_15_ScienceForHungryPeoplePartTwo_Data))]
        public static void RftPartTwo(List<string> file, int expected)
        {
            // Act
            int actual = _15_ScienceForHungryPeople.PartTwo_Test(file);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
