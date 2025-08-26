using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using Rftim3AdventOfCode.Refactor;

namespace Rftim3xUnitAdventOfCode.Unit
{
    public class _05_IfYouGiveASeedAFertilizer_Test
    {
        // Arrange
        private static readonly List<string> Input = RftAdventOfCodeStaticData.Input_Test(problemName: nameof(_05_IfYouGiveASeedAFertilizer))!;
        private static readonly long ExpectedPartOne = long.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_05_IfYouGiveASeedAFertilizer))![0]);
        private static readonly long ExpectedPartTwo = long.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_05_IfYouGiveASeedAFertilizer))![1]);

        public static TheoryData<List<string>, long> _05_IfYouGiveASeedAFertilizerPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, long> _05_IfYouGiveASeedAFertilizerPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_05_IfYouGiveASeedAFertilizerPartOne_Data))]
        public void PartOne(List<string> a0, long expected)
        {
            // Act
            long actual = _05_IfYouGiveASeedAFertilizer.PartOne_Test(a0);

            // Assert
            Assert.Equivalent(expected, actual, true);
        }

        [Theory]
        [MemberData(nameof(_05_IfYouGiveASeedAFertilizerPartTwo_Data))]
        public void PartTwo(List<string> a0, long expected)
        {
            // Act
            long actual = _05_IfYouGiveASeedAFertilizer.PartTwo_Test(a0);

            // Assert
            Assert.Equivalent(expected, actual, true);
        }
    }
}
