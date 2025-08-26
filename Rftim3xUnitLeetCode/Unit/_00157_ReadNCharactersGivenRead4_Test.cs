using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _00157_ReadNCharactersGivenRead4_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_00157_ReadNCharactersGivenRead4))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_00157_ReadNCharactersGivenRead4))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_00157_ReadNCharactersGivenRead4))![1]);

        public static TheoryData<List<string>, int> _00157_ReadNCharactersGivenRead4PartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _00157_ReadNCharactersGivenRead4PartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_00157_ReadNCharactersGivenRead4PartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _00157_ReadNCharactersGivenRead4.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00157_ReadNCharactersGivenRead4PartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _00157_ReadNCharactersGivenRead4.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
