namespace Rftim3xUnitLeetCode.Temp
{
    public class _01793_MaximumScoreOfAGoodSubarray_Test
    {
        // Arrange
        private static readonly int[] a0 = [1, 4, 3, 7, 4, 5];
        private static readonly int a1 = 3;
        private static readonly int ar = 15;

        private static readonly int[] b0 = [5, 5, 4, 5, 4, 1, 1, 1];
        private static readonly int b1 = 0;
        private static readonly int br = 20;

        public static TheoryData<int[], int, int> _01793_MaximumScoreOfAGoodSubarray_Data =>
            new()
            {
                { a0, a1, ar },
                { b0, b1, br }
            };


        [Theory]
        [MemberData(nameof(_01793_MaximumScoreOfAGoodSubarray_Data))]
        public void MaximumScore0(int[] nums, int k, int expected)
        {
            // Act
            //int actual = _01793_MaximumScoreOfAGoodSubarray.MaximumScore0(nums, k);

            // Assert
            //Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01793_MaximumScoreOfAGoodSubarray_Data))]
        public void MaximumScore1(int[] nums, int k, int expected)
        {
            // Act
            //int actual = _01793_MaximumScoreOfAGoodSubarray.MaximumScore1(nums, k);

            // Assert
            //Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01793_MaximumScoreOfAGoodSubarray_Data))]
        public void MaximumScore2(int[] nums, int k, int expected)
        {
            // Act
            //int actual = _01793_MaximumScoreOfAGoodSubarray.MaximumScore2(nums, k);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
