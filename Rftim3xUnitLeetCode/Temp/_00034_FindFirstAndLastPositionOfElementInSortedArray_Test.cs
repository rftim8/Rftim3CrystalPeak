using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00034_FindFirstAndLastPositionOfElementInSortedArray_Test
    {
        // Arrange
        private static readonly int[] a0 = [];
        private static readonly int a1 = 0;
        private static readonly int[] ar = [];

        public static TheoryData<int[], int, int[]> _00034_FindFirstAndLastPositionOfElementInSortedArray_Data =>
            new()
            {
                { a0, a1, ar }
            };


        [Theory]
        [MemberData(nameof(_00034_FindFirstAndLastPositionOfElementInSortedArray_Data))]
        public void FindFirstAndLastPositionOfElementInSortedArray0(int[] a0, int a1, int[] expected)
        {
            // Act
            int[] actual = _00034_FindFirstAndLastPositionOfElementInSortedArray.FindFirstAndLastPositionOfElementInSortedArray0(a0, a1);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}