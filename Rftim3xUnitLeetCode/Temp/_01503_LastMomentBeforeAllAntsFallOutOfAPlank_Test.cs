namespace Rftim3xUnitLeetCode.Temp
{
    public class _01503_LastMomentBeforeAllAntsFallOutOfAPlank_Test
    {
        // Arrange
        private static readonly int a0 = 4;
        private static readonly int[] a1 = [4, 3];
        private static readonly int[] a2 = [0, 1];
        private static readonly int ar = 4;

        private static readonly int b0 = 7;
        private static readonly int[] b1 = [];
        private static readonly int[] b2 = [0, 1, 2, 3, 4, 5, 6, 7];
        private static readonly int br = 7;

        private static readonly int c0 = 7;
        private static readonly int[] c1 = [0, 1, 2, 3, 4, 5, 6, 7];
        private static readonly int[] c2 = [];
        private static readonly int cr = 7;

        public static TheoryData<int, int[], int[], int> _01503_LastMomentBeforeAllAntsFallOutOfAPlank_Data =>
            new()
            {
                { a0, a1, a2, ar },
                { b0, b1, b2, br },
                { c0, c1, c2, cr }
            };

        [Theory]
        [MemberData(nameof(_01503_LastMomentBeforeAllAntsFallOutOfAPlank_Data))]
        public void GetLastMoment0(int n, int[] left, int[] right, int expected)
        {
            // Act
            //int actual = _01503_LastMomentBeforeAllAntsFallOutOfAPlank.GetLastMoment0(n, left, right);

            // Assert
            //Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01503_LastMomentBeforeAllAntsFallOutOfAPlank_Data))]
        public void GetLastMoment1(int n, int[] left, int[] right, int expected)
        {
            // Act
            //int actual = _01503_LastMomentBeforeAllAntsFallOutOfAPlank.GetLastMoment1(n, left, right);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
