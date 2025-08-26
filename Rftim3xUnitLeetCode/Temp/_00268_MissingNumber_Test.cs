namespace Rftim3xUnitLeetCode.Temp
{
    public class _00268_MissingNumber_Test
    {
        // Arrange
        private static readonly int[] a0 = [3, 0, 1];
        private static readonly int ar = 2;

        private static readonly int[] b0 = [0, 1];
        private static readonly int br = 2;

        private static readonly int[] c0 = [9, 6, 4, 2, 3, 5, 7, 0, 1];
        private static readonly int cr = 8;

        public static TheoryData<int[], int> _00268_MissingNumber_Data =>
            new()
            {
                { a0, ar },
                { b0, br },
                { c0, cr }
            };

        [Theory]
        [MemberData(nameof(_00268_MissingNumber_Data))]
        public void MissingNumber0(int[] nums, int expected)
        {
            // Act
            //int actual = _00268_MissingNumber.MissingNumber0(nums);

            // Assert
            //Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00268_MissingNumber_Data))]
        public void MissingNumber1(int[] nums, int expected)
        {
            // Act
            //int actual = _00268_MissingNumber.MissingNumber1(nums);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
