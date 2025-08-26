using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _02734_LexicographicallySmallestStringAfterSubstringOperation_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_02734_LexicographicallySmallestStringAfterSubstringOperation))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02734_LexicographicallySmallestStringAfterSubstringOperation))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02734_LexicographicallySmallestStringAfterSubstringOperation))![1]);

        public static TheoryData<List<string>, int> _02734_LexicographicallySmallestStringAfterSubstringOperationPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _02734_LexicographicallySmallestStringAfterSubstringOperationPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_02734_LexicographicallySmallestStringAfterSubstringOperationPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _02734_LexicographicallySmallestStringAfterSubstringOperation.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02734_LexicographicallySmallestStringAfterSubstringOperationPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _02734_LexicographicallySmallestStringAfterSubstringOperation.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
