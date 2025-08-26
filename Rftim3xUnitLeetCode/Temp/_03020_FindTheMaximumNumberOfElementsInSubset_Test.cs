using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _03020_FindTheMaximumNumberOfElementsInSubset_Test
    {
        // Arrange
        private static readonly int[] a0 = [];
        private static readonly int ar = 0;

        public static TheoryData<int[], int> _03020_FindTheMaximumNumberOfElementsInSubset_Data =>
            new()
            {
                { a0, ar }
            };


        [Theory]
        [MemberData(nameof(_03020_FindTheMaximumNumberOfElementsInSubset_Data))]
        public void FindTheMaximumNumberOfElementsInSubset0(int[] a0, int expected)
        {
            // Act
            int actual = _03020_FindTheMaximumNumberOfElementsInSubset.FindTheMaximumNumberOfElementsInSubset0(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}