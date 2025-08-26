using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _01569_NumberOfWaysToReorderArrayToGetSameBST_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_01569_NumberOfWaysToReorderArrayToGetSameBST))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01569_NumberOfWaysToReorderArrayToGetSameBST))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01569_NumberOfWaysToReorderArrayToGetSameBST))![1]);

        public static TheoryData<List<string>, int> _01569_NumberOfWaysToReorderArrayToGetSameBSTPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _01569_NumberOfWaysToReorderArrayToGetSameBSTPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_01569_NumberOfWaysToReorderArrayToGetSameBSTPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _01569_NumberOfWaysToReorderArrayToGetSameBST.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01569_NumberOfWaysToReorderArrayToGetSameBSTPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _01569_NumberOfWaysToReorderArrayToGetSameBST.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
