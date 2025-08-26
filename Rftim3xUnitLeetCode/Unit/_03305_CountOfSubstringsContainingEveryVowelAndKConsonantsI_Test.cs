using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _03305_CountOfSubstringsContainingEveryVowelAndKConsonantsI_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_03305_CountOfSubstringsContainingEveryVowelAndKConsonantsI))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_03305_CountOfSubstringsContainingEveryVowelAndKConsonantsI))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_03305_CountOfSubstringsContainingEveryVowelAndKConsonantsI))![1]);

        public static TheoryData<List<string>, int> _03305_CountOfSubstringsContainingEveryVowelAndKConsonantsIPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _03305_CountOfSubstringsContainingEveryVowelAndKConsonantsIPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_03305_CountOfSubstringsContainingEveryVowelAndKConsonantsIPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _03305_CountOfSubstringsContainingEveryVowelAndKConsonantsI.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_03305_CountOfSubstringsContainingEveryVowelAndKConsonantsIPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _03305_CountOfSubstringsContainingEveryVowelAndKConsonantsI.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
