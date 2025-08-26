using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00118_PascalsTriangle_Test
    {
        // Arrange
        private static readonly int a0 = 5;
        private static readonly int[][] ar = [[1], [1, 1], [1, 2, 1], [1, 3, 3, 1], [1, 4, 6, 4, 1]];

        private static readonly int b0 = 1;
        private static readonly int[][] br = [[1]];

        public static TheoryData<int, int[][]> _00118_PascalsTriangle_Data =>
            new()
            {
                { a0, ar },
                { b0, br }
            };

        [Theory]
        [MemberData(nameof(_00118_PascalsTriangle_Data))]
        public void Generate0(int a0, int[][] expected)
        {
            // Act
            IList<IList<int>> actual = _00118_PascalsTriangle.Generate0(a0);

            // Assert
            //Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00118_PascalsTriangle_Data))]
        public void Generate1(int a0, int[][] expected)
        {
            // Act
            IList<IList<int>>? actual = _00118_PascalsTriangle.Generate0(a0);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
