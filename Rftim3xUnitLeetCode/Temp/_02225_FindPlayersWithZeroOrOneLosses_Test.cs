using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _02225_FindPlayersWithZeroOrOneLosses_Test
    {
        // Arrange
        private static readonly int[][] a0 = [[1, 3], [2, 3], [3, 6], [5, 6], [5, 7], [4, 5], [4, 8], [4, 9], [10, 4], [10, 9]];
        private static readonly IList<IList<int>> ar = [[1, 2, 10], [4, 5, 7, 8]];

        public static TheoryData<int[][], IList<IList<int>>> _02225_FindPlayersWithZeroOrOneLosses_Data =>
            new()
            {
                { a0, ar }
            };

        [Theory]
        [MemberData(nameof(_02225_FindPlayersWithZeroOrOneLosses_Data))]
        public void FindWinners0(int[][] a0, IList<IList<int>> expected)
        {
            // Act
            IList<IList<int>> actual = _02225_FindPlayersWithZeroOrOneLosses.FindWinners0(a0);

            // Assert
            //Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02225_FindPlayersWithZeroOrOneLosses_Data))]
        public void FindWinners1(int[][] a0, IList<IList<int>> expected)
        {
            // Act
            IList<IList<int>> actual = _02225_FindPlayersWithZeroOrOneLosses.FindWinners1(a0);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
