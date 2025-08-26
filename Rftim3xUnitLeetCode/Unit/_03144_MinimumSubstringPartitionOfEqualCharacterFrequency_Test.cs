using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _03144_MinimumSubstringPartitionOfEqualCharacterFrequency_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_03144_MinimumSubstringPartitionOfEqualCharacterFrequency))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_03144_MinimumSubstringPartitionOfEqualCharacterFrequency))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_03144_MinimumSubstringPartitionOfEqualCharacterFrequency))![1]);

        public static TheoryData<List<string>, int> _03144_MinimumSubstringPartitionOfEqualCharacterFrequencyPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _03144_MinimumSubstringPartitionOfEqualCharacterFrequencyPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_03144_MinimumSubstringPartitionOfEqualCharacterFrequencyPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _03144_MinimumSubstringPartitionOfEqualCharacterFrequency.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_03144_MinimumSubstringPartitionOfEqualCharacterFrequencyPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _03144_MinimumSubstringPartitionOfEqualCharacterFrequency.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
