using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _01378_ReplaceEmployeeIDWithTheUniqueIdentifier_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_01378_ReplaceEmployeeIDWithTheUniqueIdentifier))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01378_ReplaceEmployeeIDWithTheUniqueIdentifier))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01378_ReplaceEmployeeIDWithTheUniqueIdentifier))![1]);

        public static TheoryData<List<string>, int> _01378_ReplaceEmployeeIDWithTheUniqueIdentifierPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _01378_ReplaceEmployeeIDWithTheUniqueIdentifierPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_01378_ReplaceEmployeeIDWithTheUniqueIdentifierPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _01378_ReplaceEmployeeIDWithTheUniqueIdentifier.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01378_ReplaceEmployeeIDWithTheUniqueIdentifierPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _01378_ReplaceEmployeeIDWithTheUniqueIdentifier.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
