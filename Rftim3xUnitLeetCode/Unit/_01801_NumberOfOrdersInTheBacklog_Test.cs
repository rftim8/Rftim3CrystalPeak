using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _01801_NumberOfOrdersInTheBacklog_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_01801_NumberOfOrdersInTheBacklog))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01801_NumberOfOrdersInTheBacklog))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01801_NumberOfOrdersInTheBacklog))![1]);

        public static TheoryData<List<string>, int> _01801_NumberOfOrdersInTheBacklogPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _01801_NumberOfOrdersInTheBacklogPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_01801_NumberOfOrdersInTheBacklogPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _01801_NumberOfOrdersInTheBacklog.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01801_NumberOfOrdersInTheBacklogPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _01801_NumberOfOrdersInTheBacklog.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
