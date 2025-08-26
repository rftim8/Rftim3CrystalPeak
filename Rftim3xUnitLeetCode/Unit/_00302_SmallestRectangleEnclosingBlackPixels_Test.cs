using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _00302_SmallestRectangleEnclosingBlackPixels_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_00302_SmallestRectangleEnclosingBlackPixels))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_00302_SmallestRectangleEnclosingBlackPixels))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_00302_SmallestRectangleEnclosingBlackPixels))![1]);

        public static TheoryData<List<string>, int> _00302_SmallestRectangleEnclosingBlackPixelsPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _00302_SmallestRectangleEnclosingBlackPixelsPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_00302_SmallestRectangleEnclosingBlackPixelsPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _00302_SmallestRectangleEnclosingBlackPixels.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00302_SmallestRectangleEnclosingBlackPixelsPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _00302_SmallestRectangleEnclosingBlackPixels.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
