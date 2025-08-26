using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _02428_MaximumSumOfAnHourglass_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_02428_MaximumSumOfAnHourglass))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02428_MaximumSumOfAnHourglass))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02428_MaximumSumOfAnHourglass))![1]);

        public static TheoryData<List<string>, int> _02428_MaximumSumOfAnHourglassPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _02428_MaximumSumOfAnHourglassPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_02428_MaximumSumOfAnHourglassPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _02428_MaximumSumOfAnHourglass.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02428_MaximumSumOfAnHourglassPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _02428_MaximumSumOfAnHourglass.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
