using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00217_ContainsDuplicate_Test
    {
        // Arrange
        private static readonly int[] a0 = [1, 2, 3, 1];
        private static readonly bool ar = true;

        private static readonly int[] b0 = [1, 2, 3, 4];
        private static readonly bool br = false;

        private static readonly int[] c0 = [1, 1, 1, 3, 3, 4, 3, 2, 4, 2];
        private static readonly bool cr = true;

        public static TheoryData<int[], bool> _00217_ContainsDuplicate_Data =>
            new()
            {
                { a0, ar },
                { b0, br },
                { c0, cr }
            };

        [Theory]
        [MemberData(nameof(_00217_ContainsDuplicate_Data))]
        public void ContainsDuplicate0(int[] nums, bool expected)
        {
            // Act
            bool actual = _00217_ContainsDuplicate.ContainsDuplicate0(nums);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
