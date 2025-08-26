using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00930_BinarySubarraysWithSum_Test
    {
        // Arrange
        private static readonly int[] a0 = [1, 0, 1, 0, 1];
        private static readonly int a1 = 2, ar = 4;

        private static readonly int[] b0 = [0, 0, 0, 0, 0];
        private static readonly int b1 = 0, br = 15;

        public static TheoryData<int[], int, int> _00930_BinarySubarraysWithSum_Data =>
            new()
            {
                { a0, a1, ar },
                { b0, b1, br }
            };


        [Theory]
        [MemberData(nameof(_00930_BinarySubarraysWithSum_Data))]
        public void BinarySubarraysWithSum0(int[] a0, int a1, int expected)
        {
            // Act
            int actual = _00930_BinarySubarraysWithSum.BinarySubarraysWithSum0(a0, a1);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00930_BinarySubarraysWithSum_Data))]
        public void BinarySubarraysWithSum1(int[] a0, int a1, int expected)
        {
            // Act
            int actual = _00930_BinarySubarraysWithSum.BinarySubarraysWithSum1(a0, a1);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}