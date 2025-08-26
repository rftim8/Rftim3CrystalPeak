using Rftim3CodinGame.Refactor.Puzzles;

namespace Rftim3xUnitCodinGame.Unit.Puzzles
{
    public class TableOfContents_Test
    {
        // Arrange
        private static readonly List<string> a0 = [
            "Sudamerica 1",
            ">Argentina 5",
            ">>BuenosAires 8",
            ">>Cordoba 10",
            ">Brasil 15",
            ">>SaoPaulo 20",
            ">>Fortaleza 25",
            "Asia 30",
            ">Japan 32",
            ">>Yokohama 35",
            ">>Tokio 40",
            ">Iran 42",
            ">>Teheran 45"
        ];
        private static readonly List<string> ar = [
            "1 Sudamerica.....................................1",
            "    1 Argentina..................................5",
            "        1 BuenosAires............................8",
            "        2 Cordoba...............................10",
            "    2 Brasil....................................15",
            "        1 SaoPaulo..............................20",
            "        2 Fortaleza.............................25",
            "2 Asia..........................................30",
            "    1 Japan.....................................32",
            "        1 Yokohama..............................35",
            "        2 Tokio.................................40",
            "    2 Iran......................................42",
            "        1 Teheran...............................45"
        ];

        public static IEnumerable<object[]> TableOfContents_Data =>
            new List<object[]>
            {
                new object[] { a0, 50, ar }
            };

        [Theory]
        [MemberData(nameof(TableOfContents_Data))]
        public void RftPartOne(List<string> input, int lengthofline, List<string> expected)
        {
            // Act
            List<string> actual = TableOfContents.RftSolve(input, lengthofline);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
