using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using Rftim3AdventOfCode.Refactor;

namespace Rftim3xUnitAdventOfCode.Unit
{
    public class _10_TheStarsAlign_Test
    {
        // Arrange
        private static readonly List<string> Input = RftAdventOfCodeStaticData.Input_Test(problemName: nameof(_10_TheStarsAlign))!;
        private static readonly string ExpectedPartOne = RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_10_TheStarsAlign))![0];
        private static readonly int ExpectedPartTwo = int.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_10_TheStarsAlign))![1]);

        public static TheoryData<List<string>, string> _10_TheStarsAlignPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _10_TheStarsAlignPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_10_TheStarsAlignPartOne_Data))]
        public void RftPartOne(List<string> a0, string expected)
        {
            // Act
            string actual = _10_TheStarsAlign.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_10_TheStarsAlignPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _10_TheStarsAlign.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
