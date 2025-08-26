using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _02477_MinimumFuelCostToReportToTheCapital_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_02477_MinimumFuelCostToReportToTheCapital))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02477_MinimumFuelCostToReportToTheCapital))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02477_MinimumFuelCostToReportToTheCapital))![1]);

        public static TheoryData<List<string>, int> _02477_MinimumFuelCostToReportToTheCapitalPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _02477_MinimumFuelCostToReportToTheCapitalPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_02477_MinimumFuelCostToReportToTheCapitalPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _02477_MinimumFuelCostToReportToTheCapital.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02477_MinimumFuelCostToReportToTheCapitalPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _02477_MinimumFuelCostToReportToTheCapital.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
