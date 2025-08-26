using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00190_ReverseBits_Test
    {
        // Arrange
        private static readonly uint a0 = 43261596;
        private static readonly uint ar = 964176192;

        private static readonly uint b0 = 4294967293;
        private static readonly uint br = 3221225471;

        public static TheoryData<uint, uint> _00190_ReverseBits_Data =>
            new()
            {
                { a0, ar },
                { b0, br }
            };

        [Theory]
        [MemberData(nameof(_00190_ReverseBits_Data))]
        public void ReverseBits0(uint n, uint expected)
        {
            // Act
            uint actual = _00190_ReverseBits.ReverseBits0(n);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00190_ReverseBits_Data))]
        public void ReverseBits1(uint n, uint expected)
        {
            // Act
            uint actual = _00190_ReverseBits.ReverseBits1(n);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
