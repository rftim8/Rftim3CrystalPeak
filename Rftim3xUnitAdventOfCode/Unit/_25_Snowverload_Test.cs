using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using Rftim3AdventOfCode.Refactor;

namespace Rftim3xUnitAdventOfCode.Unit
{
    public class _25_Snowverload_Test
    {
        public static List<string> Input => RftAdventOfCodeStaticData.Input_Test(problemName: nameof(_25_Snowverload))!;
        private static readonly int ExpectedPartOne = int.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_25_Snowverload))![0]);

        public static TheoryData<List<string>, int> Assert1_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        [Theory]
        [MemberData(nameof(Assert1_Data))]
        public void Actual1(List<string> input, int expected)
        {
            // Act
            int actual = _25_Snowverload.PartOne_Test(input);

            // Assert
            Assert.Equivalent(expected, actual, true);
        }
    }
}
