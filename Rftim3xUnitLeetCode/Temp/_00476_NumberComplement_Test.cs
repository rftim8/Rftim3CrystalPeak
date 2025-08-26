namespace Rftim3xUnitLeetCode.Temp
{
    public class _00476_NumberComplement_Test
    {
        // Arrange
        private static readonly int a0 = 5;
        private static readonly int ar = 2;

        private static readonly int b0 = 1;
        private static readonly int br = 0;

        public static TheoryData<int, int> _00476_NumberComplement_Data =>
            new()
            {
                { a0, ar },
                { b0, br }
            };

        [Theory]
        [MemberData(nameof(_00476_NumberComplement_Data))]
        public void FindComplement0(int num, int expected)
        {
            // Act
            //int actual = _00476_NumberComplement.FindComplement0(num);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
