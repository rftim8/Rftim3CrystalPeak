using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _01581_CustomerWhoVisitedButDidNotMakeAnyTransactions_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_01581_CustomerWhoVisitedButDidNotMakeAnyTransactions))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01581_CustomerWhoVisitedButDidNotMakeAnyTransactions))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01581_CustomerWhoVisitedButDidNotMakeAnyTransactions))![1]);

        public static TheoryData<List<string>, int> _01581_CustomerWhoVisitedButDidNotMakeAnyTransactionsPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _01581_CustomerWhoVisitedButDidNotMakeAnyTransactionsPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_01581_CustomerWhoVisitedButDidNotMakeAnyTransactionsPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _01581_CustomerWhoVisitedButDidNotMakeAnyTransactions.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01581_CustomerWhoVisitedButDidNotMakeAnyTransactionsPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _01581_CustomerWhoVisitedButDidNotMakeAnyTransactions.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
