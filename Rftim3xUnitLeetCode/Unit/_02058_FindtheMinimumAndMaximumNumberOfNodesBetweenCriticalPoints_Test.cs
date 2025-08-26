using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _02058_FindtheMinimumAndMaximumNumberOfNodesBetweenCriticalPoints_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_02058_FindtheMinimumAndMaximumNumberOfNodesBetweenCriticalPoints))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02058_FindtheMinimumAndMaximumNumberOfNodesBetweenCriticalPoints))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02058_FindtheMinimumAndMaximumNumberOfNodesBetweenCriticalPoints))![1]);

        public static TheoryData<List<string>, int> _02058_FindtheMinimumAndMaximumNumberOfNodesBetweenCriticalPointsPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _02058_FindtheMinimumAndMaximumNumberOfNodesBetweenCriticalPointsPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_02058_FindtheMinimumAndMaximumNumberOfNodesBetweenCriticalPointsPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _02058_FindtheMinimumAndMaximumNumberOfNodesBetweenCriticalPoints.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02058_FindtheMinimumAndMaximumNumberOfNodesBetweenCriticalPointsPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _02058_FindtheMinimumAndMaximumNumberOfNodesBetweenCriticalPoints.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
