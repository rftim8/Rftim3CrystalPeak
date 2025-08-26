using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _00944_DeleteColumnsToMakeSorted_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_00944_DeleteColumnsToMakeSorted))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_00944_DeleteColumnsToMakeSorted))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_00944_DeleteColumnsToMakeSorted))![1]);

        public static TheoryData<List<string>, int> _00944_DeleteColumnsToMakeSortedPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _00944_DeleteColumnsToMakeSortedPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_00944_DeleteColumnsToMakeSortedPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _00944_DeleteColumnsToMakeSorted.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00944_DeleteColumnsToMakeSortedPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _00944_DeleteColumnsToMakeSorted.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
