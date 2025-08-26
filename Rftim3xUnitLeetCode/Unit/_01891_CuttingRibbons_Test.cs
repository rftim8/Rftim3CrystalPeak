using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _01891_CuttingRibbons_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_01891_CuttingRibbons))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01891_CuttingRibbons))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01891_CuttingRibbons))![1]);

        public static TheoryData<List<string>, int> _01891_CuttingRibbonsPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _01891_CuttingRibbonsPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_01891_CuttingRibbonsPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _01891_CuttingRibbons.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01891_CuttingRibbonsPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _01891_CuttingRibbons.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
