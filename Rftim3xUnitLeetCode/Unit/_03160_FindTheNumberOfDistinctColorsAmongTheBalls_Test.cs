using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _03160_FindTheNumberOfDistinctColorsAmongTheBalls_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_03160_FindTheNumberOfDistinctColorsAmongTheBalls))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_03160_FindTheNumberOfDistinctColorsAmongTheBalls))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_03160_FindTheNumberOfDistinctColorsAmongTheBalls))![1]);

        public static TheoryData<List<string>, int> _03160_FindTheNumberOfDistinctColorsAmongTheBallsPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _03160_FindTheNumberOfDistinctColorsAmongTheBallsPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_03160_FindTheNumberOfDistinctColorsAmongTheBallsPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _03160_FindTheNumberOfDistinctColorsAmongTheBalls.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_03160_FindTheNumberOfDistinctColorsAmongTheBallsPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _03160_FindTheNumberOfDistinctColorsAmongTheBalls.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
