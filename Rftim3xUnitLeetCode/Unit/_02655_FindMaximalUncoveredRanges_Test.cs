using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _02655_FindMaximalUncoveredRanges_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_02655_FindMaximalUncoveredRanges))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02655_FindMaximalUncoveredRanges))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02655_FindMaximalUncoveredRanges))![1]);

        public static TheoryData<List<string>, int> _02655_FindMaximalUncoveredRangesPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _02655_FindMaximalUncoveredRangesPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_02655_FindMaximalUncoveredRangesPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _02655_FindMaximalUncoveredRanges.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02655_FindMaximalUncoveredRangesPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _02655_FindMaximalUncoveredRanges.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
