using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using Rftim3AdventOfCode.Refactor;

namespace Rftim3xUnitAdventOfCode.Unit
{
    public class _17_NoSuchThingAsTooMuch_Test
    {
        // Arrange
        private static readonly List<string> Input = RftAdventOfCodeStaticData.Input_Test(problemName: nameof(_17_NoSuchThingAsTooMuch))!;
        private static readonly int ExpectedPartOne = int.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_17_NoSuchThingAsTooMuch))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_17_NoSuchThingAsTooMuch))![1]);

        public static TheoryData<List<string>, int> _17_NoSuchThingAsTooMuchPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _17_NoSuchThingAsTooMuchPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_17_NoSuchThingAsTooMuchPartOne_Data))]
        public static void RftPartOne(List<string> file, int expected)
        {
            // Act
            int actual = _17_NoSuchThingAsTooMuch.PartOne_Test(file);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_17_NoSuchThingAsTooMuchPartTwo_Data))]
        public static void RftPartTwo(List<string> file, int expected)
        {
            // Act
            int actual = _17_NoSuchThingAsTooMuch.PartTwo_Test(file);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
