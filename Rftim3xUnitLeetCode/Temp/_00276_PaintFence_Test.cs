using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00276_PaintFence_Test
    {
        // Arrange
        private static readonly int a0 = 3, a1 = 2, ar = 6;

        private static readonly int b0 = 1, b1 = 1, br = 1;

        private static readonly int c0 = 7, c1 = 2, cr = 42;

        public static TheoryData<int, int, int> _00276_PaintFence_Data =>
            new()
            {
                { a0, a1, ar },
                { b0, b1, br },
                { c0, c1, cr }
            };


        [Theory]
        [MemberData(nameof(_00276_PaintFence_Data))]
        public void PaintFence0(int a0, int a1, int expected)
        {
            // Act
            int actual = _00276_PaintFence.PaintFence0(a0, a1);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00276_PaintFence_Data))]
        public void PaintFence1(int a0, int a1, int expected)
        {
            // Act
            int actual = _00276_PaintFence.PaintFence1(a0, a1);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00276_PaintFence_Data))]
        public void PaintFence2(int a0, int a1, int expected)
        {
            // Act
            int actual = _00276_PaintFence.PaintFence2(a0, a1);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00276_PaintFence_Data))]
        public void PaintFence3(int a0, int a1, int expected)
        {
            // Act
            int actual = _00276_PaintFence.PaintFence3(a0, a1);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}