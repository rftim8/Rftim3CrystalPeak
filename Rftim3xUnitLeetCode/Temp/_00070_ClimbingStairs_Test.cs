namespace Rftim3xUnitLeetCode.Temp
{
    public class _00070_ClimbingStairs_Test
    {
        // Arrange
        private static readonly int a0 = 2;
        private static readonly int ar = 2;

        private static readonly int b0 = 3;
        private static readonly int br = 3;

        public static TheoryData<int, int> _00070_ClimbingStairs_Data =>
            new()
            {
                { a0, ar },
                { b0, br }
            };

        [Theory]
        [MemberData(nameof(_00070_ClimbingStairs_Data))]
        public void ClimbStairs0(int x, int expected)
        {
            // Act
            //int actual = _00070_ClimbingStairs.ClimbStairs0(x);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
