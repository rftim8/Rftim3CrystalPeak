using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using Rftim3AdventOfCode.Refactor;

namespace Rftim3xUnitAdventOfCode.Unit
{
    public class _07_InternetProtocolVersion7_Test
    {
        // Arrange
        private static readonly List<string> Input = RftAdventOfCodeStaticData.Input_Test(problemName: nameof(_07_InternetProtocolVersion7))!;
        private static readonly int ExpectedPartOne = int.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_07_InternetProtocolVersion7))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_07_InternetProtocolVersion7))![1]);

        public static TheoryData<List<string>, int> _07_InternetProtocolVersion7PartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _07_InternetProtocolVersion7PartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_07_InternetProtocolVersion7PartOne_Data))]
        public static void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _07_InternetProtocolVersion7.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_07_InternetProtocolVersion7PartTwo_Data))]
        public static void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _07_InternetProtocolVersion7.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
