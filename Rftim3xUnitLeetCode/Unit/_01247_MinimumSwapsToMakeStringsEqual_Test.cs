using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _01247_MinimumSwapsToMakeStringsEqual_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_01247_MinimumSwapsToMakeStringsEqual))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01247_MinimumSwapsToMakeStringsEqual))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01247_MinimumSwapsToMakeStringsEqual))![1]);

        public static TheoryData<List<string>, int> _01247_MinimumSwapsToMakeStringsEqualPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _01247_MinimumSwapsToMakeStringsEqualPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_01247_MinimumSwapsToMakeStringsEqualPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _01247_MinimumSwapsToMakeStringsEqual.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01247_MinimumSwapsToMakeStringsEqualPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _01247_MinimumSwapsToMakeStringsEqual.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
