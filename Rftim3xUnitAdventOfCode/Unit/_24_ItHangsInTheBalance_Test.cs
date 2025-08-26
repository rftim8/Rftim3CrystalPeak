using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using Rftim3AdventOfCode.Refactor;

namespace Rftim3xUnitAdventOfCode.Unit
{
    public class _24_ItHangsInTheBalance_Test
    {
        // Arrange
        private static readonly List<string> Input = RftAdventOfCodeStaticData.Input_Test(problemName: nameof(_24_ItHangsInTheBalance))!;
        private static readonly long ExpectedPartOne = long.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_24_ItHangsInTheBalance))![0]);
        private static readonly long ExpectedPartTwo = long.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_24_ItHangsInTheBalance))![1]);

        public static TheoryData<List<string>, long> _24_ItHangsInTheBalancePartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, long> _24_ItHangsInTheBalancePartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_24_ItHangsInTheBalancePartOne_Data))]
        public static void RftPartOne(List<string> input, long expected)
        {
            // Act
            long actual = _24_ItHangsInTheBalance.PartOne_Test(input);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_24_ItHangsInTheBalancePartTwo_Data))]
        public static void RftPartTwo(List<string> input, long expected)
        {
            // Act
            long actual = _24_ItHangsInTheBalance.PartTwo_Test(input);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
