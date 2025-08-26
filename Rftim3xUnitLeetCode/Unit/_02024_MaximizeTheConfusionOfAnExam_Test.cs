using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _02024_MaximizeTheConfusionOfAnExam_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_02024_MaximizeTheConfusionOfAnExam))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02024_MaximizeTheConfusionOfAnExam))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02024_MaximizeTheConfusionOfAnExam))![1]);

        public static TheoryData<List<string>, int> _02024_MaximizeTheConfusionOfAnExamPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _02024_MaximizeTheConfusionOfAnExamPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_02024_MaximizeTheConfusionOfAnExamPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _02024_MaximizeTheConfusionOfAnExam.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02024_MaximizeTheConfusionOfAnExamPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _02024_MaximizeTheConfusionOfAnExam.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
