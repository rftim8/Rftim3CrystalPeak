using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _01779_FindNearestPointThatHasTheSameXOrYCoordinate_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_01779_FindNearestPointThatHasTheSameXOrYCoordinate))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01779_FindNearestPointThatHasTheSameXOrYCoordinate))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01779_FindNearestPointThatHasTheSameXOrYCoordinate))![1]);

        public static TheoryData<List<string>, int> _01779_FindNearestPointThatHasTheSameXOrYCoordinatePartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _01779_FindNearestPointThatHasTheSameXOrYCoordinatePartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_01779_FindNearestPointThatHasTheSameXOrYCoordinatePartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _01779_FindNearestPointThatHasTheSameXOrYCoordinate.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01779_FindNearestPointThatHasTheSameXOrYCoordinatePartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _01779_FindNearestPointThatHasTheSameXOrYCoordinate.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
