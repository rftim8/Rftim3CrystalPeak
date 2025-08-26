namespace Rftim3xUnitLeetCode.Temp
{
    public class _00458_PoorPigs_Test
    {
        // Arrange
        private static readonly int a0 = 4;
        private static readonly int a1 = 15;
        private static readonly int a2 = 15;
        private static readonly int ar = 2;

        private static readonly int b0 = 4;
        private static readonly int b1 = 15;
        private static readonly int b2 = 30;
        private static readonly int br = 2;

        public static TheoryData<int, int, int, int> _00458_PoorPigs_Data =>
            new()
            {
                { a0, a1, a2, ar },
                { b0, b1, b2, br }
            };

        [Theory]
        [MemberData(nameof(_00458_PoorPigs_Data))]
        public void PoorPigs0(int buckets, int minutesToDie, int minutesToTest, int expected)
        {
            // Act
            //int actual = _00458_PoorPigs.PoorPigs0(buckets, minutesToDie, minutesToTest);

            // Assert
            //Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00458_PoorPigs_Data))]
        public void PoorPigs1(int buckets, int minutesToDie, int minutesToTest, int expected)
        {
            // Act
            //int actual = _00458_PoorPigs.PoorPigs1(buckets, minutesToDie, minutesToTest);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
