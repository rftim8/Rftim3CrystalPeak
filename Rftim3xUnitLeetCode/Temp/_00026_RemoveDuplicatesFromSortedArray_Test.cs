namespace Rftim3xUnitLeetCode.Temp
{
    public class _00026_RemoveDuplicatesFromSortedArray_Test
    {
        // Arrange
        private static readonly int[] a0 = [1, 1, 2];
        private static readonly int ar = 2;

        private static readonly int[] b0 = [0, 0, 1, 1, 1, 2, 2, 3, 3, 4];
        private static readonly int br = 5;

        public static TheoryData<int[], int> _00026_RemoveDuplicatesFromSortedArray_Data =>
            new()
            {
                { a0, ar },
                { b0, br }
            };

        [Theory]
        [MemberData(nameof(_00026_RemoveDuplicatesFromSortedArray_Data))]
        public void RemoveDuplicates0(int[] nums, int expected)
        {
            // Act
            //int actual = _00026_RemoveDuplicatesFromSortedArray.RemoveDuplicates0(nums);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
