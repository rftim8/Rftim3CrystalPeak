using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00231_PowerOfTwo_Test
    {
        // Arrange
        private static readonly int a0 = 1;
        private static readonly bool ar = true;

        private static readonly int b0 = 16;
        private static readonly bool br = true;

        private static readonly int c0 = 3;
        private static readonly bool cr = false;

        public static TheoryData<int, bool> _00231_PowerOfTwo_Data =>
            new()
            {
                { a0, ar },
                { b0, br },
                { c0, cr }
            };


        [Theory]
        [MemberData(nameof(_00231_PowerOfTwo_Data))]
        public void PowerOfTwo0(int a0, bool expected)
        {
            // Act
            bool actual = _00231_PowerOfTwo.PowerOfTwo0(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}