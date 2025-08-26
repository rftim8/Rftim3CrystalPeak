using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _01424_DiagonalTraverse2_Test
    {
        // Arrange
        private static readonly List<IList<int>> a0 = [[1, 2, 3], [4, 5, 6], [7, 8, 9]];
        private static readonly int[] ar = [1, 4, 2, 7, 5, 3, 8, 6, 9];

        private static readonly List<IList<int>> b0 = [[1, 2, 3, 4, 5], [6, 7], [8], [9, 10, 11], [12, 13, 14, 15, 16]];
        private static readonly int[] br = [1, 6, 2, 8, 7, 3, 9, 4, 12, 10, 5, 13, 11, 14, 15, 16];

        public static TheoryData<List<IList<int>>, int[]> _01424_DiagonalTraverse2_Data =>
            new()
            {
                { a0, ar },
                { b0, br }
            };

        [Theory]
        [MemberData(nameof(_01424_DiagonalTraverse2_Data))]
        public void FindDiagonalOrder0(List<IList<int>> arr, int[] expected)
        {
            // Act
            int[] actual = _01424_DiagonalTraverse2.FindDiagonalOrder0(arr);

            // Assert
            //Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01424_DiagonalTraverse2_Data))]
        public void FindDiagonalOrder1(List<IList<int>> arr, int[] expected)
        {
            // Act
            int[] actual = _01424_DiagonalTraverse2.FindDiagonalOrder1(arr);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
