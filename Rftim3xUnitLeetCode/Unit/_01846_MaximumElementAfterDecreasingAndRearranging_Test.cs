using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _01846_MaximumElementAfterDecreasingAndRearranging_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_01846_MaximumElementAfterDecreasingAndRearranging))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01846_MaximumElementAfterDecreasingAndRearranging))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01846_MaximumElementAfterDecreasingAndRearranging))![1]);

        public static TheoryData<List<string>, int> _01846_MaximumElementAfterDecreasingAndRearrangingPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _01846_MaximumElementAfterDecreasingAndRearrangingPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_01846_MaximumElementAfterDecreasingAndRearrangingPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _01846_MaximumElementAfterDecreasingAndRearranging.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01846_MaximumElementAfterDecreasingAndRearrangingPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _01846_MaximumElementAfterDecreasingAndRearranging.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
