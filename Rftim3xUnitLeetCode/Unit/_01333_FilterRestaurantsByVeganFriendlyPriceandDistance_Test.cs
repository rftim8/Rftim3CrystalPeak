using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _01333_FilterRestaurantsByVeganFriendlyPriceandDistance_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_01333_FilterRestaurantsByVeganFriendlyPriceandDistance))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01333_FilterRestaurantsByVeganFriendlyPriceandDistance))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01333_FilterRestaurantsByVeganFriendlyPriceandDistance))![1]);

        public static TheoryData<List<string>, int> _01333_FilterRestaurantsByVeganFriendlyPriceandDistancePartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _01333_FilterRestaurantsByVeganFriendlyPriceandDistancePartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_01333_FilterRestaurantsByVeganFriendlyPriceandDistancePartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _01333_FilterRestaurantsByVeganFriendlyPriceandDistance.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01333_FilterRestaurantsByVeganFriendlyPriceandDistancePartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _01333_FilterRestaurantsByVeganFriendlyPriceandDistance.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
