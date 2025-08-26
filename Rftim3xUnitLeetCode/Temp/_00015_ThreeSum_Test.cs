using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00015_ThreeSum_Test
    {
        // Arrange
        private static readonly int[] a0 = [-1, 0, 1, 2, -1, -4];
        private static readonly List<IList<int>> ar = [[-1, -1, 2], [-1, 0, 1]];

        private static readonly int[] b0 = [0, 1, 1];
        private static readonly List<IList<int>> br = [];

        private static readonly int[] c0 = [0, 0, 0];
        private static readonly List<IList<int>> cr = [[0, 0, 0]];

        public static TheoryData<int[], List<IList<int>>> _00015_ThreeSum_Data =>
            new()
            {
                { a0, ar },
                { b0, br },
                { c0, cr }
            };


        [Theory]
        [MemberData(nameof(_00015_ThreeSum_Data))]
        public void ThreeSum0(int[] a0, List<IList<int>> expected)
        {
            // Act
            IList<IList<int>> actual = _00015_ThreeSum.ThreeSum0(a0);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}