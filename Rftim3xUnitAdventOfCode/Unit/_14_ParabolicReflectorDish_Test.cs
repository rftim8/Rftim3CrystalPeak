using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using Rftim3AdventOfCode.Refactor;

namespace Rftim3xUnitAdventOfCode.Unit
{
    public class _14_ParabolicReflectorDish_Test
    {
        // Arrange
        private static readonly List<string> Input = RftAdventOfCodeStaticData.Input_Test(problemName: nameof(_14_ParabolicReflectorDish))!;
        private static readonly int ExpectedPartOne = int.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_14_ParabolicReflectorDish))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_14_ParabolicReflectorDish))![1]);

        public static TheoryData<List<string>, int> _14_ParabolicReflectorDishPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _14_ParabolicReflectorDishPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_14_ParabolicReflectorDishPartOne_Data))]
        public void PartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _14_ParabolicReflectorDish.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_14_ParabolicReflectorDishPartTwo_Data))]
        public void PartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _14_ParabolicReflectorDish.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
