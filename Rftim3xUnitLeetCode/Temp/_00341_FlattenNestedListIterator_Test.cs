using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00341_FlattenNestedListIterator_Test
    {
        // Arrange
        private static readonly int[] a0 = [1, 1];
        private static readonly int[] a1 = [1, 1];
        private static readonly int[] ar = [1, 1, 2, 1, 1];

        private static readonly int[] b0 = [1, 1];
        private static readonly int[] b1 = [1, 1];
        private static readonly int[] br = [1, 4, 6];

        public static TheoryData<int[], int[], int[]> _00341_FlattenNestedListIterator_Data =>
            new()
            {
                { a0, a1, ar },
                { b0, b1, br }
            };

        //[Theory]
        //[MemberData(nameof(_00341_FlattenNestedListIterator_Data))]
        public void FlattenNestedListIterator0(object[] s, int[] expected)
        {
            // Act
            IList<int> actual = _00341_FlattenNestedListIterator.FlattenNestedListIterator0();

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
