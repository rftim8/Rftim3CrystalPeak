using Rftim3CodinGame.Refactor.Puzzles;

namespace Rftim3xUnitCodinGame.Unit.Puzzles
{
    public class FloodFillExample_Test
    {
        // Arrange
        private static readonly string[] a0 =
            [
                "..#.#...##",
                "#..#.#....",
                ".........#",
                "..#..#..#.",
                ".......#..",
                "..#.JEDI.#",
                "..#.....#.",
                ".....#..#.",
                "..........",
                ".........."
            ];
        private static readonly int a1 = 10, a2 = 10;
        private static readonly string[] ar = 
            [
                "JJ#.#DDD##",
                "#JJ#J#DDDD",
                "JJJJJ+DDD#",
                "JJ#JJ#DD#I",
                "JJJJJED#II",
                "JJ#JJEDII#",
                "JJ#JJEDI#I",
                "JJJJJ#DI#I",
                "JJJJJ+DIII",
                "JJJJJ+DIII"
            ];

        public static TheoryData<string[], int, int, string[]> FloodFillExample_Data =>
            new()
            {
                { a0, a1, a2, ar }
            };

        [Theory]
        [MemberData(nameof(FloodFillExample_Data))]
        public void FloodFillExample0(string[] a0, int a1, int a2, string[] expected)
        {
            // Act
            string[] actual = FloodFillExample.FloodFillExample0(a0, a1, a2);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
