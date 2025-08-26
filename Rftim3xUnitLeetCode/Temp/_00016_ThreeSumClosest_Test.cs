namespace Rftim3xUnitLeetCode.Temp
{
    public class _00016_ThreeSumClosest_Test
    {
        // Arrange
        private static readonly int[] a0 = [-1, 2, 1, -4];
        private static readonly int a1 = 1;
        private static readonly int ar = 2;

        private static readonly int[] b0 = [0, 0, 0];
        private static readonly int b1 = 1;
        private static readonly int br = 0;

        public static TheoryData<int[], int, int> _00016_ThreeSumClosest_Data =>
            new()
            {
                { a0, a1, ar },
                { b0, b1, br }
            };


        [Theory]
        [MemberData(nameof(_00016_ThreeSumClosest_Data))]
        public void ThreeSumClosest0(int[] a0, int a1, int expected)
        {
            // Act
            //int actual = _00016_ThreeSumClosest.ThreeSumClosest0(a0, a1);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}