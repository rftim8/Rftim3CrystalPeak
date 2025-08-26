using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _02177_FindThreeConsecutiveIntegersThatSumtoaGivenNumber_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_02177_FindThreeConsecutiveIntegersThatSumtoaGivenNumber))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02177_FindThreeConsecutiveIntegersThatSumtoaGivenNumber))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02177_FindThreeConsecutiveIntegersThatSumtoaGivenNumber))![1]);

        public static TheoryData<List<string>, int> _02177_FindThreeConsecutiveIntegersThatSumtoaGivenNumberPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _02177_FindThreeConsecutiveIntegersThatSumtoaGivenNumberPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_02177_FindThreeConsecutiveIntegersThatSumtoaGivenNumberPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _02177_FindThreeConsecutiveIntegersThatSumtoaGivenNumber.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02177_FindThreeConsecutiveIntegersThatSumtoaGivenNumberPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _02177_FindThreeConsecutiveIntegersThatSumtoaGivenNumber.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
