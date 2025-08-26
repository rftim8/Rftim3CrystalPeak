using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _01420_BuildArrayWhereYouCanFindTheMaximumExactlyKComparisons_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_01420_BuildArrayWhereYouCanFindTheMaximumExactlyKComparisons))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01420_BuildArrayWhereYouCanFindTheMaximumExactlyKComparisons))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01420_BuildArrayWhereYouCanFindTheMaximumExactlyKComparisons))![1]);

        public static TheoryData<List<string>, int> _01420_BuildArrayWhereYouCanFindTheMaximumExactlyKComparisonsPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _01420_BuildArrayWhereYouCanFindTheMaximumExactlyKComparisonsPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_01420_BuildArrayWhereYouCanFindTheMaximumExactlyKComparisonsPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _01420_BuildArrayWhereYouCanFindTheMaximumExactlyKComparisons.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01420_BuildArrayWhereYouCanFindTheMaximumExactlyKComparisonsPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _01420_BuildArrayWhereYouCanFindTheMaximumExactlyKComparisons.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
