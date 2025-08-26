using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00238_ProductOfArrayExceptSelf_Test
    {
        // Arrange
        private static readonly int[] a0 = [1, 2, 3, 4];
        private static readonly int[] ar = [24, 12, 8, 6];

        private static readonly int[] b0 = [-1, 1, 0, -3, 3];
        private static readonly int[] br = [0, 0, 9, 0, 0];

        public static TheoryData<int[], int[]> _00238_ProductOfArrayExceptSelf_Data =>
            new()
            {
                { a0, ar },
                { b0, br }
            };


        [Theory]
        [MemberData(nameof(_00238_ProductOfArrayExceptSelf_Data))]
        public void ProductOfArrayExceptSelf0(int[] a0, int[] expected)
        {
            // Act
            int[] actual = _00238_ProductOfArrayExceptSelf.ProductOfArrayExceptSelf0(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00238_ProductOfArrayExceptSelf_Data))]
        public void ProductOfArrayExceptSelf1(int[] a0, int[] expected)
        {
            // Act
            int[] actual = _00238_ProductOfArrayExceptSelf.ProductOfArrayExceptSelf1(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00238_ProductOfArrayExceptSelf_Data))]
        public void ProductOfArrayExceptSelf2(int[] a0, int[] expected)
        {
            // Act
            int[] actual = _00238_ProductOfArrayExceptSelf.ProductOfArrayExceptSelf2(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}