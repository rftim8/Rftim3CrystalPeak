using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using Rftim3AdventOfCode.Refactor;

namespace Rftim3xUnitAdventOfCode.Unit
{
    public class _20_JurassicJigsaw_Test
    {
        // Arrange
        private static readonly List<string> Input = RftAdventOfCodeStaticData.Input_Test(problemName: nameof(_20_JurassicJigsaw))!;
        private static readonly long ExpectedPartOne = long.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_20_JurassicJigsaw))![0]);
        private static readonly long ExpectedPartTwo = long.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_20_JurassicJigsaw))![1]);

        public static TheoryData<List<string>, long> _20_JurassicJigsawPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, long> _20_JurassicJigsawPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory(Skip = "Incomplete")]
        [MemberData(nameof(_20_JurassicJigsawPartOne_Data))]
        public void RftPartOne(List<string> a0, long expected)
        {
            // Act
            long actual = _20_JurassicJigsaw.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory(Skip = "Incomplete")]
        [MemberData(nameof(_20_JurassicJigsawPartTwo_Data))]
        public void RftPartTwo(List<string> a0, long expected)
        {
            // Act
            long actual = _20_JurassicJigsaw.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
