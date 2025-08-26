using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00170_TwoSumIII_Datastructuredesign_Test
    {
        // Arrange
        private static readonly List<string> a0 = ["TwoSum", "add", "add", "add", "find", "find"];
        private static readonly List<int[]> a1 = [[0], [1], [3], [5], [4], [7]];
        private static readonly List<bool?> ar = [true, false];

        public static TheoryData<List<string>, List<int[]>, List<bool?>> _00170_TwoSumIII_Datastructuredesign_Data =>
            new()
            {
                { a0, a1, ar }
            };


        [Theory]
        [MemberData(nameof(_00170_TwoSumIII_Datastructuredesign_Data))]
        public void Datastructuredesign0(List<string> a0, List<int[]> a1, List<bool?> expected)
        {
            // Act
            List<bool?> actual = _00170_TwoSumIII_Datastructuredesign.Datastructuredesign0(a0, a1);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}