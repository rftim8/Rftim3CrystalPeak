using Rftim3CodinGame.Refactor.Puzzles;

namespace Rftim3xUnitCodinGame.Unit.Puzzles
{
    public class AContributionByMinhtan143_Test
    {
        // Arrange
        private static readonly List<int> a0 = [1, 8, 6, 2, 5, 4, 8, 3, 7];

        public static IEnumerable<object[]> AContributionByMinhtan143_Data =>
            new List<object[]>
            {
                new object[] { a0, 49 }
            };

        [Theory]
        [MemberData(nameof(AContributionByMinhtan143_Data))]
        public void RftSolve(List<int> a0, int expected)
        {
            // Act
            int actual = AContributionByMinhtan143.RftSolve(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
