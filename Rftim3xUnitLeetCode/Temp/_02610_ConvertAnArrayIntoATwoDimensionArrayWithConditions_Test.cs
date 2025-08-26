using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _02610_ConvertAnArrayIntoATwoDimensionArrayWithConditions_Test
    {
        // Arrange
        private static readonly int[] a0 = [1, 3, 4, 1, 2, 3, 1];
        private static readonly IList<IList<int>> ar = [[1, 3, 4, 2], [1, 3], [1]];

        private static readonly int[] b0 = [1, 2, 3, 4];
        private static readonly IList<IList<int>> br = [[4, 3, 2, 1]];

        public static TheoryData<int[], IList<IList<int>>> Assert0_Data =>
            new()
            {
                { a0, ar },
                { b0, br }
            };

        [Theory]
        [MemberData(nameof(Assert0_Data))]
        public void MinDifficulty0(int[] a0, IList<IList<int>> expected)
        {
            // Act
            IList<IList<int>> actual = _02610_ConvertAnArrayIntoATwoDimensionArrayWithConditions.FindMatrix0(a0);

            // Assert
            Assert.Equivalent(expected, actual, true);
        }

        [Theory]
        [MemberData(nameof(Assert0_Data))]
        public void MinDifficulty1(int[] a0, IList<IList<int>> expected)
        {
            // Act
            IList<IList<int>> actual = _02610_ConvertAnArrayIntoATwoDimensionArrayWithConditions.FindMatrix1(a0);

            // Assert
            Assert.Equivalent(expected, actual, true);
        }
    }
}
