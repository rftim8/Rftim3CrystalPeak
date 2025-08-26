using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using Rftim3AdventOfCode.Refactor;

namespace Rftim3xUnitAdventOfCode.Unit
{
    public class _14_ExtendedPolymerization_Test
    {
        // Arrange
        private static readonly List<string> Input = [.. string.Join("\r\n", RftAdventOfCodeStaticData.Input_Test(problemName: nameof(_14_ExtendedPolymerization))!).Split("\r\n\r\n")];
        private static readonly long ExpectedPartOne = long.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_14_ExtendedPolymerization))![0]);
        private static readonly long ExpectedPartTwo = long.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_14_ExtendedPolymerization))![1]);

        public static TheoryData<List<string>, long> _14_ExtendedPolymerizationPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, long> _14_ExtendedPolymerizationPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_14_ExtendedPolymerizationPartOne_Data))]
        public void RftPartOne(List<string> a0, long expected)
        {
            // Act
            long actual = _14_ExtendedPolymerization.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_14_ExtendedPolymerizationPartTwo_Data))]
        public void RftPartTwo(List<string> a0, long expected)
        {
            // Act
            long actual = _14_ExtendedPolymerization.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
