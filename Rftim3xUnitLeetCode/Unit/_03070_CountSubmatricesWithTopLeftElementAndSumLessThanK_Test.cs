using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _03070_CountSubmatricesWithTopLeftElementAndSumLessThanK_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_03070_CountSubmatricesWithTopLeftElementAndSumLessThanK))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_03070_CountSubmatricesWithTopLeftElementAndSumLessThanK))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_03070_CountSubmatricesWithTopLeftElementAndSumLessThanK))![1]);

        public static TheoryData<List<string>, int> _03070_CountSubmatricesWithTopLeftElementAndSumLessThanKPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _03070_CountSubmatricesWithTopLeftElementAndSumLessThanKPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_03070_CountSubmatricesWithTopLeftElementAndSumLessThanKPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _03070_CountSubmatricesWithTopLeftElementAndSumLessThanK.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_03070_CountSubmatricesWithTopLeftElementAndSumLessThanKPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _03070_CountSubmatricesWithTopLeftElementAndSumLessThanK.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
