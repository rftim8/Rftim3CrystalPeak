using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _02940_FindBuildingWhereAliceAndBobCanMeet_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_02940_FindBuildingWhereAliceAndBobCanMeet))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02940_FindBuildingWhereAliceAndBobCanMeet))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02940_FindBuildingWhereAliceAndBobCanMeet))![1]);

        public static TheoryData<List<string>, int> _02940_FindBuildingWhereAliceAndBobCanMeetPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _02940_FindBuildingWhereAliceAndBobCanMeetPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_02940_FindBuildingWhereAliceAndBobCanMeetPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _02940_FindBuildingWhereAliceAndBobCanMeet.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02940_FindBuildingWhereAliceAndBobCanMeetPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _02940_FindBuildingWhereAliceAndBobCanMeet.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
