using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _01815_MaximumNumberOfGroupsGettingFreshDonuts_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_01815_MaximumNumberOfGroupsGettingFreshDonuts))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01815_MaximumNumberOfGroupsGettingFreshDonuts))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01815_MaximumNumberOfGroupsGettingFreshDonuts))![1]);

        public static TheoryData<List<string>, int> _01815_MaximumNumberOfGroupsGettingFreshDonutsPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _01815_MaximumNumberOfGroupsGettingFreshDonutsPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_01815_MaximumNumberOfGroupsGettingFreshDonutsPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _01815_MaximumNumberOfGroupsGettingFreshDonuts.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01815_MaximumNumberOfGroupsGettingFreshDonutsPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _01815_MaximumNumberOfGroupsGettingFreshDonuts.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
