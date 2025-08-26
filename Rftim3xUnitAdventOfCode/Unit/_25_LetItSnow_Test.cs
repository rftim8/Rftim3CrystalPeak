using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using Rftim3AdventOfCode.Refactor;

namespace Rftim3xUnitAdventOfCode.Unit
{
    public class _25_LetItSnow_Test
    {
        // Arrange
        private static readonly List<string> Input = RftAdventOfCodeStaticData.Input_Test(problemName: nameof(_25_LetItSnow))!;
        private static readonly int ExpectedPartOne = int.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_25_LetItSnow))![0]);

        public static TheoryData<List<string>, int> _25_LetItSnowPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        [Theory]
        [MemberData(nameof(_25_LetItSnowPartOne_Data))]
        public static void RftPartOne(List<string> input, int expected)
        {
            // Act
            int actual = _25_LetItSnow.PartOne_Test(input);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
