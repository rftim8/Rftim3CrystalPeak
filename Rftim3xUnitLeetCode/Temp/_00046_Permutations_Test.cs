using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00046_Permutations_Test
    {
        // Arrange
        private static readonly int[] a0 = [];
        private static readonly List<IList<int>> ar = [];

        public static TheoryData<int[], List<IList<int>>> _00046_Permutations_Data =>
            new()
            {
                { a0, ar }
            };


        [Theory]
        [MemberData(nameof(_00046_Permutations_Data))]
        public void Permutations0(int[] a0, List<IList<int>> expected)
        {
            // Act
            List<IList<int>> actual = _00046_Permutations.Permutations0(a0);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}