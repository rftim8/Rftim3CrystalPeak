using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _02184_NumberOfWaysToBuildSturdyBrickWall_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_02184_NumberOfWaysToBuildSturdyBrickWall))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02184_NumberOfWaysToBuildSturdyBrickWall))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02184_NumberOfWaysToBuildSturdyBrickWall))![1]);

        public static TheoryData<List<string>, int> _02184_NumberOfWaysToBuildSturdyBrickWallPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _02184_NumberOfWaysToBuildSturdyBrickWallPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_02184_NumberOfWaysToBuildSturdyBrickWallPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _02184_NumberOfWaysToBuildSturdyBrickWall.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02184_NumberOfWaysToBuildSturdyBrickWallPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _02184_NumberOfWaysToBuildSturdyBrickWall.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
