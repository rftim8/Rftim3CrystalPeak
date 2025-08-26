using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _03202_FindTheMaximumLengthOfValidSubsequenceII_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_03202_FindTheMaximumLengthOfValidSubsequenceII))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_03202_FindTheMaximumLengthOfValidSubsequenceII))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_03202_FindTheMaximumLengthOfValidSubsequenceII))![1]);

        public static TheoryData<List<string>, int> _03202_FindTheMaximumLengthOfValidSubsequenceIIPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _03202_FindTheMaximumLengthOfValidSubsequenceIIPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_03202_FindTheMaximumLengthOfValidSubsequenceIIPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _03202_FindTheMaximumLengthOfValidSubsequenceII.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_03202_FindTheMaximumLengthOfValidSubsequenceIIPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _03202_FindTheMaximumLengthOfValidSubsequenceII.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
