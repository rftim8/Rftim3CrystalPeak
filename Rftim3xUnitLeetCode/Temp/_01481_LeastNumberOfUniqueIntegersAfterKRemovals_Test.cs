using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _01481_LeastNumberOfUniqueIntegersAfterKRemovals_Test
    {
        // Arrange
        private static readonly int[] a0 = [5, 5, 4];
        private static readonly int a1 = 1, ar = 1;

        private static readonly int[] b0 = [4, 3, 1, 1, 3, 3, 2];
        private static readonly int b1 = 3, br = 2;

        public static TheoryData<int[], int, int> _01481_LeastNumberOfUniqueIntegersAfterKRemovals_Data =>
            new()
            {
                { a0, a1, ar },
                { b0, b1, br }
            };


        [Theory]
        [MemberData(nameof(_01481_LeastNumberOfUniqueIntegersAfterKRemovals_Data))]
        public void LeastNumberOfUniqueIntegersAfterKRemovals0(int[] a0, int a1, int expected)
        {
            // Act
            int actual = _01481_LeastNumberOfUniqueIntegersAfterKRemovals.LeastNumberOfUniqueIntegersAfterKRemovals0(a0, a1);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01481_LeastNumberOfUniqueIntegersAfterKRemovals_Data))]
        public void LeastNumberOfUniqueIntegersAfterKRemovals1(int[] a0, int a1, int expected)
        {
            // Act
            int actual = _01481_LeastNumberOfUniqueIntegersAfterKRemovals.LeastNumberOfUniqueIntegersAfterKRemovals1(a0, a1);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}