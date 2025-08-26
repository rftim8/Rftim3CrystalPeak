using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00121_BestTimeToBuyAndSellStock_Test
    {
        // Arrange
        private static readonly int[] a0 = [7, 1, 5, 3, 6, 4];
        private static readonly int ar = 5;

        private static readonly int[] b0 = [7, 6, 4, 3, 1];
        private static readonly int Br = 0;

        public static TheoryData<int[], int> _00121_BestTimeToBuyAndSellStock_Data =>
            new()
            {
                { a0, ar },
                { b0, Br }
            };


        [Theory]
        [MemberData(nameof(_00121_BestTimeToBuyAndSellStock_Data))]
        public void BestTimeToBuyAndSellStock0(int[] a0, int expected)
        {
            // Act
            int actual = _00121_BestTimeToBuyAndSellStock.BestTimeToBuyAndSellStock0(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}