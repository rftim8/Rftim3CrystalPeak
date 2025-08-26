using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _02076_ProcessRestrictedFriendRequests_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_02076_ProcessRestrictedFriendRequests))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02076_ProcessRestrictedFriendRequests))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02076_ProcessRestrictedFriendRequests))![1]);

        public static TheoryData<List<string>, int> _02076_ProcessRestrictedFriendRequestsPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _02076_ProcessRestrictedFriendRequestsPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_02076_ProcessRestrictedFriendRequestsPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _02076_ProcessRestrictedFriendRequests.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02076_ProcessRestrictedFriendRequestsPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _02076_ProcessRestrictedFriendRequests.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
