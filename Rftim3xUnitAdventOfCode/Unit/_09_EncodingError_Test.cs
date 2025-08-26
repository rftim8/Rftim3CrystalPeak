using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using Rftim3AdventOfCode.Refactor;

namespace Rftim3xUnitAdventOfCode.Unit
{
    public class _09_EncodingError_Test
    {
        // Arrange
        private static readonly List<string> Input = RftAdventOfCodeStaticData.Input_Test(problemName: nameof(_09_EncodingError))!;
        private static readonly long ExpectedPartOne = long.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_09_EncodingError))![0]);
        private static readonly long ExpectedPartTwo = long.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_09_EncodingError))![1]);

        public static TheoryData<List<string>, long> _09_EncodingErrorPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, long> _09_EncodingErrorPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_09_EncodingErrorPartOne_Data))]
        public void RftPartOne(List<string> a0, long expected)
        {
            // Act
            long actual = _09_EncodingError.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_09_EncodingErrorPartTwo_Data))]
        public void RftPartTwo(List<string> a0, long expected)
        {
            // Act
            long actual = _09_EncodingError.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
