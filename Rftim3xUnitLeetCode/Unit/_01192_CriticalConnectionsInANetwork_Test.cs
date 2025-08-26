using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _01192_CriticalConnectionsInANetwork_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_01192_CriticalConnectionsInANetwork))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01192_CriticalConnectionsInANetwork))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01192_CriticalConnectionsInANetwork))![1]);

        public static TheoryData<List<string>, int> _01192_CriticalConnectionsInANetworkPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _01192_CriticalConnectionsInANetworkPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_01192_CriticalConnectionsInANetworkPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _01192_CriticalConnectionsInANetwork.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01192_CriticalConnectionsInANetworkPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _01192_CriticalConnectionsInANetwork.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
