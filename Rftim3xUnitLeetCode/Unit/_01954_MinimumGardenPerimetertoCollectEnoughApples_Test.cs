using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _01954_MinimumGardenPerimetertoCollectEnoughApples_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_01954_MinimumGardenPerimetertoCollectEnoughApples))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01954_MinimumGardenPerimetertoCollectEnoughApples))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01954_MinimumGardenPerimetertoCollectEnoughApples))![1]);

        public static TheoryData<List<string>, int> _01954_MinimumGardenPerimetertoCollectEnoughApplesPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _01954_MinimumGardenPerimetertoCollectEnoughApplesPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_01954_MinimumGardenPerimetertoCollectEnoughApplesPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _01954_MinimumGardenPerimetertoCollectEnoughApples.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01954_MinimumGardenPerimetertoCollectEnoughApplesPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _01954_MinimumGardenPerimetertoCollectEnoughApples.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
