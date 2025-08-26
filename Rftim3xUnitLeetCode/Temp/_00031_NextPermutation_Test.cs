using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00031_NextPermutation_Test
    {
        // Arrange
        private static readonly int[] a0 = [];
        private static readonly int[] ar = [];

        public static TheoryData<int[], int[]> _00031_NextPermutation_Data =>
            new()
            {
                { a0, ar }
            };


        [Theory]
        [MemberData(nameof(_00031_NextPermutation_Data))]
        public void NextPermutation0(int[] a0, int[] expected)
        {
            // Act
            int[] actual = _00031_NextPermutation.NextPermutation0(a0);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}