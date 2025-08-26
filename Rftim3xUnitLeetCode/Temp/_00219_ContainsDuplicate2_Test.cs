using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00219_ContainsDuplicate2_Test
    {
        // Arrange
        private static readonly int[] a0 = [1, 2, 3, 1];
        private static readonly int a1 = 3;
        private static readonly bool ar = true;

        private static readonly int[] b0 = [1, 0, 1, 1];
        private static readonly int b1 = 1;
        private static readonly bool br = true;

        private static readonly int[] c0 = [1, 2, 3, 1, 2, 3];
        private static readonly int c1 = 2;
        private static readonly bool cr = false;

        public static TheoryData<int[], int, bool> _00219_ContainsDuplicate2_Data =>
            new()
            {
                { a0, a1, ar },
                { b0, b1, br },
                { c0, c1, cr }
            };

        [Theory]
        [MemberData(nameof(_00219_ContainsDuplicate2_Data))]
        public void ContainsNearbyDuplicate0(int[] nums, int k, bool expected)
        {
            // Act
            bool actual = _00219_ContainsDuplicate2.ContainsNearbyDuplicate0(nums, k);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
