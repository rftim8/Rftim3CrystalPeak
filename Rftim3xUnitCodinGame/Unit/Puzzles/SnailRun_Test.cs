using Rftim3CodinGame.Refactor.Puzzles;

namespace Rftim3xUnitCodinGame.Unit.Puzzles
{
    public class SnailRun_Test
    {
        // Arrange
        private static readonly string[] map = ["1****#", "2****#", "3****#"];
        private static readonly string[] map0 = ["1*****", "2****#", "**#***"];
        private static readonly string[] map1 = ["**3****", "****2**", "#*****1"];

        public static IEnumerable<object[]> SnailRun_Data =>
            new List<object[]>
            {
                new object[] { new Dictionary<int, int>() { { 1, 2 }, { 2, 3 }, { 3, 5 } }, map, 3 },
                new object[] { new Dictionary<int, int>() { { 1, 1 }, { 2, 1 } }, map0, 2 },
                new object[] { new Dictionary<int, int>() { { 1, 1 }, { 2, 1 }, { 3, 1 } }, map1, 3 }
            };

        [Theory]
        [MemberData(nameof(SnailRun_Data))]
        public void RftSolve(Dictionary<int, int> speeds, string[] map, int expected)
        {
            // Act
            int actual = SnailRun.RftSolve(speeds, map);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
