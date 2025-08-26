using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using Rftim3AdventOfCode.Refactor;

namespace Rftim3xUnitAdventOfCode.Unit
{
    public class _11_MonkeyInTheMiddle_Test
    {
        // Arrange
        private static readonly List<string> Input = RftAdventOfCodeStaticData.Input_Test(problemName: nameof(_11_MonkeyInTheMiddle))!;
        private static readonly long ExpectedPartOne = long.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_11_MonkeyInTheMiddle))![0]);
        private static readonly long ExpectedPartTwo = long.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_11_MonkeyInTheMiddle))![1]);

        public static TheoryData<List<string>, long> _11_MonkeyInTheMiddlePartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, long> _11_MonkeyInTheMiddlePartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_11_MonkeyInTheMiddlePartOne_Data))]
        public void RftPartOne(List<string> a0, long expected)
        {
            // Act
            long actual = _11_MonkeyInTheMiddle.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_11_MonkeyInTheMiddlePartTwo_Data))]
        public void RftPartTwo(List<string> a0, long expected)
        {
            // Act
            long actual = _11_MonkeyInTheMiddle.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
