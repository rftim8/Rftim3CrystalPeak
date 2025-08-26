using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _02752_CustomersWithMaximumNumberOfTransactionsOnConsecutiveDays_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_02752_CustomersWithMaximumNumberOfTransactionsOnConsecutiveDays))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02752_CustomersWithMaximumNumberOfTransactionsOnConsecutiveDays))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02752_CustomersWithMaximumNumberOfTransactionsOnConsecutiveDays))![1]);

        public static TheoryData<List<string>, int> _02752_CustomersWithMaximumNumberOfTransactionsOnConsecutiveDaysPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _02752_CustomersWithMaximumNumberOfTransactionsOnConsecutiveDaysPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_02752_CustomersWithMaximumNumberOfTransactionsOnConsecutiveDaysPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _02752_CustomersWithMaximumNumberOfTransactionsOnConsecutiveDays.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02752_CustomersWithMaximumNumberOfTransactionsOnConsecutiveDaysPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _02752_CustomersWithMaximumNumberOfTransactionsOnConsecutiveDays.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
