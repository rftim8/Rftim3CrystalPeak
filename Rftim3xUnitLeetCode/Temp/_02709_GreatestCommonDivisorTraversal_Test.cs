using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _02709_GreatestCommonDivisorTraversal_Test
    {
        // Arrange
        private static readonly int[] a0 = [2, 3, 6];
        private static readonly bool ar = true;

        private static readonly int[] b0 = [3, 9, 5];
        private static readonly bool br = false;

        private static readonly int[] c0 = [4, 3, 12, 8];
        private static readonly bool cr = true;

        public static TheoryData<int[], bool> _02709_GreatestCommonDivisorTraversal_Data =>
            new()
            {
                { a0, ar },
                { b0, br },
                { c0, cr }
            };

        [Theory]
        [MemberData(nameof(_02709_GreatestCommonDivisorTraversal_Data))]
        public void GreatestCommonDivisorTraversal0(int[] a0, bool expected)
        {
            // Act
            bool actual = _02709_GreatestCommonDivisorTraversal.GreatestCommonDivisorTraversal0(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02709_GreatestCommonDivisorTraversal_Data))]
        public void GreatestCommonDivisorTraversal1(int[] a0, bool expected)
        {
            // Act
            bool actual = _02709_GreatestCommonDivisorTraversal.GreatestCommonDivisorTraversal1(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}