using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using Rftim3AdventOfCode.Refactor;

namespace Rftim3xUnitAdventOfCode.Unit
{
    public class _08_IHeardYouLikeRegisters_Test
    {
        // Arrange
        private static readonly List<string> Input = RftAdventOfCodeStaticData.Input_Test(problemName: nameof(_08_IHeardYouLikeRegisters))!;
        private static readonly int ExpectedPartOne = int.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_08_IHeardYouLikeRegisters))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_08_IHeardYouLikeRegisters))![1]);

        public static TheoryData<List<string>, int> _08_IHeardYouLikeRegistersPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _08_IHeardYouLikeRegistersPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_08_IHeardYouLikeRegistersPartOne_Data))]
        public void RftPartOne(List<string> input, int expected)
        {
            // Act
            int actual = _08_IHeardYouLikeRegisters.PartOne_Test(input);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_08_IHeardYouLikeRegistersPartTwo_Data))]
        public void RftPartTwo(List<string> input, int expected)
        {
            // Act
            int actual = _08_IHeardYouLikeRegisters.PartTwo_Test(input);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
