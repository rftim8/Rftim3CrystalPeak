using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using Rftim3AdventOfCode.Refactor;

namespace Rftim3xUnitAdventOfCode.Unit
{
    public class _19_TractorBeam_Test
    {
        // Arrange
        private static readonly List<string> Input = RftAdventOfCodeStaticData.Input_Test(problemName: nameof(_19_TractorBeam))!;
        private static readonly int ExpectedPartOne = int.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_19_TractorBeam))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_19_TractorBeam))![1]);

        public static TheoryData<List<string>, int> _19_TractorBeamPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _19_TractorBeamPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_19_TractorBeamPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _19_TractorBeam.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_19_TractorBeamPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _19_TractorBeam.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
