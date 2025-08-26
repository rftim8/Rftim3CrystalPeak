using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _02124_CheckIfAllAsAppearsBeforeAllBs_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_02124_CheckIfAllAsAppearsBeforeAllBs))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02124_CheckIfAllAsAppearsBeforeAllBs))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02124_CheckIfAllAsAppearsBeforeAllBs))![1]);

        public static TheoryData<List<string>, int> _02124_CheckIfAllAsAppearsBeforeAllBsPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _02124_CheckIfAllAsAppearsBeforeAllBsPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_02124_CheckIfAllAsAppearsBeforeAllBsPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _02124_CheckIfAllAsAppearsBeforeAllBs.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02124_CheckIfAllAsAppearsBeforeAllBsPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _02124_CheckIfAllAsAppearsBeforeAllBs.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
