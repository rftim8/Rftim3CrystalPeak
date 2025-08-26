using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _01072_FlipColumnsForMaximumNumberOfEqualRows_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_01072_FlipColumnsForMaximumNumberOfEqualRows))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01072_FlipColumnsForMaximumNumberOfEqualRows))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01072_FlipColumnsForMaximumNumberOfEqualRows))![1]);

        public static TheoryData<List<string>, int> _01072_FlipColumnsForMaximumNumberOfEqualRowsPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _01072_FlipColumnsForMaximumNumberOfEqualRowsPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_01072_FlipColumnsForMaximumNumberOfEqualRowsPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _01072_FlipColumnsForMaximumNumberOfEqualRows.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01072_FlipColumnsForMaximumNumberOfEqualRowsPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _01072_FlipColumnsForMaximumNumberOfEqualRows.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
