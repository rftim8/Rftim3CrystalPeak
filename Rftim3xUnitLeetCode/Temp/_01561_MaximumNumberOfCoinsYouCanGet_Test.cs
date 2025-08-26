using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _01561_MaximumNumberOfCoinsYouCanGet_Test
    {
        // Arrange
        private static readonly int[] a0 = [2, 4, 1, 2, 7, 8];
        private static readonly int ar = 9;

        private static readonly int[] b0 = [2, 4, 5];
        private static readonly int br = 4;

        private static readonly int[] c0 = [9, 8, 7, 6, 5, 1, 2, 3, 4];
        private static readonly int cr = 18;

        public static TheoryData<int[], int> _01561_MaximumNumberOfCoinsYouCanGet_Data =>
            new()
            {
                { a0, ar },
                { b0, br },
                { c0, cr }
            };

        [Theory]
        [MemberData(nameof(_01561_MaximumNumberOfCoinsYouCanGet_Data))]
        public void MaxCoins0(int[] a0, int expected)
        {
            // Act
            int actual = _01561_MaximumNumberOfCoinsYouCanGet.MaxCoins0(a0);

            // Assert
            Assert.Equivalent(expected, actual, true);
        }
    }
}
