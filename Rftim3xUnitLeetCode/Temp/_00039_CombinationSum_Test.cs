using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00039_CombinationSum_Test
    {
        // Arrange
        private static readonly int[] a0 = [];
        private static readonly int a1 = 0;
        private static readonly List<IList<int>> ar = [];

        public static TheoryData<int[], int, List<IList<int>>> _00039_CombinationSum_Data =>
            new()
            {
                { a0, a1, ar }
            };


        [Theory]
        [MemberData(nameof(_00039_CombinationSum_Data))]
        public void CombinationSum0(int[] a0, int a1, List<IList<int>> expected)
        {
            // Act
            IList<IList<int>> actual = _00039_CombinationSum.CombinationSum0(a0, a1);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}