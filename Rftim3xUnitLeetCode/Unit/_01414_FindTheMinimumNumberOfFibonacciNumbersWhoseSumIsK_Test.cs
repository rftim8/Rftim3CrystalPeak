using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _01414_FindTheMinimumNumberOfFibonacciNumbersWhoseSumIsK_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_01414_FindTheMinimumNumberOfFibonacciNumbersWhoseSumIsK))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01414_FindTheMinimumNumberOfFibonacciNumbersWhoseSumIsK))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01414_FindTheMinimumNumberOfFibonacciNumbersWhoseSumIsK))![1]);

        public static TheoryData<List<string>, int> _01414_FindTheMinimumNumberOfFibonacciNumbersWhoseSumIsKPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _01414_FindTheMinimumNumberOfFibonacciNumbersWhoseSumIsKPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_01414_FindTheMinimumNumberOfFibonacciNumbersWhoseSumIsKPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _01414_FindTheMinimumNumberOfFibonacciNumbersWhoseSumIsK.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01414_FindTheMinimumNumberOfFibonacciNumbersWhoseSumIsKPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _01414_FindTheMinimumNumberOfFibonacciNumbersWhoseSumIsK.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
