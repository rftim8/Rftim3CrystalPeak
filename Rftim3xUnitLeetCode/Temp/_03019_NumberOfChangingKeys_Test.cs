using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _03019_NumberOfChangingKeys_Test
    {
        // Arrange
        private static readonly int[] a0 = [];
        private static readonly int ar = 0;

        public static TheoryData<int[], int> _03019_NumberOfChangingKeys_Data =>
            new()
            {
                { a0, ar }
            };


        [Theory]
        [MemberData(nameof(_03019_NumberOfChangingKeys_Data))]
        public void NumberOfChangingKeys0(int[] a0, int expected)
        {
            // Act
            int actual = _03019_NumberOfChangingKeys.NumberOfChangingKeys0(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}