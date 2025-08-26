namespace Rftim3xUnitLeetCode.Temp
{
    public class _00907_SumOfSubarrayMinimums_Test
    {
        // Arrange
        private static readonly int[] a0 = [3, 1, 2, 4];
        private static readonly int ar = 17;

        private static readonly int[] b0 = [11, 81, 94, 43, 3];
        private static readonly int br = 444;

        public static TheoryData<int[], int> _00907_SumOfSubarrayMinimums_Data =>
            new()
            {
                { a0, ar },
                { b0, br }
            };

        [Theory]
        [MemberData(nameof(_00907_SumOfSubarrayMinimums_Data))]
        public void SumSubarrayMins0(int[] a0, int expected)
        {
            // Act
            //int actual = _00907_SumOfSubarrayMinimums.SumSubarrayMins0(a0);

            // Assert
            //Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00907_SumOfSubarrayMinimums_Data))]
        public void SumSubarrayMins1(int[] a0, int expected)
        {
            // Act
            //int actual = _00907_SumOfSubarrayMinimums.SumSubarrayMins1(a0);

            // Assert
            //Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00907_SumOfSubarrayMinimums_Data))]
        public void SumSubarrayMins2(int[] a0, int expected)
        {
            // Act
            //int actual = _00907_SumOfSubarrayMinimums.SumSubarrayMins2(a0);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
