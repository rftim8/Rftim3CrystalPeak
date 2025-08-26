using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00492_ConstructTheRectangle_Test
    {
        // Arrange
        private static readonly int a0 = 4;
        private static readonly int[] ar = [2, 2];

        private static readonly int b0 = 37;
        private static readonly int[] br = [37, 1];

        private static readonly int c0 = 122122;
        private static readonly int[] cr = [427, 286];

        public static TheoryData<int, int[]> _00492_ConstructTheRectangle_Data =>
            new()
            {
                { a0, ar },
                { b0, br },
                { c0, cr }
            };

        [Theory]
        [MemberData(nameof(_00492_ConstructTheRectangle_Data))]
        public void ConstructRectangle0(int area, int[] expected)
        {
            // Act
            int[] actual = _00492_ConstructTheRectangle.ConstructRectangle0(area);

            // Assert
            //Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00492_ConstructTheRectangle_Data))]
        public void ConstructRectangle1(int area, int[] expected)
        {
            // Act
            int[] actual = _00492_ConstructTheRectangle.ConstructRectangle1(area);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
