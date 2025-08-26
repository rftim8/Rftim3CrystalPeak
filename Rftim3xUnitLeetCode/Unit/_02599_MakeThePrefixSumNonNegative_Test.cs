using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _02599_MakeThePrefixSumNonNegative_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_02599_MakeThePrefixSumNonNegative))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02599_MakeThePrefixSumNonNegative))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02599_MakeThePrefixSumNonNegative))![1]);

        public static TheoryData<List<string>, int> _02599_MakeThePrefixSumNonNegativePartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _02599_MakeThePrefixSumNonNegativePartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_02599_MakeThePrefixSumNonNegativePartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _02599_MakeThePrefixSumNonNegative.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02599_MakeThePrefixSumNonNegativePartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _02599_MakeThePrefixSumNonNegative.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
