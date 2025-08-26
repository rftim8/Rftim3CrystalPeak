using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _03083_ExistenceOfASubstringInAStringAndItsReverse_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_03083_ExistenceOfASubstringInAStringAndItsReverse))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_03083_ExistenceOfASubstringInAStringAndItsReverse))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_03083_ExistenceOfASubstringInAStringAndItsReverse))![1]);

        public static TheoryData<List<string>, int> _03083_ExistenceOfASubstringInAStringAndItsReversePartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _03083_ExistenceOfASubstringInAStringAndItsReversePartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_03083_ExistenceOfASubstringInAStringAndItsReversePartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _03083_ExistenceOfASubstringInAStringAndItsReverse.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_03083_ExistenceOfASubstringInAStringAndItsReversePartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _03083_ExistenceOfASubstringInAStringAndItsReverse.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
