using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _01744_CanYouEatYourFavoriteCandyOnYourFavoriteDay_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_01744_CanYouEatYourFavoriteCandyOnYourFavoriteDay))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01744_CanYouEatYourFavoriteCandyOnYourFavoriteDay))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01744_CanYouEatYourFavoriteCandyOnYourFavoriteDay))![1]);

        public static TheoryData<List<string>, int> _01744_CanYouEatYourFavoriteCandyOnYourFavoriteDayPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _01744_CanYouEatYourFavoriteCandyOnYourFavoriteDayPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_01744_CanYouEatYourFavoriteCandyOnYourFavoriteDayPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _01744_CanYouEatYourFavoriteCandyOnYourFavoriteDay.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01744_CanYouEatYourFavoriteCandyOnYourFavoriteDayPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _01744_CanYouEatYourFavoriteCandyOnYourFavoriteDay.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
