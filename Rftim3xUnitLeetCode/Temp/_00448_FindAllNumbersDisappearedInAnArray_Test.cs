using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00448_FindAllNumbersDisappearedInAnArray_Test
    {
        // Arrange
        private static readonly int[] a0 = [4, 3, 2, 7, 8, 2, 3, 1];
        private static readonly int[] ar = [5, 6];

        private static readonly int[] b0 = [1, 1];
        private static readonly int[] br = [2];

        public static TheoryData<int[], int[]> _00448_FindAllNumbersDisappearedInAnArray_Data =>
            new()
            {
                { a0, ar },
                { b0, br }
            };

        [Theory]
        [MemberData(nameof(_00448_FindAllNumbersDisappearedInAnArray_Data))]
        public void FindDisappearedNumbers0(int[] nums, IList<int> expected)
        {
            // Act
            IList<int> actual = _00448_FindAllNumbersDisappearedInAnArray.FindDisappearedNumbers0(nums);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
