using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00718_MaximumLengthOfRepeatedSubarray_Test
    {
        // Arrange
        private static readonly int[] a0 = [1, 2, 3, 2, 1], a1 = [3, 2, 1, 4, 7];
        private static readonly int ar = 3;

        private static readonly int[] b0 = [0, 0, 0, 0, 0], b1 = [0, 0, 0, 0, 0];
        private static readonly int br = 5;

        public static TheoryData<int[], int[], int> _00718_MaximumLengthOfRepeatedSubarray_Data =>
            new()
            {
                { a0, a1, ar },
                { b0, b1, br }
            };

        [Theory]
        [MemberData(nameof(_00718_MaximumLengthOfRepeatedSubarray_Data))]
        public void MaximumLengthOfRepeatedSubarray0(int[] a0, int[] a1, int expected)
        {
            // Act
            int actual = _00718_MaximumLengthOfRepeatedSubarray.MaximumLengthOfRepeatedSubarray0(a0, a1);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00718_MaximumLengthOfRepeatedSubarray_Data))]
        public void MaximumLengthOfRepeatedSubarray1(int[] a0, int[] a1, int expected)
        {
            // Act
            int actual = _00718_MaximumLengthOfRepeatedSubarray.MaximumLengthOfRepeatedSubarray1(a0, a1);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}