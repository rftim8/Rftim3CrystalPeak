namespace Rftim3xUnitLeetCode.Temp
{
    public class _00160_IntersectionOfTwoLinkedLists_Test
    {
        // Arrange
        private static readonly int[] a0 = [4, 1, 8, 4, 5];
        private static readonly int[] a1 = [5, 6, 1, 8, 4, 5];
        private static readonly int a2 = 2, a3 = 3, ar = 8;

        private static readonly int[] b0 = [1, 9, 1, 2, 4];
        private static readonly int[] b1 = [3, 2, 4];
        private static readonly int b2 = 3, b3 = 1, br = 2;

        private static readonly int[] c0 = [2, 6, 4];
        private static readonly int[] c1 = [1, 5];
        private static readonly int c2 = 3, c3 = 2, cr = 0;

        public static TheoryData<int[], int[], int, int, int> _00160_IntersectionOfTwoLinkedLists_Data =>
            new()
            {
                { a0, a1, a2, a3, ar },
                { b0, b1, b2, b3, br },
                { c0, c1, c2, c3, cr }
            };


        [Theory]
        [MemberData(nameof(_00160_IntersectionOfTwoLinkedLists_Data))]
        public void IntersectionOfTwoLinkedLists0(int[] a0, int[] a1, int a2, int a3, int expected)
        {
            // Act
            //int actual = _00160_IntersectionOfTwoLinkedLists.IntersectionOfTwoLinkedLists0(a0, a1);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}