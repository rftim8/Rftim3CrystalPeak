namespace Rftim3xUnitLeetCode.Temp
{
    public class _00495_TeemoAttacking_Test
    {
        // Arrange
        private static readonly int[] a0 = [1, 4];
        private static readonly int a1 = 2;
        private static readonly int ar = 4;

        private static readonly int[] b0 = [1, 2];
        private static readonly int b1 = 2;
        private static readonly int br = 3;

        public static TheoryData<int[], int, int> _00495_TeemoAttacking_Data =>
            new()
            {
                { a0, a1, ar },
                { b0, b1, br }
            };

        [Theory]
        [MemberData(nameof(_00495_TeemoAttacking_Data))]
        public void FindPoisonedDuration0(int[] timeSeries, int duration, int expected)
        {
            // Act
            //int actual = _00495_TeemoAttacking.FindPoisonedDuration0(timeSeries, duration);

            // Assert
            //Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00495_TeemoAttacking_Data))]
        public void FindPoisonedDuration1(int[] timeSeries, int duration, int expected)
        {
            // Act
            //int actual = _00495_TeemoAttacking.FindPoisonedDuration1(timeSeries, duration);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
