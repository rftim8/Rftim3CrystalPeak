namespace Rftim3xUnitLeetCode.Temp
{
    public class _02391_MinimumAmountOfTimeToCollectGarbage_Test
    {
        // Arrange
        private static readonly string[] a0 = ["G", "P", "GP", "GG"];
        private static readonly int[] a1 = [2, 4, 3];
        private static readonly int ar = 21;

        private static readonly string[] b0 = ["MMM", "PGM", "GP"];
        private static readonly int[] b1 = [3, 10];
        private static readonly int br = 37;

        public static TheoryData<string[], int[], int> _02391_MinimumAmountOfTimeToCollectGarbage_Data =>
            new()
            {
                { a0, a1, ar },
                { b0, b1, br }
            };

        [Theory]
        [MemberData(nameof(_02391_MinimumAmountOfTimeToCollectGarbage_Data))]
        public void GarbageCollection0(string[] a0, int[] b0, int expected)
        {
            // Act
            //int actual = _02391_MinimumAmountOfTimeToCollectGarbage.GarbageCollection0(a0, b0);

            // Assert
            //Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02391_MinimumAmountOfTimeToCollectGarbage_Data))]
        public void GarbageCollection1(string[] a0, int[] b0, int expected)
        {
            // Act
            //int actual = _02391_MinimumAmountOfTimeToCollectGarbage.GarbageCollection1(a0, b0);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
