using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _01558_MinimumNumbersOfFunctionCallsToMakeTargetArray_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_01558_MinimumNumbersOfFunctionCallsToMakeTargetArray))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01558_MinimumNumbersOfFunctionCallsToMakeTargetArray))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01558_MinimumNumbersOfFunctionCallsToMakeTargetArray))![1]);

        public static TheoryData<List<string>, int> _01558_MinimumNumbersOfFunctionCallsToMakeTargetArrayPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _01558_MinimumNumbersOfFunctionCallsToMakeTargetArrayPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_01558_MinimumNumbersOfFunctionCallsToMakeTargetArrayPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _01558_MinimumNumbersOfFunctionCallsToMakeTargetArray.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01558_MinimumNumbersOfFunctionCallsToMakeTargetArrayPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _01558_MinimumNumbersOfFunctionCallsToMakeTargetArray.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
