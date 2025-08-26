using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00040_CombinationSumII_Test
    {
        // Arrange
        private static readonly int[] a0 = [];
        private static readonly int a1 = 0;
        private static readonly List<IList<int>> ar = [];

        public static TheoryData<int[], int, List<IList<int>>> _00040_CombinationSumII_Data =>
            new()
            {
                { a0, a1, ar }
            };


        [Theory]
        [MemberData(nameof(_00040_CombinationSumII_Data))]
        public void CombinationSumII0(int[] a0, int a1, List<IList<int>> expected)
        {
            // Act
            IList<IList<int>> actual = _00040_CombinationSumII.CombinationSumII0(a0, a1);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}