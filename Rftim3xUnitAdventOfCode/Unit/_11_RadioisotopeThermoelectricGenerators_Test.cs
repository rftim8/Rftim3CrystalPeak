using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using Rftim3AdventOfCode.Refactor;

namespace Rftim3xUnitAdventOfCode.Unit
{
    public class _11_RadioisotopeThermoelectricGenerators_Test
    {
        // Arrange
        private static readonly List<string> Input = RftAdventOfCodeStaticData.Input_Test(problemName: nameof(_11_RadioisotopeThermoelectricGenerators))!;
        private static readonly int ExpectedPartOne = int.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_11_RadioisotopeThermoelectricGenerators))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_11_RadioisotopeThermoelectricGenerators))![1]);

        public static TheoryData<List<string>, int> _11_RadioisotopeThermoelectricGeneratorsPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _11_RadioisotopeThermoelectricGeneratorsPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_11_RadioisotopeThermoelectricGeneratorsPartOne_Data))]
        public static void RftPartOne(List<string> input, int expected)
        {
            // Act
            int actual = _11_RadioisotopeThermoelectricGenerators.PartOne_Test(input);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_11_RadioisotopeThermoelectricGeneratorsPartTwo_Data))]
        public static void RftPartTwo(List<string> input, int expected)
        {
            // Act
            int actual = _11_RadioisotopeThermoelectricGenerators.PartTwo_Test(input);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
