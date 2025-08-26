namespace Rftim3xUnitLeetCode.Temp
{
    public class _00035_SearchInsertPosition_Test
    {
        // Arrange
        private static readonly int[] a0 = [1, 3, 5, 6];
        private static readonly int a1 = 5;
        private static readonly int ar = 2;

        private static readonly int[] b0 = [1, 3, 5, 6];
        private static readonly int b1 = 2;
        private static readonly int br = 1;

        private static readonly int[] c0 = [1, 3, 5, 6];
        private static readonly int c1 = 7;
        private static readonly int cr = 4;

        private static readonly int[] d0 = [1, 3];
        private static readonly int d1 = 2;
        private static readonly int dr = 1;

        public static TheoryData<int[], int, int> _00035_SearchInsertPosition_Data =>
            new()
            {
                { a0, a1, ar },
                { b0, b1, br },
                { c0, c1, cr },
                { d0, d1, dr }
            };

        [Theory]
        [MemberData(nameof(_00035_SearchInsertPosition_Data))]
        public void SearchInsertPosition0(int[] nums, int target, int expected)
        {
            // Act
            //int actual = _00035_SearchInsertPosition.SearchInsertPosition0(nums, target);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
