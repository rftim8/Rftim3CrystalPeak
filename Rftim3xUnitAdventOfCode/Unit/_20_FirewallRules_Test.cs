using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using Rftim3AdventOfCode.Refactor;

namespace Rftim3xUnitAdventOfCode.Unit
{
    public class _20_FirewallRules_Test
    {
        // Arrange
        private static readonly List<string> Input = RftAdventOfCodeStaticData.Input_Test(problemName: nameof(_20_FirewallRules))!;
        private static readonly int ExpectedPartOne = int.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_20_FirewallRules))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_20_FirewallRules))![1]);

        public static TheoryData<List<string>, long> _20_FirewallRulesPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, long> _20_FirewallRulesPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_20_FirewallRulesPartOne_Data))]
        public static void RftPartOne(List<string> input, long expected)
        {
            // Act
            long actual = _20_FirewallRules.PartOne_Test(input);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_20_FirewallRulesPartTwo_Data))]
        public static void RftPartTwo(List<string> input, long expected)
        {
            // Act
            long actual = _20_FirewallRules.PartTwo_Test(input);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
