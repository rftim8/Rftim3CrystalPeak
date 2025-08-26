using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00081_SearchinRotatedSortedArrayII_Test
    {
        // Arrange
        private static readonly int[] a0 = [];
        private static readonly int a1 = 0;
        private static readonly bool ar = true;

        public static TheoryData<int[], int, bool> _00081_SearchinRotatedSortedArrayII_Data =>
            new()
            {
                { a0, a1, ar }
            };


        [Theory]
        [MemberData(nameof(_00081_SearchinRotatedSortedArrayII_Data))]
        public void SearchinRotatedSortedArrayII0(int[] a0, int a1, bool expected)
        {
            // Act
            bool actual = _00081_SearchinRotatedSortedArrayII.SearchinRotatedSortedArrayII0(a0, a1);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}