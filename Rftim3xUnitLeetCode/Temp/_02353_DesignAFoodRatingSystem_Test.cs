using Rftim3LeetCode.Temp;
using static Rftim3LeetCode.Temp._02353_DesignAFoodRatingSystem;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _02353_DesignAFoodRatingSystem_Test
    {
        // Arrange
        private static readonly string[] a0 = ["FoodRatings", "highestRated", "highestRated", "changeRating", "highestRated", "changeRating", "highestRated"];
        private static readonly Foods a1 = new(
                ["kimchi", "miso", "sushi", "moussaka", "ramen", "bulgogi"],
                ["korean", "japanese", "japanese", "greek", "japanese", "korean"],
                [9, 12, 8, 15, 14, 7]
            );
        private static readonly Rating[] a2 =
            [
                new("korean", -1),
                new("japanese", -1),
                new("sushi", 16),
                new("japanese", -1),
                new("ramen", 16),
                new("japanese", -1)
            ];
        private static readonly string[] ar = ["null", "kimchi", "ramen", "null", "sushi", "null", "ramen"];

        public static TheoryData<string[], Foods, Rating[], string[]> _02353_DesignAFoodRatingSystem_Data =>
            new()
            {
                { a0, a1, a2, ar }
            };

        [Theory]
        [MemberData(nameof(_02353_DesignAFoodRatingSystem_Data))]
        public void DesignAFoodRatingSystem0(string[] a0, Foods a1, Rating[] a2, string[] expected)
        {
            // Act
            string[] actual = _02353_DesignAFoodRatingSystem.DesignAFoodRatingSystem0(a0, a1, a2);

            // Assert
            Assert.Equivalent(expected, actual, true);
        }
    }
}
