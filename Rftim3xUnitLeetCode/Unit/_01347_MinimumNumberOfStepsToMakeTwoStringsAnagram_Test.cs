using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _01347_MinimumNumberOfStepsToMakeTwoStringsAnagram_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_01347_MinimumNumberOfStepsToMakeTwoStringsAnagram))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01347_MinimumNumberOfStepsToMakeTwoStringsAnagram))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01347_MinimumNumberOfStepsToMakeTwoStringsAnagram))![1]);

        public static TheoryData<List<string>, int> _01347_MinimumNumberOfStepsToMakeTwoStringsAnagramPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _01347_MinimumNumberOfStepsToMakeTwoStringsAnagramPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_01347_MinimumNumberOfStepsToMakeTwoStringsAnagramPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _01347_MinimumNumberOfStepsToMakeTwoStringsAnagram.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01347_MinimumNumberOfStepsToMakeTwoStringsAnagramPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _01347_MinimumNumberOfStepsToMakeTwoStringsAnagram.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
