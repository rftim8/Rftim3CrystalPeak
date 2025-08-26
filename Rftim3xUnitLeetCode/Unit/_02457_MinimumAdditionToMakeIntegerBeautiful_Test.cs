using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _02457_MinimumAdditionToMakeIntegerBeautiful_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_02457_MinimumAdditionToMakeIntegerBeautiful))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02457_MinimumAdditionToMakeIntegerBeautiful))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02457_MinimumAdditionToMakeIntegerBeautiful))![1]);

        public static TheoryData<List<string>, int> _02457_MinimumAdditionToMakeIntegerBeautifulPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _02457_MinimumAdditionToMakeIntegerBeautifulPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_02457_MinimumAdditionToMakeIntegerBeautifulPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _02457_MinimumAdditionToMakeIntegerBeautiful.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02457_MinimumAdditionToMakeIntegerBeautifulPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _02457_MinimumAdditionToMakeIntegerBeautiful.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
