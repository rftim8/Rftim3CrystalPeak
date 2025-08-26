using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _02966_DivideArrayIntoArraysWithMaxDifference_Test
    {
        // Arrange
        private static readonly int[] a0 = [1, 3, 4, 8, 7, 9, 3, 5, 1];
        private static readonly int a1 = 2;
        private static readonly int[][] ar = [[1, 1, 3], [3, 4, 5], [7, 8, 9]];

        private static readonly int[] b0 = [1, 3, 3, 2, 7, 3];
        private static readonly int b1 = 3;
        private static readonly int[][] br = [];

        public static TheoryData<int[], int, int[][]> _02966_DivideArrayIntoArraysWithMaxDifference_Data =>
            new()
            {
                { a0, a1, ar },
                { b0, b1, br }
            };


        [Theory]
        [MemberData(nameof(_02966_DivideArrayIntoArraysWithMaxDifference_Data))]
        public void DivideArrayIntoArraysWithMaxDifference0(int[] a0, int a1, int[][] expected)
        {
            // Act
            int[][] actual = _02966_DivideArrayIntoArraysWithMaxDifference.DivideArrayIntoArraysWithMaxDifference0(a0, a1);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02966_DivideArrayIntoArraysWithMaxDifference_Data))]
        public void DivideArrayIntoArraysWithMaxDifference1(int[] a0, int a1, int[][] expected)
        {
            // Act
            int[][] actual = _02966_DivideArrayIntoArraysWithMaxDifference.DivideArrayIntoArraysWithMaxDifference1(a0, a1);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}