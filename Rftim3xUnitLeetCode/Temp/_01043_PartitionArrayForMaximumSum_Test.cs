using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _01043_PartitionArrayForMaximumSum_Test
    {
        // Arrange
        private static readonly int[] a0 = [1, 15, 7, 9, 2, 5, 10];
        private static readonly int a1 = 3, ar = 84;

        private static readonly int[] b0 = [1, 4, 1, 5, 7, 3, 6, 1, 9, 9, 3];
        private static readonly int b1 = 4, br = 83;

        private static readonly int[] c0 = [1];
        private static readonly int c1 = 1, cr = 1;

        public static TheoryData<int[], int, int> _01043_PartitionArrayForMaximumSum_Data =>
            new()
            {
                { a0, a1, ar },
                { b0, b1, br },
                { c0, c1, cr }
            };


        [Theory]
        [MemberData(nameof(_01043_PartitionArrayForMaximumSum_Data))]
        public void PartitionArrayForMaximumSum0(int[] a0, int a1, int expected)
        {
            // Act
            int actual = _01043_PartitionArrayForMaximumSum.PartitionArrayForMaximumSum0(a0, a1);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01043_PartitionArrayForMaximumSum_Data))]
        public void PartitionArrayForMaximumSum1(int[] a0, int a1, int expected)
        {
            // Act
            int actual = _01043_PartitionArrayForMaximumSum.PartitionArrayForMaximumSum1(a0, a1);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01043_PartitionArrayForMaximumSum_Data))]
        public void PartitionArrayForMaximumSum2(int[] a0, int a1, int expected)
        {
            // Act
            int actual = _01043_PartitionArrayForMaximumSum.PartitionArrayForMaximumSum2(a0, a1);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01043_PartitionArrayForMaximumSum_Data))]
        public void PartitionArrayForMaximumSum3(int[] a0, int a1, int expected)
        {
            // Act
            int actual = _01043_PartitionArrayForMaximumSum.PartitionArrayForMaximumSum3(a0, a1);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}