using Rftim3CodinGame.Refactor.Puzzles;

namespace Rftim3xUnitCodinGame.Unit.Puzzles
{
    public class MovesInMaze_Test
    {
        // Arrange
        private static readonly char[][] a0 = [
            ['#', '#', '#', '#', '#', '#', '#', '#', '#', '#'],
            ['#', 'S', '.', '.', '.', '.', '.', '.', '.', '#'],
            ['#', '#', '.', '#', '#', '#', '#', '#', '.', '#'],
            ['#', '#', '.', '#', '.', '.', '.', '.', '.', '#'],
            ['#', '#', '#', '#', '#', '#', '#', '#', '#', '#']
        ];
        private static readonly char[][] ar = [
            ['#', '#', '#', '#', '#', '#', '#', '#', '#', '#'],
            ['#', '0', '1', '2', '3', '4', '5', '6', '7', '#'],
            ['#', '#', '2', '#', '#', '#', '#', '#', '8', '#'],
            ['#', '#', '3', '#', 'D', 'C', 'B', 'A', '9', '#'],
            ['#', '#', '#', '#', '#', '#', '#', '#', '#', '#']
        ];

        public static IEnumerable<object[]> MovesInMaze_Data =>
            new List<object[]>
            {
                new object[] { a0, ar }
            };

        [Theory]
        [MemberData(nameof(MovesInMaze_Data))]
        public void RftSolve(char[][] map, char[][] expected)
        {
            // Act
            char[][] actual = MovesInMaze.RftSolve(map);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
