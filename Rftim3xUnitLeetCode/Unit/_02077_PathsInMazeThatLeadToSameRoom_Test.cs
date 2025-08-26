using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _02077_PathsInMazeThatLeadToSameRoom_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_02077_PathsInMazeThatLeadToSameRoom))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02077_PathsInMazeThatLeadToSameRoom))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02077_PathsInMazeThatLeadToSameRoom))![1]);

        public static TheoryData<List<string>, int> _02077_PathsInMazeThatLeadToSameRoomPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _02077_PathsInMazeThatLeadToSameRoomPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_02077_PathsInMazeThatLeadToSameRoomPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _02077_PathsInMazeThatLeadToSameRoom.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02077_PathsInMazeThatLeadToSameRoomPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _02077_PathsInMazeThatLeadToSameRoom.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
