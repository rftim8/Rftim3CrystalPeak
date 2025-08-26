using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _02806_AccountBalanceAfterRoundedPurchase_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_02806_AccountBalanceAfterRoundedPurchase))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02806_AccountBalanceAfterRoundedPurchase))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02806_AccountBalanceAfterRoundedPurchase))![1]);

        public static TheoryData<List<string>, int> _02806_AccountBalanceAfterRoundedPurchasePartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _02806_AccountBalanceAfterRoundedPurchasePartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_02806_AccountBalanceAfterRoundedPurchasePartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _02806_AccountBalanceAfterRoundedPurchase.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02806_AccountBalanceAfterRoundedPurchasePartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _02806_AccountBalanceAfterRoundedPurchase.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
