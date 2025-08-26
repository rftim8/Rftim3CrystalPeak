using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _01956_MinimumTimeForKVirusVariantsToSpread_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_01956_MinimumTimeForKVirusVariantsToSpread))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01956_MinimumTimeForKVirusVariantsToSpread))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01956_MinimumTimeForKVirusVariantsToSpread))![1]);

        public static TheoryData<List<string>, int> _01956_MinimumTimeForKVirusVariantsToSpreadPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _01956_MinimumTimeForKVirusVariantsToSpreadPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_01956_MinimumTimeForKVirusVariantsToSpreadPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _01956_MinimumTimeForKVirusVariantsToSpread.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01956_MinimumTimeForKVirusVariantsToSpreadPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _01956_MinimumTimeForKVirusVariantsToSpread.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
