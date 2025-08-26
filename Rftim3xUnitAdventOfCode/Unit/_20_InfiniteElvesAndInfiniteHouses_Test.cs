using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using Rftim3AdventOfCode.Refactor;

namespace Rftim3xUnitAdventOfCode.Unit
{
    public class _20_InfiniteElvesAndInfiniteHouses_Test
    {
        // Arrange
        private static readonly List<string> Input = RftAdventOfCodeStaticData.Input_Test(problemName: nameof(_20_InfiniteElvesAndInfiniteHouses))!;
        private static readonly int ExpectedPartOne = int.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_20_InfiniteElvesAndInfiniteHouses))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_20_InfiniteElvesAndInfiniteHouses))![1]);

        public static TheoryData<List<string>, long> _20_InfiniteElvesAndInfiniteHousesPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, long> _20_InfiniteElvesAndInfiniteHousesPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_20_InfiniteElvesAndInfiniteHousesPartOne_Data))]
        public static void RftPartOne(List<string> file, long expected)
        {
            // Act
            long actual = _20_InfiniteElvesAndInfiniteHouses.PartOne_Test(file);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_20_InfiniteElvesAndInfiniteHousesPartTwo_Data))]
        public static void RftPartTwo(List<string> file, long expected)
        {
            // Act
            long actual = _20_InfiniteElvesAndInfiniteHouses.PartTwo_Test(file);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
