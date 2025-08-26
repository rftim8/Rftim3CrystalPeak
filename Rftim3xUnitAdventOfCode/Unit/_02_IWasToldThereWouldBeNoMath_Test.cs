using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using Rftim3AdventOfCode.Refactor;

namespace Rftim3xUnitAdventOfCode.Unit
{
    public class _02_IWasToldThereWouldBeNoMath_Test
    {
        // Arrange
        private static readonly List<string> Input = RftAdventOfCodeStaticData.Input_Test(problemName: nameof(_02_IWasToldThereWouldBeNoMath))!;
        private static readonly int ExpectedPartOne = int.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_02_IWasToldThereWouldBeNoMath))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_02_IWasToldThereWouldBeNoMath))![1]);

        public static TheoryData<List<string>, int> _02_IWasToldThereWouldBeNoMathPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _02_IWasToldThereWouldBeNoMathPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_02_IWasToldThereWouldBeNoMathPartOne_Data))]
        public static void RftPartOne(List<string> input, int expected)
        {
            // Act
            int actual = _02_IWasToldThereWouldBeNoMath.PartOne_Test(input);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02_IWasToldThereWouldBeNoMathPartTwo_Data))]
        public static void RftPartTwo(List<string> input, int expected)
        {
            // Act
            int actual = _02_IWasToldThereWouldBeNoMath.PartTwo_Test(input);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
