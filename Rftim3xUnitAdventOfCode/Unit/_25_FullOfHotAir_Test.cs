using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using Rftim3AdventOfCode.Refactor;

namespace Rftim3xUnitAdventOfCode.Unit
{
    public class _25_FullOfHotAir_Test
    {
        // Arrange
        private static readonly List<string> Input = RftAdventOfCodeStaticData.Input_Test(problemName: nameof(_25_FullOfHotAir))!;
        private static readonly string ExpectedPartOne = RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_25_FullOfHotAir))![0];

        public static TheoryData<List<string>, string> _25_FullOfHotAirPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        [Theory]
        [MemberData(nameof(_25_FullOfHotAirPartOne_Data))]
        public void RftPartOne(List<string> a0, string expected)
        {
            // Act
            string actual = _25_FullOfHotAir.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
