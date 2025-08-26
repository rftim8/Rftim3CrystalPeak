namespace Rftim3xUnitLeetCode.Temp
{
    public class _00169_MajorityElement_Test
    {
        // Arrange
        private static readonly int[] a0 = [3, 2, 3];
        private static readonly int ar = 3;

        private static readonly int[] b0 = [2, 2, 1, 1, 1, 2, 2];
        private static readonly int br = 2;

        public static TheoryData<int[], int> _00169_MajorityElement_Data =>
            new()
            {
                { a0, ar },
                { b0, br }
            };

        [Theory]
        [MemberData(nameof(_00169_MajorityElement_Data))]
        public void MajorityElement0(int[] nums, int expected)
        {
            // Act
            //int actual = _00169_MajorityElement.MajorityElement0(nums);

            // Assert
            //Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00169_MajorityElement_Data))]
        public void MajorityElement1(int[] nums, int expected)
        {
            // Act
            //int actual = _00169_MajorityElement.MajorityElement1(nums);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
