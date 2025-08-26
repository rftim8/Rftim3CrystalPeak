using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _00158_ReadNCharactersGivenRead4IICallMultipleTimes_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_00158_ReadNCharactersGivenRead4IICallMultipleTimes))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_00158_ReadNCharactersGivenRead4IICallMultipleTimes))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_00158_ReadNCharactersGivenRead4IICallMultipleTimes))![1]);

        public static TheoryData<List<string>, int> _00158_ReadNCharactersGivenRead4IICallMultipleTimesPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _00158_ReadNCharactersGivenRead4IICallMultipleTimesPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_00158_ReadNCharactersGivenRead4IICallMultipleTimesPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _00158_ReadNCharactersGivenRead4IICallMultipleTimes.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00158_ReadNCharactersGivenRead4IICallMultipleTimesPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _00158_ReadNCharactersGivenRead4IICallMultipleTimes.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
