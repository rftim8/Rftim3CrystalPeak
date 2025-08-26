using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00787_CheapestFlightsWithinKStops_Test
    {
        // Arrange
        private static readonly int a0 = 4;
        private static readonly int[][] a1 = [[0, 1, 100], [1, 2, 100], [2, 0, 100], [1, 3, 600], [2, 3, 200]];
        private static readonly int a2 = 0, a3 = 3, a4 = 1, ar = 700;

        private static readonly int b0 = 3;
        private static readonly int[][] b1 = [[0, 1, 100], [1, 2, 100], [0, 2, 500]];
        private static readonly int b2 = 0, b3 = 2, b4 = 1, br = 200;

        private static readonly int c0 = 3;
        private static readonly int[][] c1 = [[0, 1, 100], [1, 2, 100], [0, 2, 500]];
        private static readonly int c2 = 0, c3 = 2, c4 = 0, cr = 500;

        public static TheoryData<int, int[][], int, int, int, int> _00787_CheapestFlightsWithinKStops_Data =>
            new()
            {
                { a0, a1, a2, a3, a4, ar },
                { b0, b1, b2, b3, b4, br },
                { c0, c1, c2, c3, c4, cr }
            };


        [Theory]
        [MemberData(nameof(_00787_CheapestFlightsWithinKStops_Data))]
        public void CheapestFlightsWithinKStops0(int a0, int[][] a1, int a2, int a3, int a4, int expected)
        {
            // Act
            int actual = _00787_CheapestFlightsWithinKStops.CheapestFlightsWithinKStops0(a0, a1, a2, a3, a4);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}