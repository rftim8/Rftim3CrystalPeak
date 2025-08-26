namespace Rftim3xUnitLeetCode.Temp
{
    public class _00191_NumberOfOneBits_Test
    {
        // Arrange
        private static readonly uint a0 = 11;
        private static readonly int ar = 3;

        private static readonly uint b0 = 128;
        private static readonly int br = 1;

        private static readonly uint c0 = 4294967293;
        private static readonly int cr = 31;

        public static TheoryData<uint, int> _00191_NumberOfOneBits_Data =>
            new()
            {
                { a0, ar},
                { b0, br },
                { c0, cr }
            };

        [Theory]
        [MemberData(nameof(_00191_NumberOfOneBits_Data))]
        public void HammingWeight0(uint n, int expected)
        {
            // Act
            //int actual = _00191_NumberOfOneBits.HammingWeight0(n);

            // Assert
            //Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00191_NumberOfOneBits_Data))]
        public void HammingWeight1(uint n, int expected)
        {
            // Act
            //int actual = _00191_NumberOfOneBits.HammingWeight1(n);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
