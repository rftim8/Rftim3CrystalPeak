using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _01151_MinimumSwapsToGroupAll1sTogether_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_01151_MinimumSwapsToGroupAll1sTogether))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01151_MinimumSwapsToGroupAll1sTogether))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01151_MinimumSwapsToGroupAll1sTogether))![1]);

        public static TheoryData<List<string>, int> _01151_MinimumSwapsToGroupAll1sTogetherPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _01151_MinimumSwapsToGroupAll1sTogetherPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_01151_MinimumSwapsToGroupAll1sTogetherPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _01151_MinimumSwapsToGroupAll1sTogether.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01151_MinimumSwapsToGroupAll1sTogetherPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _01151_MinimumSwapsToGroupAll1sTogether.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
