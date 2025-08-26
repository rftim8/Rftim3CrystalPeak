using Rftim3CodinGame.Refactor.Puzzles;

namespace Rftim3xUnitCodinGame.Unit.Puzzles
{
    public class GravityTumbler_Test
    {
        // Arrange
        private static readonly int a0 = 17, a1 = 5, a2 = 1;
        private static readonly List<string> a3 =
            [
                ".................",
                ".................",
                "...##...###..#...",
                ".####..#####.###.",
                "#################"
            ];
        private static readonly List<string> ar =
            [
                "....#",
                "....#",
                "....#",
                "....#",
                "....#",
                "...##",
                "...##",
                "...##",
                "...##",
                "...##",
                "...##",
                "..###",
                "..###",
                "..###",
                "..###",
                "..###",
                "..###"
            ];

        public static TheoryData<int, int, int, List<string>, List<string>> GravityTumbler_Data =>
            new()
            {
                { a0, a1, a2, a3, ar },
            };

        [Theory]
        [MemberData(nameof(GravityTumbler_Data))]
        public void GravityTumbler0(int a0, int a1, int a2, List<string> a3, List<string> expected)
        {
            // Act
            List<string> actual = GravityTumbler.GravityTumbler0(a0, a1, a2, a3);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
