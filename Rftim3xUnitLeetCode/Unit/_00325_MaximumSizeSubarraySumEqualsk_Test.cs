using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _00325_MaximumSizeSubarraySumEqualsk_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_00325_MaximumSizeSubarraySumEqualsk))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_00325_MaximumSizeSubarraySumEqualsk))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_00325_MaximumSizeSubarraySumEqualsk))![1]);

        public static TheoryData<List<string>, int> _00325_MaximumSizeSubarraySumEqualskPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _00325_MaximumSizeSubarraySumEqualskPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_00325_MaximumSizeSubarraySumEqualskPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _00325_MaximumSizeSubarraySumEqualsk.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00325_MaximumSizeSubarraySumEqualskPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _00325_MaximumSizeSubarraySumEqualsk.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
