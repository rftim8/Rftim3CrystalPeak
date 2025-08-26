using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00188_BestTimetoBuyandSellStockIV_Test
    {
        // Arrange
        private static readonly int a0 = 2, ar = 2;
        private static readonly int[] a1 = [2, 4, 1];

        private static readonly int b0 = 2, br = 7;
        private static readonly int[] b1 = [3, 2, 6, 5, 0, 3];

        public static TheoryData<int, int[], int> _00188_BestTimetoBuyandSellStockIV_Data =>
            new()
            {
                { a0, a1, ar },
                { b0, b1, br }
            };

        [Theory]
        [MemberData(nameof(_00188_BestTimetoBuyandSellStockIV_Data))]
        public void BestTimetoBuyandSellStockIV0(int a0, int[] a1, int expected)
        {
            // Act
            int actual = _00188_BestTimetoBuyandSellStockIV.BestTimetoBuyandSellStockIV0(a0, a1);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00188_BestTimetoBuyandSellStockIV_Data))]
        public void BestTimetoBuyandSellStockIV1(int a0, int[] a1, int expected)
        {
            // Act
            int actual = _00188_BestTimetoBuyandSellStockIV.BestTimetoBuyandSellStockIV1(a0, a1);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00188_BestTimetoBuyandSellStockIV_Data))]
        public void BestTimetoBuyandSellStockIV2(int a0, int[] a1, int expected)
        {
            // Act
            int actual = _00188_BestTimetoBuyandSellStockIV.BestTimetoBuyandSellStockIV2(a0, a1);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}