using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using Rftim3AdventOfCode.Refactor;

namespace Rftim3xUnitAdventOfCode.Unit
{
    public class _06_SignalsAndNoise_Test
    {
        // Arrange
        private static readonly List<string> Input = RftAdventOfCodeStaticData.Input_Test(problemName: nameof(_06_SignalsAndNoise))!;
        private static readonly string ExpectedPartOne = RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_06_SignalsAndNoise))![0];
        private static readonly string ExpectedPartTwo = RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_06_SignalsAndNoise))![1];

        public static TheoryData<List<string>, string> _06_SignalsAndNoisePartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, string> _06_SignalsAndNoisePartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_06_SignalsAndNoisePartOne_Data))]
        public static void RftPartOne(List<string> a0, string expected)
        {
            // Act
            string actual = _06_SignalsAndNoise.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_06_SignalsAndNoisePartTwo_Data))]
        public static void RftPartTwo(List<string> a0, string expected)
        {
            // Act
            string actual = _06_SignalsAndNoise.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
