using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _02436_MinimumSplitIntoSubarraysWithGCDGreaterThanOne_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_02436_MinimumSplitIntoSubarraysWithGCDGreaterThanOne))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02436_MinimumSplitIntoSubarraysWithGCDGreaterThanOne))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02436_MinimumSplitIntoSubarraysWithGCDGreaterThanOne))![1]);

        public static TheoryData<List<string>, int> _02436_MinimumSplitIntoSubarraysWithGCDGreaterThanOnePartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _02436_MinimumSplitIntoSubarraysWithGCDGreaterThanOnePartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_02436_MinimumSplitIntoSubarraysWithGCDGreaterThanOnePartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _02436_MinimumSplitIntoSubarraysWithGCDGreaterThanOne.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02436_MinimumSplitIntoSubarraysWithGCDGreaterThanOnePartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _02436_MinimumSplitIntoSubarraysWithGCDGreaterThanOne.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
