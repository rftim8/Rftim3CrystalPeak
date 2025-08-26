using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _01864_MinimumNumberOfSwapsToMakeTheBinaryStringAlternating_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_01864_MinimumNumberOfSwapsToMakeTheBinaryStringAlternating))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01864_MinimumNumberOfSwapsToMakeTheBinaryStringAlternating))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01864_MinimumNumberOfSwapsToMakeTheBinaryStringAlternating))![1]);

        public static TheoryData<List<string>, int> _01864_MinimumNumberOfSwapsToMakeTheBinaryStringAlternatingPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _01864_MinimumNumberOfSwapsToMakeTheBinaryStringAlternatingPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_01864_MinimumNumberOfSwapsToMakeTheBinaryStringAlternatingPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _01864_MinimumNumberOfSwapsToMakeTheBinaryStringAlternating.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01864_MinimumNumberOfSwapsToMakeTheBinaryStringAlternatingPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _01864_MinimumNumberOfSwapsToMakeTheBinaryStringAlternating.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
