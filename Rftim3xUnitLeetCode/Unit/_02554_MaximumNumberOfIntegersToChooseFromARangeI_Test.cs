using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _02554_MaximumNumberOfIntegersToChooseFromARangeI_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_02554_MaximumNumberOfIntegersToChooseFromARangeI))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02554_MaximumNumberOfIntegersToChooseFromARangeI))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02554_MaximumNumberOfIntegersToChooseFromARangeI))![1]);

        public static TheoryData<List<string>, int> _02554_MaximumNumberOfIntegersToChooseFromARangeIPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _02554_MaximumNumberOfIntegersToChooseFromARangeIPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_02554_MaximumNumberOfIntegersToChooseFromARangeIPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _02554_MaximumNumberOfIntegersToChooseFromARangeI.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02554_MaximumNumberOfIntegersToChooseFromARangeIPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _02554_MaximumNumberOfIntegersToChooseFromARangeI.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
