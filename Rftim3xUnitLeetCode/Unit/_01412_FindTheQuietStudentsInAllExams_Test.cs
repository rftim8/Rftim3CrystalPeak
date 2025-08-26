using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _01412_FindTheQuietStudentsInAllExams_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_01412_FindTheQuietStudentsInAllExams))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01412_FindTheQuietStudentsInAllExams))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01412_FindTheQuietStudentsInAllExams))![1]);

        public static TheoryData<List<string>, int> _01412_FindTheQuietStudentsInAllExamsPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _01412_FindTheQuietStudentsInAllExamsPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_01412_FindTheQuietStudentsInAllExamsPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _01412_FindTheQuietStudentsInAllExams.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01412_FindTheQuietStudentsInAllExamsPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _01412_FindTheQuietStudentsInAllExams.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
