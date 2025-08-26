using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using Rftim3AdventOfCode;

namespace Rftim3xUnitAdventOfCode.Unit
{
    public class _21_MonkeyMath_Test
    {
        // Arrange
        private static readonly List<string> Input = RftAdventOfCodeStaticData.Input_Test(problemName: nameof(_21_MonkeyMath))!;
        private static readonly long ExpectedPartOne = long.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_21_MonkeyMath))![0]);
        private static readonly long ExpectedPartTwo = long.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_21_MonkeyMath))![1]);

        public static TheoryData<List<string>, long> _21_MonkeyMathPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, long> _21_MonkeyMathPartTwo_Data =>
           new()
           {
               { Input, ExpectedPartTwo }
           };

        [Theory]
        [MemberData(nameof(_21_MonkeyMathPartOne_Data))]
        public void RftPartOne(List<string> a0, long expected)
        {
            // Act
            long actual = _21_MonkeyMath.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_21_MonkeyMathPartTwo_Data))]
        public void RftPartTwo(List<string> a0, long expected)
        {
            // Act
            long actual = _21_MonkeyMath.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
