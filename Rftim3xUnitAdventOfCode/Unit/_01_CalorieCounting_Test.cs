using Rftim3AdventOfCode.Refactor;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;

namespace Rftim3xUnitAdventOfCode.Unit
{
    public class _01_CalorieCounting_Test
    {
        // Arrange
        private static readonly List<string> Input = RftAdventOfCodeStaticData.Input_Test(problemName: nameof(_01_CalorieCounting))!;
        private static readonly int ExpectedPartOne = int.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_01_CalorieCounting))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_01_CalorieCounting))![1]);

        public static TheoryData<string[], int> _01_CalorieCountingPartOne_Data =>
            new()
            {
                    { Input.ToArray(), ExpectedPartOne }
            };

        public static TheoryData<string[], int> _01_CalorieCountingPartTwo_Data =>
            new()
            {
                    { Input.ToArray(), ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_01_CalorieCountingPartOne_Data))]
        public void RftPartOne(string[] a0, int expected)
        {
            // Act
            int actual = _01_CalorieCounting.PartOne_Test([.. a0]);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01_CalorieCountingPartTwo_Data))]
        public void RftPartTwo(string[] a0, int expected)
        {
            // Act
            int actual = _01_CalorieCounting.PartTwo_Test([.. a0]);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
