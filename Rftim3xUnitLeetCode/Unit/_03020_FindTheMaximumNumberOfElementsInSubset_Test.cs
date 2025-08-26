using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _03020_FindTheMaximumNumberOfElementsInSubset_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_03020_FindTheMaximumNumberOfElementsInSubset))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_03020_FindTheMaximumNumberOfElementsInSubset))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_03020_FindTheMaximumNumberOfElementsInSubset))![1]);

        public static TheoryData<List<string>, int> _03020_FindTheMaximumNumberOfElementsInSubsetPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _03020_FindTheMaximumNumberOfElementsInSubsetPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_03020_FindTheMaximumNumberOfElementsInSubsetPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _03020_FindTheMaximumNumberOfElementsInSubset.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_03020_FindTheMaximumNumberOfElementsInSubsetPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _03020_FindTheMaximumNumberOfElementsInSubset.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
