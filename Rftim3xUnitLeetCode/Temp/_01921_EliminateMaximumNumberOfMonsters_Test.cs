namespace Rftim3xUnitLeetCode.Temp
{
    public class _01921_EliminateMaximumNumberOfMonsters_Test
    {
        // Arrange
        private static readonly int[] a0 = [1, 3, 4];
        private static readonly int[] a1 = [1, 1, 1];
        private static readonly int ar = 3;

        private static readonly int[] b0 = [1, 1, 2, 3];
        private static readonly int[] b1 = [1, 1, 1, 1];
        private static readonly int br = 1;

        private static readonly int[] c0 = [3, 2, 4];
        private static readonly int[] c1 = [5, 3, 2];
        private static readonly int cr = 1;

        private static readonly int[] d0 = [4, 2, 8];
        private static readonly int[] d1 = [2, 1, 4];
        private static readonly int dr = 2;

        private static readonly int[] e0 = [3, 5, 7, 4, 5];
        private static readonly int[] e1 = [2, 3, 6, 3, 2];
        private static readonly int er = 2;

        public static TheoryData<int[], int[], int> _01921_EliminateMaximumNumberOfMonsters_Data =>
            new()
            {
                { a0, a1, ar },
                { b0, b1, br },
                { c0, c1, cr },
                { d0, d1, dr },
                { e0, e1, er }
            };

        [Theory]
        [MemberData(nameof(_01921_EliminateMaximumNumberOfMonsters_Data))]
        public void EliminateMaximum0(int[] a0, int[] a1, int expected)
        {
            // Act
            //int actual = _01921_EliminateMaximumNumberOfMonsters.EliminateMaximum0(a0, a1);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
