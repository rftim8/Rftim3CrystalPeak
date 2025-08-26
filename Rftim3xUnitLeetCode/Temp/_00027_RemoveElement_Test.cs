namespace Rftim3xUnitLeetCode.Temp
{
    public class _00027_RemoveElement_Test
    {
        // Arrange
        private static readonly int[] a0 = [3, 2, 2, 3];
        private static readonly int a1 = 3;
        private static readonly int ar = 2;

        private static readonly int[] b0 = [0, 1, 2, 2, 3, 0, 4, 2];
        private static readonly int b1 = 2;
        private static readonly int br = 5;

        public static TheoryData<int[], int, int> _00027_RemoveElement_Data =>
            new()
            {
                { a0, a1, ar },
                { b0, b1, br }
            };

        [Theory]
        [MemberData(nameof(_00027_RemoveElement_Data))]
        public void RemoveElement0(int[] nums, int val, int expected)
        {
            // Act
            //int actual = _00027_RemoveElement.RemoveElement0(nums, val);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
