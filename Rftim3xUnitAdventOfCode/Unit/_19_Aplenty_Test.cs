using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using Rftim3AdventOfCode;
using System.Numerics;

namespace Rftim3xUnitAdventOfCode.Unit
{
    public class _19_Aplenty_Test
    {
        // Arrange
        private static List<string> Input => RftAdventOfCodeStaticData.Input_Test(problemName: nameof(_19_Aplenty))!;
        private static readonly long ExpectedPartOne = long.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_19_Aplenty))![0]);
        private static readonly BigInteger ExpectedPartTwo = BigInteger.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_19_Aplenty))![1]);

        public static TheoryData<List<string>, long> Assert1_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, BigInteger> Assert2_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(Assert1_Data))]
        public void Actual1(List<string> input, long expected)
        {
            // Act
            long actual = _19_Aplenty.PartOne_Test(input);

            // Assert
            Assert.Equivalent(expected, actual, true);
        }

        [Theory]
        [MemberData(nameof(Assert2_Data))]
        public void Actual2(List<string> input, BigInteger expected)
        {
            // Act
            BigInteger actual = _19_Aplenty.PartTwo_Test(input);

            // Assert
            Assert.Equivalent(expected, actual, true);
        }
    }
}
