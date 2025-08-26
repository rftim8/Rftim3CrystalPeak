using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _01491_AverageSalaryExcludingTheMinimumAndMaximumSalary_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_01491_AverageSalaryExcludingTheMinimumAndMaximumSalary))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01491_AverageSalaryExcludingTheMinimumAndMaximumSalary))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01491_AverageSalaryExcludingTheMinimumAndMaximumSalary))![1]);

        public static TheoryData<List<string>, int> _01491_AverageSalaryExcludingTheMinimumAndMaximumSalaryPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _01491_AverageSalaryExcludingTheMinimumAndMaximumSalaryPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_01491_AverageSalaryExcludingTheMinimumAndMaximumSalaryPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _01491_AverageSalaryExcludingTheMinimumAndMaximumSalary.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01491_AverageSalaryExcludingTheMinimumAndMaximumSalaryPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _01491_AverageSalaryExcludingTheMinimumAndMaximumSalary.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
