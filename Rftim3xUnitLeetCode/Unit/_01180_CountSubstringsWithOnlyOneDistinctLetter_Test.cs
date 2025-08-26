using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _01180_CountSubstringsWithOnlyOneDistinctLetter_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_01180_CountSubstringsWithOnlyOneDistinctLetter))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01180_CountSubstringsWithOnlyOneDistinctLetter))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01180_CountSubstringsWithOnlyOneDistinctLetter))![1]);

        public static TheoryData<List<string>, int> _01180_CountSubstringsWithOnlyOneDistinctLetterPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _01180_CountSubstringsWithOnlyOneDistinctLetterPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_01180_CountSubstringsWithOnlyOneDistinctLetterPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _01180_CountSubstringsWithOnlyOneDistinctLetter.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01180_CountSubstringsWithOnlyOneDistinctLetterPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _01180_CountSubstringsWithOnlyOneDistinctLetter.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
