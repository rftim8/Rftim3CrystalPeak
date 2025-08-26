using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _02918_MinimumEqualSumOfTwoArraysAfterReplacingZeros_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_02918_MinimumEqualSumOfTwoArraysAfterReplacingZeros))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02918_MinimumEqualSumOfTwoArraysAfterReplacingZeros))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02918_MinimumEqualSumOfTwoArraysAfterReplacingZeros))![1]);

        public static TheoryData<List<string>, int> _02918_MinimumEqualSumOfTwoArraysAfterReplacingZerosPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _02918_MinimumEqualSumOfTwoArraysAfterReplacingZerosPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_02918_MinimumEqualSumOfTwoArraysAfterReplacingZerosPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _02918_MinimumEqualSumOfTwoArraysAfterReplacingZeros.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02918_MinimumEqualSumOfTwoArraysAfterReplacingZerosPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _02918_MinimumEqualSumOfTwoArraysAfterReplacingZeros.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
