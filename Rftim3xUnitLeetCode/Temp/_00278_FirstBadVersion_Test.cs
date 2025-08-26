namespace Rftim3xUnitLeetCode.Temp
{
    public class _00278_FirstBadVersion_Test
    {
        // Arrange
        private static readonly int a0 = 5;
        private static readonly int a1 = 4;
        private static readonly int ar = 4;

        private static readonly int b0 = 1;
        private static readonly int b1 = 1;
        private static readonly int br = 1;

        public static TheoryData<int, int, int> _00278_FirstBadVersion_Data =>
            new()
            {
                { a0, a1, ar },
                { b0, b1, br }
            };

        [Theory]
        [MemberData(nameof(_00278_FirstBadVersion_Data))]
        public void FirstBadVersion0(int n, int bad, int expected)
        {
            // Act
            //int actual = _00278_FirstBadVersion.FirstBadVersion0(n, bad);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
