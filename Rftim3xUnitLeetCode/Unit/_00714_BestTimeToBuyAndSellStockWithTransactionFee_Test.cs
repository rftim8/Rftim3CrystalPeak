using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _00714_BestTimeToBuyAndSellStockWithTransactionFee_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_00714_BestTimeToBuyAndSellStockWithTransactionFee))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_00714_BestTimeToBuyAndSellStockWithTransactionFee))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_00714_BestTimeToBuyAndSellStockWithTransactionFee))![1]);

        public static TheoryData<List<string>, int> _00714_BestTimeToBuyAndSellStockWithTransactionFeePartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _00714_BestTimeToBuyAndSellStockWithTransactionFeePartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_00714_BestTimeToBuyAndSellStockWithTransactionFeePartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _00714_BestTimeToBuyAndSellStockWithTransactionFee.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00714_BestTimeToBuyAndSellStockWithTransactionFeePartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _00714_BestTimeToBuyAndSellStockWithTransactionFee.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
