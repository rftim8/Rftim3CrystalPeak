using Rftim3CodinGame.Refactor.Puzzles;

namespace Rftim3xUnitCodinGame.Unit.Puzzles
{
    public class ASCIIArtTheDrunkenBishopAlgorithm_Test
    {
        // Arrange
        private static readonly List<string> ar = [
            "+---[CODINGAME]---+",
            "|       .=o.  .   |",
            "|     . *+*. o    |",
            "|      =.*..o     |",
            "|       o + ..    |",
            "|        S o.     |",
            "|         o  .    |",
            "|          .  . . |",
            "|              o .|",
            "|               E.|",
            "+-----------------+"
        ];

        public static IEnumerable<object[]> ASCIIArtTheDrunkenBishopAlgorithm_Data =>
            new List<object[]>
            {
                new object[] { "fc:94:b0:c1:e5:b0:98:7c:58:43:99:76:97:ee:9f:b7", ar }
            };

        [Theory]
        [MemberData(nameof(ASCIIArtTheDrunkenBishopAlgorithm_Data))]
        public void RftSolve(string a0, List<string> expected)
        {
            // Act
            List<string> actual = ASCIIArtTheDrunkenBishopAlgorithm.RftSolve(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
