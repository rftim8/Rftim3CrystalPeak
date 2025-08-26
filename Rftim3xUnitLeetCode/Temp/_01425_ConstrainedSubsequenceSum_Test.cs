namespace Rftim3xUnitLeetCode.Temp
{
    public class _01425_ConstrainedSubsequenceSum_Test
    {
        // Arrange
        private static readonly int[] a0 = [10, 2, -10, 5, 20];
        private static readonly int a1 = 2;
        private static readonly int ar = 37;

        private static readonly int[] b0 = [-1, -2, -3];
        private static readonly int b1 = 1;
        private static readonly int br = -1;

        private static readonly int[] c0 = [10, -2, -10, -5, 20];
        private static readonly int c1 = 2;
        private static readonly int cr = 23;

        public static TheoryData<int[], int, int> _01425_ConstrainedSubsequenceSum_Data =>
            new()
            {
                { a0, a1, ar },
                { b0, b1, br },
                { c0, c1, cr }
            };

        [Theory]
        [MemberData(nameof(_01425_ConstrainedSubsequenceSum_Data))]
        public void ConstrainedSubsetSum0(int[] nums, int k, int expected)
        {
            // Act
            //int actual = _01425_ConstrainedSubsequenceSum.ConstrainedSubsetSum0(nums, k);

            // Assert
            //Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01425_ConstrainedSubsequenceSum_Data))]
        public void ConstrainedSubsetSum1(int[] nums, int k, int expected)
        {
            // Act
            //int actual = _01425_ConstrainedSubsequenceSum.ConstrainedSubsetSum1(nums, k);

            // Assert
            //Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01425_ConstrainedSubsequenceSum_Data))]
        public void ConstrainedSubsetSum2(int[] nums, int k, int expected)
        {
            // Act
            //int actual = _01425_ConstrainedSubsequenceSum.ConstrainedSubsetSum2(nums, k);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
