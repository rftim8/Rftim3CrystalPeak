using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using Rftim3AdventOfCode;

namespace Rftim3xUnitAdventOfCode.Unit
{
    public class _16_TicketTranslation_Test
    {
        // Arrange
        private static readonly List<string> Input = [.. string.Join("\r\n", RftAdventOfCodeStaticData.Input_Test(problemName: nameof(_16_TicketTranslation))!).Split("\r\n\r\n")];
        private static readonly int ExpectedPartOne = int.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_16_TicketTranslation))![0]);
        private static readonly ulong ExpectedPartTwo = ulong.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_16_TicketTranslation))![1]);

        public static TheoryData<List<string>, int> _16_TicketTranslationPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, ulong> _16_TicketTranslationPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_16_TicketTranslationPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _16_TicketTranslation.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_16_TicketTranslationPartTwo_Data))]
        public void RftPartTwo(List<string> a0, ulong expected)
        {
            // Act
            ulong actual = _16_TicketTranslation.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
