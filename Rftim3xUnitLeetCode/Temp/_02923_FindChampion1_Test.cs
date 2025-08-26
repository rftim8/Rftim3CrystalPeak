namespace Rftim3xUnitLeetCode.Temp
{
    public class _02923_FindChampion1_Test
    {
        // Arrange
        private static readonly int[][] a0 = [[0, 1], [0, 0]];
        private static readonly int ar = 0;

        private static readonly int[][] b0 = [[0, 0, 1], [1, 0, 1], [0, 0, 0]];
        private static readonly int br = 1;

        public static TheoryData<int[][], int> _02923_FindChampion1_Data =>
            new()
            {
                { a0, ar },
                { b0, br }
            };

        [Theory]
        [MemberData(nameof(_02923_FindChampion1_Data))]
        public void FindChampion0(int[][] a0, int expected)
        {
            // Act
            //int actual = _02923_FindChampion1.FindChampion0(a0);

            // Assert
            //Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02923_FindChampion1_Data))]
        public void FindChampion1(int[][] a0, int expected)
        {
            // Act
            //int actual = _02923_FindChampion1.FindChampion1(a0);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
