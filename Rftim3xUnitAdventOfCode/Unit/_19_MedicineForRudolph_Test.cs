using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using Rftim3AdventOfCode.Refactor;

namespace Rftim3xUnitAdventOfCode.Unit
{
    public class _19_MedicineForRudolph_Test
    {
        // Arrange
        private static readonly List<string> Input = RftAdventOfCodeStaticData.Input_Test(problemName: nameof(_19_MedicineForRudolph))!;
        private static readonly int ExpectedPartOne = int.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_19_MedicineForRudolph))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_19_MedicineForRudolph))![1]);

        public static TheoryData<List<string>, int> _19_MedicineForRudolphPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _19_MedicineForRudolphPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_19_MedicineForRudolphPartOne_Data))]
        public static void RftPartOne(List<string> file, int expected)
        {
            // Act
            int actual = _19_MedicineForRudolph.PartOne_Test(file);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_19_MedicineForRudolphPartTwo_Data))]
        public static void RftPartTwo(List<string> file, int expected)
        {
            // Act
            int actual = _19_MedicineForRudolph.PartTwo_Test(file);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
