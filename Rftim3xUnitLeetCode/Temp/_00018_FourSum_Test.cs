using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00018_FourSum_Test
    {
        // Arrange
        private static readonly int[] a0 = [1, 0, -1, 0, -2, 2];
        private static readonly int a1 = 0;
        private static readonly List<IList<int>> ar = [[-2, -1, 1, 2], [-2, 0, 0, 2], [-1, 0, 0, 1]];

        private static readonly int[] b0 = [2, 2, 2, 2, 2];
        private static readonly int b1 = 8;
        private static readonly List<IList<int>> br = [[2, 2, 2, 2]];

        public static TheoryData<int[], int, List<IList<int>>> _00018_FourSum_Data =>
            new()
            {
                { a0, a1, ar },
                { b0, b1, br }
            };


        [Theory]
        [MemberData(nameof(_00018_FourSum_Data))]
        public void FourSum0(int[] a0, int a1, List<IList<int>> expected)
        {
            // Act
            IList<IList<int>> actual = _00018_FourSum.FourSum0(a0, a1);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}