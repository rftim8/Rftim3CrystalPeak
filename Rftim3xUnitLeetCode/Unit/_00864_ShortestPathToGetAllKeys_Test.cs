using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _00864_ShortestPathToGetAllKeys_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_00864_ShortestPathToGetAllKeys))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_00864_ShortestPathToGetAllKeys))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_00864_ShortestPathToGetAllKeys))![1]);

        public static TheoryData<List<string>, int> _00864_ShortestPathToGetAllKeysPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _00864_ShortestPathToGetAllKeysPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_00864_ShortestPathToGetAllKeysPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _00864_ShortestPathToGetAllKeys.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00864_ShortestPathToGetAllKeysPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _00864_ShortestPathToGetAllKeys.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
