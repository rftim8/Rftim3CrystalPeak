using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _02971_FindPolygonWithTheLargestPerimeter_Test
    {
        // Arrange
        private static readonly int[] a0 = [5, 5, 5];
        private static readonly long ar = 15;

        private static readonly int[] b0 = [1, 12, 1, 2, 5, 50, 3];
        private static readonly long br = 12;

        private static readonly int[] c0 = [5, 5, 50];
        private static readonly long cr = -1;

        public static TheoryData<int[], long> _02971_FindPolygonWithTheLargestPerimeter_Data =>
            new()
            {
                { a0, ar },
                { b0, br },
                { c0, cr }
            };

        [Theory]
        [MemberData(nameof(_02971_FindPolygonWithTheLargestPerimeter_Data))]
        public void FindPolygonWithTheLargestPerimeter0(int[] a0, long expected)
        {
            // Act
            long actual = _02971_FindPolygonWithTheLargestPerimeter.FindPolygonWithTheLargestPerimeter0(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02971_FindPolygonWithTheLargestPerimeter_Data))]
        public void FindPolygonWithTheLargestPerimeter1(int[] a0, long expected)
        {
            // Act
            long actual = _02971_FindPolygonWithTheLargestPerimeter.FindPolygonWithTheLargestPerimeter1(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}