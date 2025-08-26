using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _01689_PartitioningIntoMinimumNumberOfDeciBinaryNumbers_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_01689_PartitioningIntoMinimumNumberOfDeciBinaryNumbers))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01689_PartitioningIntoMinimumNumberOfDeciBinaryNumbers))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01689_PartitioningIntoMinimumNumberOfDeciBinaryNumbers))![1]);

        public static TheoryData<List<string>, int> _01689_PartitioningIntoMinimumNumberOfDeciBinaryNumbersPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _01689_PartitioningIntoMinimumNumberOfDeciBinaryNumbersPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_01689_PartitioningIntoMinimumNumberOfDeciBinaryNumbersPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _01689_PartitioningIntoMinimumNumberOfDeciBinaryNumbers.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01689_PartitioningIntoMinimumNumberOfDeciBinaryNumbersPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _01689_PartitioningIntoMinimumNumberOfDeciBinaryNumbers.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
