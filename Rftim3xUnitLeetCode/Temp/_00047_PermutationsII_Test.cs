using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00047_PermutationsII_Test
    {
        // Arrange
        private static readonly int[] a0 = [];
        private static readonly List<IList<int>> ar = [];

        public static TheoryData<int[], List<IList<int>>> _00047_PermutationsII_Data =>
            new()
            {
                { a0, ar }
            };


        [Theory]
        [MemberData(nameof(_00047_PermutationsII_Data))]
        public void PermutationsII0(int[] a0, List<IList<int>> expected)
        {
            // Act
            IList<IList<int>> actual = _00047_PermutationsII.PermutationsII0(a0);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}