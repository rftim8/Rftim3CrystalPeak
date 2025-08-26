using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using Rftim3AdventOfCode.Refactor;

namespace Rftim3xUnitAdventOfCode.Unit
{
    public class _25_ComboBreaker_Test
    {
        // Arrange
        private static readonly List<string> Input = RftAdventOfCodeStaticData.Input_Test(problemName: nameof(_25_ComboBreaker))!;
        private static readonly long ExpectedPartOne = long.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_25_ComboBreaker))![0]);

        public static TheoryData<List<string>, long> _25_ComboBreakerPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        [Theory]
        [MemberData(nameof(_25_ComboBreakerPartOne_Data))]
        public void RftPartOne(List<string> a0, long expected)
        {
            // Act
            long actual = _25_ComboBreaker.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
