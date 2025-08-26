using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _02433_FindTheOriginalArrayOfPrefixXor_Test
    {
        // Arrange
        private static readonly int[] a0 = [5, 2, 0, 3, 1];
        private static readonly int[] ar = [5, 7, 2, 3, 2];

        private static readonly int[] b0 = [13];
        private static readonly int[] br = [13];

        public static TheoryData<int[], int[]> _02433_FindTheOriginalArrayOfPrefixXor_Data =>
            new()
            {
                { a0, ar },
                { b0, br }
            };

        [Theory]
        [MemberData(nameof(_02433_FindTheOriginalArrayOfPrefixXor_Data))]
        public void FindArray0(int[] a0, int[] expected)
        {
            // Act
            int[] actual = _02433_FindTheOriginalArrayOfPrefixXor.FindArray0(a0);

            // Assert
            //Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02433_FindTheOriginalArrayOfPrefixXor_Data))]
        public void FindArray1(int[] a0, int[] expected)
        {
            // Act
            int[] actual = _02433_FindTheOriginalArrayOfPrefixXor.FindArray1(a0);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
