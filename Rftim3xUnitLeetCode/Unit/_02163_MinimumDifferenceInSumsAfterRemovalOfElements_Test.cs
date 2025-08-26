using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _02163_MinimumDifferenceInSumsAfterRemovalOfElements_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_02163_MinimumDifferenceInSumsAfterRemovalOfElements))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02163_MinimumDifferenceInSumsAfterRemovalOfElements))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02163_MinimumDifferenceInSumsAfterRemovalOfElements))![1]);

        public static TheoryData<List<string>, int> _02163_MinimumDifferenceInSumsAfterRemovalOfElementsPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _02163_MinimumDifferenceInSumsAfterRemovalOfElementsPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_02163_MinimumDifferenceInSumsAfterRemovalOfElementsPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _02163_MinimumDifferenceInSumsAfterRemovalOfElements.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02163_MinimumDifferenceInSumsAfterRemovalOfElementsPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _02163_MinimumDifferenceInSumsAfterRemovalOfElements.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
