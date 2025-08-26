using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _02372_CalculateTheInfluenceOfEachSalesperson_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_02372_CalculateTheInfluenceOfEachSalesperson))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02372_CalculateTheInfluenceOfEachSalesperson))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02372_CalculateTheInfluenceOfEachSalesperson))![1]);

        public static TheoryData<List<string>, int> _02372_CalculateTheInfluenceOfEachSalespersonPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _02372_CalculateTheInfluenceOfEachSalespersonPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_02372_CalculateTheInfluenceOfEachSalespersonPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _02372_CalculateTheInfluenceOfEachSalesperson.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02372_CalculateTheInfluenceOfEachSalespersonPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _02372_CalculateTheInfluenceOfEachSalesperson.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
