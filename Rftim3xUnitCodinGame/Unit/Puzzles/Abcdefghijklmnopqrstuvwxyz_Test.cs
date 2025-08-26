using Rftim3CodinGame.Refactor.Puzzles;

namespace Rftim3xUnitCodinGame.Unit.Puzzles
{
    public class Abcdefghijklmnopqrstuvwxyz_Test
    {
        // Arrange
        private static readonly char[][] a0 = [
            ['q', 'a', 'd', 'n', 'h', 'w', 'b', 'n', 'y', 'w'],
            ['i', 'i', 'o', 'p', 'c', 'y', 'g', 'y', 'd', 'k'],
            ['b', 'a', 'h', 'l', 'f', 'i', 'o', 'j', 'd', 'c'],
            ['c', 'f', 'i', 'j', 't', 'd', 'm', 'k', 'g', 'f'],
            ['d', 'z', 'h', 'k', 'l', 'i', 'p', 'l', 'z', 'g'],
            ['e', 'f', 'g', 'r', 'm', 'p', 'q', 'r', 'y', 'x'],
            ['l', 'o', 'e', 'h', 'n', 'o', 'v', 's', 't', 'w'],
            ['j', 'r', 's', 'a', 'c', 'y', 'm', 'e', 'u', 'v'],
            ['f', 'p', 'n', 'o', 'c', 'p', 'd', 'k', 'r', 's'],
            ['j', 'l', 'm', 's', 'v', 'w', 'v', 'u', 'i', 'h']
        ];

        private static readonly char[][] ar = [
            ['-', '-', '-', '-', '-', '-', '-', '-', '-', '-'],
            ['-', '-', '-', '-', '-', '-', '-', '-', '-', '-'],
            ['b', 'a', '-', '-', '-', '-', '-', '-', '-', '-'],
            ['c', '-', 'i', 'j', '-', '-', '-', '-', '-', '-'],
            ['d', '-', 'h', 'k', 'l', '-', '-', '-', 'z', '-'],
            ['e', 'f', 'g', '-', 'm', 'p', 'q', 'r', 'y', 'x'],
            ['-', '-', '-', '-', 'n', 'o', '-', 's', 't', 'w'],
            ['-', '-', '-', '-', '-', '-', '-', '-', 'u', 'v'],
            ['-', '-', '-', '-', '-', '-', '-', '-', '-', '-'],
            ['-', '-', '-', '-', '-', '-', '-', '-', '-', '-']
        ];

        public static IEnumerable<object[]> Abcdefghijklmnopqrstuvwxyz_Data =>
            new List<object[]>
            {
                new object[] { a0, ar }
            };

        [Theory]
        [MemberData(nameof(Abcdefghijklmnopqrstuvwxyz_Data))]
        public void RftSolve(char[][] input, char[][] expected)
        {
            // Act
            char[][] actual = Abcdefghijklmnopqrstuvwxyz.RftSolve(input);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
