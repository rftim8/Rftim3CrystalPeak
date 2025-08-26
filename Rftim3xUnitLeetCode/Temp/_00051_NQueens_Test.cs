using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00051_NQueens_Test
    {
        // Arrange
        private static readonly int a0 = 0;
        private static readonly List<IList<string>> ar = [];

        public static TheoryData<int, List<IList<string>>> _00051_NQueens_Data =>
            new()
            {
                { a0, ar }
            };


        [Theory]
        [MemberData(nameof(_00051_NQueens_Data))]
        public void NQueens0(int a0, List<IList<string>> expected)
        {
            // Act
            List<IList<string>> actual = _00051_NQueens.NQueens0(a0);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}