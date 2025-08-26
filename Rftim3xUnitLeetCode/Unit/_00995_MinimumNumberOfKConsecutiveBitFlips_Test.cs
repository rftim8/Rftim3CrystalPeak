using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _00995_MinimumNumberOfKConsecutiveBitFlips_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_00995_MinimumNumberOfKConsecutiveBitFlips))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_00995_MinimumNumberOfKConsecutiveBitFlips))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_00995_MinimumNumberOfKConsecutiveBitFlips))![1]);

        public static TheoryData<List<string>, int> _00995_MinimumNumberOfKConsecutiveBitFlipsPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _00995_MinimumNumberOfKConsecutiveBitFlipsPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_00995_MinimumNumberOfKConsecutiveBitFlipsPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _00995_MinimumNumberOfKConsecutiveBitFlips.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00995_MinimumNumberOfKConsecutiveBitFlipsPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _00995_MinimumNumberOfKConsecutiveBitFlips.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
