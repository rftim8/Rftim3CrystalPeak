using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _02107_NumberOfUniqueFlavorsAfterSharingKCandies_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_02107_NumberOfUniqueFlavorsAfterSharingKCandies))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02107_NumberOfUniqueFlavorsAfterSharingKCandies))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02107_NumberOfUniqueFlavorsAfterSharingKCandies))![1]);

        public static TheoryData<List<string>, int> _02107_NumberOfUniqueFlavorsAfterSharingKCandiesPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _02107_NumberOfUniqueFlavorsAfterSharingKCandiesPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_02107_NumberOfUniqueFlavorsAfterSharingKCandiesPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _02107_NumberOfUniqueFlavorsAfterSharingKCandies.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02107_NumberOfUniqueFlavorsAfterSharingKCandiesPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _02107_NumberOfUniqueFlavorsAfterSharingKCandies.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
