namespace Rftim3xUnitLeetCode.Temp
{
    public class _00011_ContainerWithMostWater_Test
    {
        // Arrange
        private static readonly int[] a0 = [1, 8, 6, 2, 5, 4, 8, 3, 7];
        private static readonly int ar = 49;

        private static readonly int[] b0 = [1, 1];
        private static readonly int br = 1;

        public static TheoryData<int[], int> _00011_ContainerWithMostWater_Data =>
            new()
            {
                { a0, ar }
            };


        [Theory]
        [MemberData(nameof(_00011_ContainerWithMostWater_Data))]
        public void ContainerWithMostWater0(int[] a0, int expected)
        {
            // Act
            //int actual = _00011_ContainerWithMostWater.ContainerWithMostWater0(a0);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}