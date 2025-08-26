using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _01455_CheckIfAWordOccursAsAPrefixOfAnyWordInASentence_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_01455_CheckIfAWordOccursAsAPrefixOfAnyWordInASentence))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01455_CheckIfAWordOccursAsAPrefixOfAnyWordInASentence))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01455_CheckIfAWordOccursAsAPrefixOfAnyWordInASentence))![1]);

        public static TheoryData<List<string>, int> _01455_CheckIfAWordOccursAsAPrefixOfAnyWordInASentencePartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _01455_CheckIfAWordOccursAsAPrefixOfAnyWordInASentencePartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_01455_CheckIfAWordOccursAsAPrefixOfAnyWordInASentencePartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _01455_CheckIfAWordOccursAsAPrefixOfAnyWordInASentence.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01455_CheckIfAWordOccursAsAPrefixOfAnyWordInASentencePartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _01455_CheckIfAWordOccursAsAPrefixOfAnyWordInASentence.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
