using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _02914_MinimumNumberOfChangesToMakeBinaryStringBeautiful_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_02914_MinimumNumberOfChangesToMakeBinaryStringBeautiful))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02914_MinimumNumberOfChangesToMakeBinaryStringBeautiful))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02914_MinimumNumberOfChangesToMakeBinaryStringBeautiful))![1]);

        public static TheoryData<List<string>, int> _02914_MinimumNumberOfChangesToMakeBinaryStringBeautifulPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _02914_MinimumNumberOfChangesToMakeBinaryStringBeautifulPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_02914_MinimumNumberOfChangesToMakeBinaryStringBeautifulPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _02914_MinimumNumberOfChangesToMakeBinaryStringBeautiful.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02914_MinimumNumberOfChangesToMakeBinaryStringBeautifulPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _02914_MinimumNumberOfChangesToMakeBinaryStringBeautiful.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
