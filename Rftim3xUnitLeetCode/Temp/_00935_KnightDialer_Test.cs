using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00935_KnightDialer_Test
    {
        private static readonly int a0 = 1;
        private static readonly int ar = 10;

        private static readonly int b0 = 2;
        private static readonly int br = 20;

        private static readonly int c0 = 3131;
        private static readonly int cr = 136006598;

        // Arrange
        public static TheoryData<int, int> _00935_KnightDialer_Data =>
            new()
            {
                { a0, ar },
                { b0, br },
                { c0, cr }
            };

        [Theory]
        [MemberData(nameof(_00935_KnightDialer_Data))]
        public void KnightDialer0(int a0, int expected)
        {
            // Act
            int actual = _00935_KnightDialer.KnightDialer0(a0);

            // Assert
            Assert.Equivalent(expected, actual, true);
        }

        [Theory]
        [MemberData(nameof(_00935_KnightDialer_Data))]
        public void KnightDialer1(int a0, int expected)
        {
            // Act
            int actual = _00935_KnightDialer.KnightDialer1(a0);

            // Assert
            Assert.Equivalent(expected, actual, true);
        }

        [Theory]
        [MemberData(nameof(_00935_KnightDialer_Data))]
        public void KnightDialer2(int a0, int expected)
        {
            // Act
            int actual = _00935_KnightDialer.KnightDialer2(a0);

            // Assert
            Assert.Equivalent(expected, actual, true);
        }

        [Theory]
        [MemberData(nameof(_00935_KnightDialer_Data))]
        public void KnightDialer3(int a0, int expected)
        {
            // Act
            int actual = _00935_KnightDialer.KnightDialer3(a0);

            // Assert
            Assert.Equivalent(expected, actual, true);
        }

        [Theory]
        [MemberData(nameof(_00935_KnightDialer_Data))]
        public void KnightDialer4(int a0, int expected)
        {
            // Act
            int actual = _00935_KnightDialer.KnightDialer4(a0);

            // Assert
            Assert.Equivalent(expected, actual, true);
        }
    }
}
