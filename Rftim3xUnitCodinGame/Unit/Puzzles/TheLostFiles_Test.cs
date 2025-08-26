using Rftim3CodinGame.Refactor.Puzzles;

namespace Rftim3xUnitCodinGame.Unit.Puzzles
{
    public class TheLostFiles_Test
    {
        // Arrange
        private static readonly int a0 = 13;
        private static readonly List<string> a1 =
            [
                "4 10",
                "7 2",
                "2 1",
                "4 1",
                "8 10",
                "3 9",
                "6 3",
                "8 0",
                "7 4",
                "5 10",
                "9 6",
                "7 0",
                "8 5"
            ];
        private static readonly string ar = "2 4";

        public static TheoryData<int, List<string>, string> TheLostFiles_Data =>
            new()
            {
                { a0, a1, ar }
            };

        [Theory(Skip = "WIP")]
        [MemberData(nameof(TheLostFiles_Data))]
        public void TheLostFiles0(int a0, List<string> a1, string expected)
        {
            // Act
            string actual = TheLostFiles.TheLostFiles0(a0, a1);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
