using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _02945_FindMaximumNonDecreasingArrayLength_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_02945_FindMaximumNonDecreasingArrayLength))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02945_FindMaximumNonDecreasingArrayLength))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02945_FindMaximumNonDecreasingArrayLength))![1]);

        public static TheoryData<List<string>, int> _02945_FindMaximumNonDecreasingArrayLengthPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _02945_FindMaximumNonDecreasingArrayLengthPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_02945_FindMaximumNonDecreasingArrayLengthPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _02945_FindMaximumNonDecreasingArrayLength.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02945_FindMaximumNonDecreasingArrayLengthPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _02945_FindMaximumNonDecreasingArrayLength.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
