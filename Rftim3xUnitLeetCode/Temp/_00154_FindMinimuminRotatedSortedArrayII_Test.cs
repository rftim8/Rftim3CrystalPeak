using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00154_FindMinimumInRotatedSortedArrayII_Test
    {
        // Arrange
        private static readonly int[] a0 = [1, 3, 5];
        private static readonly int ar = 1;

        private static readonly int[] b0 = [2, 2, 2, 0, 1];
        private static readonly int br = 0;

        public static TheoryData<int[], int> _00154_FindMinimumInRotatedSortedArrayII_Data =>
            new()
            {
                { a0, ar },
                { b0, br }
            };


        [Theory]
        [MemberData(nameof(_00154_FindMinimumInRotatedSortedArrayII_Data))]
        public void FindMinimumInRotatedSortedArrayII0(int[] a0, int expected)
        {
            // Act
            int actual = _00154_FindMinimumInRotatedSortedArrayII.FindMinimumInRotatedSortedArrayII0(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}