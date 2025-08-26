using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00948_BagOfTokens_Test
    {
        // Arrange
        private static readonly int[] a0 = [100];
        private static readonly int a1 = 50, ar = 0;

        private static readonly int[] b0 = [200, 100];
        private static readonly int b1 = 150, br = 1;

        private static readonly int[] c0 = [100, 200, 300, 400];
        private static readonly int c1 = 200, cr = 2;

        public static TheoryData<int[], int, int> _00948_BagOfTokens_Data =>
            new()
            {
                { a0, a1, ar },
                { b0, b1, br },
                { c0, c1, cr }
            };


        [Theory]
        [MemberData(nameof(_00948_BagOfTokens_Data))]
        public void BagOfTokens0(int[] a0, int a1, int expected)
        {
            // Act
            int actual = _00948_BagOfTokens.BagOfTokens0(a0, a1);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00948_BagOfTokens_Data))]
        public void BagOfTokens1(int[] a0, int a1, int expected)
        {
            // Act
            int actual = _00948_BagOfTokens.BagOfTokens1(a0, a1);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}