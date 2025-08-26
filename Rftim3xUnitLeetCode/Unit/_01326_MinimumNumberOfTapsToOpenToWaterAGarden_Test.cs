using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _01326_MinimumNumberOfTapsToOpenToWaterAGarden_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_01326_MinimumNumberOfTapsToOpenToWaterAGarden))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01326_MinimumNumberOfTapsToOpenToWaterAGarden))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01326_MinimumNumberOfTapsToOpenToWaterAGarden))![1]);

        public static TheoryData<List<string>, int> _01326_MinimumNumberOfTapsToOpenToWaterAGardenPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _01326_MinimumNumberOfTapsToOpenToWaterAGardenPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_01326_MinimumNumberOfTapsToOpenToWaterAGardenPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _01326_MinimumNumberOfTapsToOpenToWaterAGarden.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01326_MinimumNumberOfTapsToOpenToWaterAGardenPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _01326_MinimumNumberOfTapsToOpenToWaterAGarden.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
