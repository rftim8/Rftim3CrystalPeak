using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using Rftim3AdventOfCode;

namespace Rftim3xUnitAdventOfCode.Unit
{
    public class _24_NeverTellMeTheOdds_Test
    {
        private static readonly List<string> Input = RftAdventOfCodeStaticData.Input_Test(problemName: nameof(_24_NeverTellMeTheOdds))!;
        private static readonly int ExpectedPartOne = int.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_24_NeverTellMeTheOdds))![0]);
        private static readonly long ExpectedPartTwo = long.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_24_NeverTellMeTheOdds))![1]);

        public static TheoryData<List<string>, int> Assert1_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, long> Assert2_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(Assert1_Data))]
        public void Actual1(List<string> input, int expected)
        {
            // Act
            int actual = _24_NeverTellMeTheOdds.PartOne_Test(input);

            // Assert
            Assert.Equivalent(expected, actual, true);
        }

        [Theory]
        [MemberData(nameof(Assert2_Data))]
        public void Actual2(List<string> input, long expected)
        {
            // Act
            long actual = _24_NeverTellMeTheOdds.PartTwo_Test(input);

            // Assert
            Assert.Equivalent(expected, actual, true);
        }
    }
}
