namespace Rftim3xUnitLeetCode.Temp
{
    public class _00414_ThirdMaximumNumber_Test
    {
        // Arrange
        private static readonly int[] a0 = [3, 2, 1];
        private static readonly int ar = 1;

        private static readonly int[] b0 = [1, 2];
        private static readonly int br = 2;

        private static readonly int[] c0 = [2, 2, 3, 1];
        private static readonly int cr = 1;

        public static TheoryData<int[], int> _00414_ThirdMaximumNumber_Data =>
            new()
            {
                { a0, ar },
                { b0, br },
                { c0, cr }
            };

        [Theory]
        [MemberData(nameof(_00414_ThirdMaximumNumber_Data))]
        public void ThirdMax0(int[] nums, int expected)
        {
            // Act
            //int actual = _00414_ThirdMaximumNumber.ThirdMax0(nums);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
