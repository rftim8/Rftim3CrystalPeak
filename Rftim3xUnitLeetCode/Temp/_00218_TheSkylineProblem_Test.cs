using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00218_TheSkylineProblem_Test
    {
        // Arrange
        private static readonly int[][] a0 = [[2, 9, 10], [3, 7, 15], [5, 12, 12], [15, 20, 10], [19, 24, 8]];
        private static readonly List<IList<int>> ar = [[2, 10], [3, 15], [7, 12], [12, 0], [15, 10], [20, 8], [24, 0]];

        private static readonly int[][] b0 = [[0, 2, 3], [2, 5, 3]];
        private static readonly List<IList<int>> br = [[0, 3], [5, 0]];

        public static TheoryData<int[][], List<IList<int>>> _00218_TheSkylineProblem_Data =>
            new()
            {
                { a0, ar },
                { b0, br }
            };


        [Theory]
        [MemberData(nameof(_00218_TheSkylineProblem_Data))]
        public void TheSkylineProblem0(int[][] a0, List<IList<int>> expected)
        {
            // Act
            IList<IList<int>> actual = _00218_TheSkylineProblem.TheSkylineProblem0(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00218_TheSkylineProblem_Data))]
        public void TheSkylineProblem1(int[][] a0, List<IList<int>> expected)
        {
            // Act
            IList<IList<int>> actual = _00218_TheSkylineProblem.TheSkylineProblem1(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00218_TheSkylineProblem_Data))]
        public void TheSkylineProblem2(int[][] a0, List<IList<int>> expected)
        {
            // Act
            IList<IList<int>> actual = _00218_TheSkylineProblem.TheSkylineProblem2(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00218_TheSkylineProblem_Data))]
        public void TheSkylineProblem3(int[][] a0, List<IList<int>> expected)
        {
            // Act
            IList<IList<int>> actual = _00218_TheSkylineProblem.TheSkylineProblem3(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}