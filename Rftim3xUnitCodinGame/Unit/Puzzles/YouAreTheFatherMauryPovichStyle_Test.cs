using Rftim3CodinGame.Refactor.Puzzles;

namespace Rftim3xUnitCodinGame.Unit.Puzzles
{
    public class YouAreTheFatherMauryPovichStyle_Test
    {
        // Arrange
        private static readonly List<string> a0 = [
            "Garrett:             #; wc",
            "Macallister:         P2 zv",
            "Jeffrey:             KI J&",
            "Scott:               WW :=",
            "Angus:               Xm N1"
        ];

        public static TheoryData<string, string, List<string>, string> YouAreTheFatherMauryPovichStyle_Data =>
            new()
            {
                { "Mother Julie:        Uj $7", "Child Brandon:       Wj =$", a0, "Scott, you are the father!" }
            };

        [Theory]
        [MemberData(nameof(YouAreTheFatherMauryPovichStyle_Data))]
        public void RftSolve(string mother, string child, List<string> fathers, string expected)
        {
            // Act
            string actual = YouAreTheFatherMauryPovichStyle.RftSolve(mother, child, fathers);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
