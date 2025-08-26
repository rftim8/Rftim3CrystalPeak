using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _02136_EarliestPossibleDayOfFullBloom_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_02136_EarliestPossibleDayOfFullBloom))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02136_EarliestPossibleDayOfFullBloom))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02136_EarliestPossibleDayOfFullBloom))![1]);

        public static TheoryData<List<string>, int> _02136_EarliestPossibleDayOfFullBloomPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _02136_EarliestPossibleDayOfFullBloomPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_02136_EarliestPossibleDayOfFullBloomPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _02136_EarliestPossibleDayOfFullBloom.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02136_EarliestPossibleDayOfFullBloomPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _02136_EarliestPossibleDayOfFullBloom.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
