using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _01101_TheEarliestMomentWhenEveryoneBecomeFriends_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_01101_TheEarliestMomentWhenEveryoneBecomeFriends))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01101_TheEarliestMomentWhenEveryoneBecomeFriends))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01101_TheEarliestMomentWhenEveryoneBecomeFriends))![1]);

        public static TheoryData<List<string>, int> _01101_TheEarliestMomentWhenEveryoneBecomeFriendsPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _01101_TheEarliestMomentWhenEveryoneBecomeFriendsPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_01101_TheEarliestMomentWhenEveryoneBecomeFriendsPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _01101_TheEarliestMomentWhenEveryoneBecomeFriends.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01101_TheEarliestMomentWhenEveryoneBecomeFriendsPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _01101_TheEarliestMomentWhenEveryoneBecomeFriends.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
