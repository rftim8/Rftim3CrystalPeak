using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _01235_MaximumProfitInJobScheduling_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_01235_MaximumProfitInJobScheduling))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01235_MaximumProfitInJobScheduling))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01235_MaximumProfitInJobScheduling))![1]);

        public static TheoryData<List<string>, int> _01235_MaximumProfitInJobSchedulingPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _01235_MaximumProfitInJobSchedulingPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_01235_MaximumProfitInJobSchedulingPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _01235_MaximumProfitInJobScheduling.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01235_MaximumProfitInJobSchedulingPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _01235_MaximumProfitInJobScheduling.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
