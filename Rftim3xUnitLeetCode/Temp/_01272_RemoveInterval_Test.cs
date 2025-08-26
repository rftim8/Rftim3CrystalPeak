using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _01272_RemoveInterval_Test
    {
        // Arrange
        private static readonly int[][] a0 = [[0, 2], [3, 4], [5, 7]];
        private static readonly int[] a1 = [1, 6];
        private static readonly List<IList<int>> ar = [[0, 1], [6, 7]];

        private static readonly int[][] b0 = [[0, 5]];
        private static readonly int[] b1 = [2, 3];
        private static readonly List<IList<int>> br = [[0, 2], [3, 5]];

        private static readonly int[][] c0 = [[-5, -4], [-3, -2], [1, 2], [3, 5], [8, 9]];
        private static readonly int[] c1 = [-1, 4];
        private static readonly List<IList<int>> cr = [[-5, -4], [-3, -2], [4, 5], [8, 9]];

        public static TheoryData<int[][], int[], List<IList<int>>> _01272_RemoveInterval_Data =>
            new()
            {
                { a0, a1, ar },
                { b0, b1, br },
                { c0, c1, cr }
            };


        [Theory]
        [MemberData(nameof(_01272_RemoveInterval_Data))]
        public void RemoveInterval0(int[][] a0, int[] a1, List<IList<int>> expected)
        {
            // Act
            IList<IList<int>> actual = _01272_RemoveInterval.RemoveInterval0(a0, a1);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}