using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _01733_MinimumNumberOfPeopleToTeach_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_01733_MinimumNumberOfPeopleToTeach))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01733_MinimumNumberOfPeopleToTeach))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01733_MinimumNumberOfPeopleToTeach))![1]);

        public static TheoryData<List<string>, int> _01733_MinimumNumberOfPeopleToTeachPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _01733_MinimumNumberOfPeopleToTeachPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_01733_MinimumNumberOfPeopleToTeachPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _01733_MinimumNumberOfPeopleToTeach.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01733_MinimumNumberOfPeopleToTeachPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _01733_MinimumNumberOfPeopleToTeach.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
