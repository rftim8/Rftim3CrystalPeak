using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using Rftim3AdventOfCode.Refactor;

namespace Rftim3xUnitAdventOfCode.Unit
{
    public class _25_SeaCucumber_Test
    {
        // Arrange
        private static readonly List<string> Input = RftAdventOfCodeStaticData.Input_Test(problemName: nameof(_25_SeaCucumber))!;
        private static readonly int ExpectedPartOne = int.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_25_SeaCucumber))![0]);

        public static TheoryData<List<string>, int> _25_SeaCucumberPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        [Theory(Skip = "Incomplete")]
        [MemberData(nameof(_25_SeaCucumberPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _25_SeaCucumber.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
