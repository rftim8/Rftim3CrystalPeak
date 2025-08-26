using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _03192_MinimumOperationsToMakeBinaryArrayElementsEqualToOneII_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_03192_MinimumOperationsToMakeBinaryArrayElementsEqualToOneII))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_03192_MinimumOperationsToMakeBinaryArrayElementsEqualToOneII))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_03192_MinimumOperationsToMakeBinaryArrayElementsEqualToOneII))![1]);

        public static TheoryData<List<string>, int> _03192_MinimumOperationsToMakeBinaryArrayElementsEqualToOneIIPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _03192_MinimumOperationsToMakeBinaryArrayElementsEqualToOneIIPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_03192_MinimumOperationsToMakeBinaryArrayElementsEqualToOneIIPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _03192_MinimumOperationsToMakeBinaryArrayElementsEqualToOneII.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_03192_MinimumOperationsToMakeBinaryArrayElementsEqualToOneIIPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _03192_MinimumOperationsToMakeBinaryArrayElementsEqualToOneII.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
