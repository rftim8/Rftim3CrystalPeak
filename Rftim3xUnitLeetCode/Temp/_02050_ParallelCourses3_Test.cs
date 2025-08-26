namespace Rftim3xUnitLeetCode.Temp
{
    public class _02050_ParallelCourses3_Test
    {
        // Arrange
        private static readonly int a0 = 3;
        private static readonly int[][] a1 = [[1, 3], [2, 3]];
        private static readonly int[] a2 = [3, 2, 5];
        private static readonly int ar = 8;

        private static readonly int b0 = 5;
        private static readonly int[][] b1 = [[1, 5], [2, 5], [3, 5], [3, 4], [4, 5]];
        private static readonly int[] b2 = [1, 2, 3, 4, 5];
        private static readonly int br = 12;

        public static TheoryData<int, int[][], int[], int> _02050_ParallelCourses3_Data =>
            new()
            {
                { a0, a1, a2, ar },
                { b0, b1, b2, br }
            };


        [Theory]
        [MemberData(nameof(_02050_ParallelCourses3_Data))]
        public void MinimumTime0(int n, int[][] relations, int[] data, int expected)
        {
            // Act
            //int actual = _02050_ParallelCourses3.MinimumTime0(n, relations, data);

            // Assert
            //Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02050_ParallelCourses3_Data))]
        public void MinimumTime1(int n, int[][] relations, int[] data, int expected)
        {
            // Act
            //int actual = _02050_ParallelCourses3.MinimumTime1(n, relations, data);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
