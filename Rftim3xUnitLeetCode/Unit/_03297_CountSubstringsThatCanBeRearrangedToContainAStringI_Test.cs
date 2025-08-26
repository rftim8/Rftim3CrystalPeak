using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _03297_CountSubstringsThatCanBeRearrangedToContainAStringI_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_03297_CountSubstringsThatCanBeRearrangedToContainAStringI))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_03297_CountSubstringsThatCanBeRearrangedToContainAStringI))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_03297_CountSubstringsThatCanBeRearrangedToContainAStringI))![1]);

        public static TheoryData<List<string>, int> _03297_CountSubstringsThatCanBeRearrangedToContainAStringIPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _03297_CountSubstringsThatCanBeRearrangedToContainAStringIPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_03297_CountSubstringsThatCanBeRearrangedToContainAStringIPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _03297_CountSubstringsThatCanBeRearrangedToContainAStringI.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_03297_CountSubstringsThatCanBeRearrangedToContainAStringIPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _03297_CountSubstringsThatCanBeRearrangedToContainAStringI.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
