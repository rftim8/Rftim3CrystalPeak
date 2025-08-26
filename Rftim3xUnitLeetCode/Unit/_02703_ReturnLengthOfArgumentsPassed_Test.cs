using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _02703_ReturnLengthOfArgumentsPassed_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_02703_ReturnLengthOfArgumentsPassed))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02703_ReturnLengthOfArgumentsPassed))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02703_ReturnLengthOfArgumentsPassed))![1]);

        public static TheoryData<List<string>, int> _02703_ReturnLengthOfArgumentsPassedPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _02703_ReturnLengthOfArgumentsPassedPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_02703_ReturnLengthOfArgumentsPassedPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _02703_ReturnLengthOfArgumentsPassed.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02703_ReturnLengthOfArgumentsPassedPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _02703_ReturnLengthOfArgumentsPassed.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
