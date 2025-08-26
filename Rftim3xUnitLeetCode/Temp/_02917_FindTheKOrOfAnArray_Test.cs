namespace Rftim3xUnitLeetCode.Temp
{
    public class _02917_FindTheKOrOfAnArray_Test
    {
        // Arrange
        private static readonly int[] a0 = [7, 12, 9, 8, 9, 15];
        private static readonly int a1 = 4;
        private static readonly int ar = 9;

        private static readonly int[] b0 = [2, 12, 1, 11, 4, 5];
        private static readonly int b1 = 6;
        private static readonly int br = 0;

        private static readonly int[] c0 = [10, 8, 5, 9, 11, 6, 8];
        private static readonly int c1 = 1;
        private static readonly int cr = 15;

        public static TheoryData<int[], int, int> _02917_FindTheKOrOfAnArray_Data =>
            new()
            {
                { a0, a1, ar },
                { b0, b1, br },
                { c0, c1, cr }
            };

        [Theory]
        [MemberData(nameof(_02917_FindTheKOrOfAnArray_Data))]
        public void FindKOr0(int[] a0, int a1, int expected)
        {
            // Act
            //int actual = _02917_FindTheKOrOfAnArray.FindKOr0(a0, a1);

            // Assert
            //Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02917_FindTheKOrOfAnArray_Data))]
        public void FindKOr1(int[] a0, int a1, int expected)
        {
            // Act
            //int actual = _02917_FindTheKOrOfAnArray.FindKOr1(a0, a1);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
