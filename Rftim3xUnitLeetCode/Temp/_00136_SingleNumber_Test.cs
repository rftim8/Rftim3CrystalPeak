namespace Rftim3xUnitLeetCode.Temp
{
    public class _00136_SingleNumber_Test
    {
        // Arrange
        private static readonly int[] a0 = [2, 2, 1];
        private static readonly int ar = 1;

        private static readonly int[] b0 = [4, 1, 2, 1, 2];
        private static readonly int br = 4;

        private static readonly int[] c0 = [1];
        private static readonly int cr = 1;

        public static TheoryData<int[], int> _00136_SingleNumber_Data =>
            new()
            {
                { a0, ar },
                { b0, br },
                { c0, cr }
            };

        [Theory]
        [MemberData(nameof(_00136_SingleNumber_Data))]
        public void SingleNumber0(int[] nums, int expected)
        {
            // Act
            //int actual = _00136_SingleNumber.SingleNumber0(nums);

            // Assert
            //Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00136_SingleNumber_Data))]
        public void SingleNumber1(int[] nums, int expected)
        {
            // Act
            //int actual = _00136_SingleNumber.SingleNumber1(nums);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
