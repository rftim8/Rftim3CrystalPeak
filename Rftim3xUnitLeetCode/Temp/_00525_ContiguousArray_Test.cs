using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00525_ContiguousArray_Test
    {
        // Arrange
        private static readonly int[] a0 = [0, 1];
        private static readonly int ar = 2;

        private static readonly int[] b0 = [0, 1, 0];
        private static readonly int br = 2;

        private static readonly int[] c0 = [0, 1, 1];
        private static readonly int cr = 2;

        private static readonly int[] d0 = [0, 1, 0, 1];
        private static readonly int dr = 4;

        public static TheoryData<int[], int> _00525_ContiguousArray_Data =>
            new()
            {
                { a0, ar },
                { b0, br },
                { c0, cr },
                { d0, dr }
            };


        [Theory]
        [MemberData(nameof(_00525_ContiguousArray_Data))]
        public void ContiguousArray0(int[] a0, int expected)
        {
            // Act
            int actual = _00525_ContiguousArray.ContiguousArray0(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}