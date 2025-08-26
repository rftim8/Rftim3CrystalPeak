using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _02149_RearrangeArrayElementsBySign_Test
    {
        // Arrange
        private static readonly int[] a0 = [3, 1, -2, -5, 2, -4];
        private static readonly int[] ar = [3, -2, 1, -5, 2, -4];

        private static readonly int[] b0 = [-1, 1];
        private static readonly int[] br = [1, -1];

        public static TheoryData<int[], int[]> _02149_RearrangeArrayElementsBySign_Data =>
            new()
            {
                { a0, ar },
                { b0, br }
            };

        [Theory]
        [MemberData(nameof(_02149_RearrangeArrayElementsBySign_Data))]
        public void RearrangeArrayElementsBySign0(int[] a0, int[] expected)
        {
            // Act
            int[] actual = _02149_RearrangeArrayElementsBySign.RearrangeArrayElementsBySign0(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}