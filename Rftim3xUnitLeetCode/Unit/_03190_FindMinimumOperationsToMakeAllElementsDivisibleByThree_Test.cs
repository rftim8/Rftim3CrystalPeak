using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _03190_FindMinimumOperationsToMakeAllElementsDivisibleByThree_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_03190_FindMinimumOperationsToMakeAllElementsDivisibleByThree))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_03190_FindMinimumOperationsToMakeAllElementsDivisibleByThree))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_03190_FindMinimumOperationsToMakeAllElementsDivisibleByThree))![1]);

        public static TheoryData<List<string>, int> _03190_FindMinimumOperationsToMakeAllElementsDivisibleByThreePartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _03190_FindMinimumOperationsToMakeAllElementsDivisibleByThreePartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_03190_FindMinimumOperationsToMakeAllElementsDivisibleByThreePartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _03190_FindMinimumOperationsToMakeAllElementsDivisibleByThree.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_03190_FindMinimumOperationsToMakeAllElementsDivisibleByThreePartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _03190_FindMinimumOperationsToMakeAllElementsDivisibleByThree.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
