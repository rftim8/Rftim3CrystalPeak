using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _01565_UniqueOrdersandCustomersPerMonth_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_01565_UniqueOrdersandCustomersPerMonth))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01565_UniqueOrdersandCustomersPerMonth))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01565_UniqueOrdersandCustomersPerMonth))![1]);

        public static TheoryData<List<string>, int> _01565_UniqueOrdersandCustomersPerMonthPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _01565_UniqueOrdersandCustomersPerMonthPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_01565_UniqueOrdersandCustomersPerMonthPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _01565_UniqueOrdersandCustomersPerMonth.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01565_UniqueOrdersandCustomersPerMonthPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _01565_UniqueOrdersandCustomersPerMonth.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
