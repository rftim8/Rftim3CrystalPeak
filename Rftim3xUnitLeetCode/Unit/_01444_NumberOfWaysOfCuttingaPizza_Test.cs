using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _01444_NumberOfWaysOfCuttingaPizza_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_01444_NumberOfWaysOfCuttingaPizza))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01444_NumberOfWaysOfCuttingaPizza))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01444_NumberOfWaysOfCuttingaPizza))![1]);

        public static TheoryData<List<string>, int> _01444_NumberOfWaysOfCuttingaPizzaPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _01444_NumberOfWaysOfCuttingaPizzaPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_01444_NumberOfWaysOfCuttingaPizzaPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _01444_NumberOfWaysOfCuttingaPizza.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01444_NumberOfWaysOfCuttingaPizzaPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _01444_NumberOfWaysOfCuttingaPizza.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
