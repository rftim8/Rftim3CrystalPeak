using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using System.Numerics;
using Rftim3AdventOfCode.Refactor;

namespace Rftim3xUnitAdventOfCode.Unit
{
    public class _09_SensorBoost_Test
    {
        // Arrange
        private static readonly List<string> Input = RftAdventOfCodeStaticData.Input_Test(problemName: nameof(_09_SensorBoost))!;
        private static readonly BigInteger ExpectedPartOne = BigInteger.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_09_SensorBoost))![0]);
        private static readonly BigInteger ExpectedPartTwo = BigInteger.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_09_SensorBoost))![1]);

        public static TheoryData<List<string>, BigInteger> _09_SensorBoostPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, BigInteger> _09_SensorBoostPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_09_SensorBoostPartOne_Data))]
        public void RftPartOne(List<string> a0, BigInteger expected)
        {
            // Act
            BigInteger actual = _09_SensorBoost.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_09_SensorBoostPartTwo_Data))]
        public void RftPartTwo(List<string> a0, BigInteger expected)
        {
            // Act
            BigInteger actual = _09_SensorBoost.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
