using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _03085_MinimumDeletionsToMakeStringKSpecial_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_03085_MinimumDeletionsToMakeStringKSpecial))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_03085_MinimumDeletionsToMakeStringKSpecial))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_03085_MinimumDeletionsToMakeStringKSpecial))![1]);

        public static TheoryData<List<string>, int> _03085_MinimumDeletionsToMakeStringKSpecialPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _03085_MinimumDeletionsToMakeStringKSpecialPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_03085_MinimumDeletionsToMakeStringKSpecialPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _03085_MinimumDeletionsToMakeStringKSpecial.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_03085_MinimumDeletionsToMakeStringKSpecialPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _03085_MinimumDeletionsToMakeStringKSpecial.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
