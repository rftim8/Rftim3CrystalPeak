using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _01404_NumberOfStepsToReduceaNumberInBinaryRepresentationToOne_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_01404_NumberOfStepsToReduceaNumberInBinaryRepresentationToOne))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01404_NumberOfStepsToReduceaNumberInBinaryRepresentationToOne))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01404_NumberOfStepsToReduceaNumberInBinaryRepresentationToOne))![1]);

        public static TheoryData<List<string>, int> _01404_NumberOfStepsToReduceaNumberInBinaryRepresentationToOnePartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _01404_NumberOfStepsToReduceaNumberInBinaryRepresentationToOnePartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_01404_NumberOfStepsToReduceaNumberInBinaryRepresentationToOnePartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _01404_NumberOfStepsToReduceaNumberInBinaryRepresentationToOne.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01404_NumberOfStepsToReduceaNumberInBinaryRepresentationToOnePartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _01404_NumberOfStepsToReduceaNumberInBinaryRepresentationToOne.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
