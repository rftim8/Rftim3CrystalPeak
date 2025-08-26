using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _02507_SmallestValueAfterReplacingWithSumOfPrimeFactors_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_02507_SmallestValueAfterReplacingWithSumOfPrimeFactors))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02507_SmallestValueAfterReplacingWithSumOfPrimeFactors))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02507_SmallestValueAfterReplacingWithSumOfPrimeFactors))![1]);

        public static TheoryData<List<string>, int> _02507_SmallestValueAfterReplacingWithSumOfPrimeFactorsPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _02507_SmallestValueAfterReplacingWithSumOfPrimeFactorsPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_02507_SmallestValueAfterReplacingWithSumOfPrimeFactorsPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _02507_SmallestValueAfterReplacingWithSumOfPrimeFactors.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02507_SmallestValueAfterReplacingWithSumOfPrimeFactorsPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _02507_SmallestValueAfterReplacingWithSumOfPrimeFactors.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
