using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _01770_MaximumScoreFromPerformingMultiplicationOperations_Test
    {
        // Arrange
        private static readonly int[] a0 = [1, 2, 3], a1 = [3, 2, 1];
        private static readonly int ar = 14;

        private static readonly int[] b0 = [-5, -3, -3, -2, 7, 1], b1 = [-10, -5, 3, 4, 6];
        private static readonly int br = 102;

        public static TheoryData<int[], int[], int> _01770_MaximumScoreFromPerformingMultiplicationOperations_Data =>
            new()
            {
                { a0, a1, ar },
                { b0, b1, br }
            };

        [Theory]
        [MemberData(nameof(_01770_MaximumScoreFromPerformingMultiplicationOperations_Data))]
        public void MaximumScoreFromPerformingMultiplicationOperations0(int[] a0, int[] a1, int expected)
        {
            // Act
            int actual = _01770_MaximumScoreFromPerformingMultiplicationOperations.MaximumScoreFromPerformingMultiplicationOperations0(a0, a1);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01770_MaximumScoreFromPerformingMultiplicationOperations_Data))]
        public void MaximumScoreFromPerformingMultiplicationOperations1(int[] a0, int[] a1, int expected)
        {
            // Act
            int actual = _01770_MaximumScoreFromPerformingMultiplicationOperations.MaximumScoreFromPerformingMultiplicationOperations1(a0, a1);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01770_MaximumScoreFromPerformingMultiplicationOperations_Data))]
        public void MaximumScoreFromPerformingMultiplicationOperations2(int[] a0, int[] a1, int expected)
        {
            // Act
            int actual = _01770_MaximumScoreFromPerformingMultiplicationOperations.MaximumScoreFromPerformingMultiplicationOperations2(a0, a1);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01770_MaximumScoreFromPerformingMultiplicationOperations_Data))]
        public void MaximumScoreFromPerformingMultiplicationOperations3(int[] a0, int[] a1, int expected)
        {
            // Act
            int actual = _01770_MaximumScoreFromPerformingMultiplicationOperations.MaximumScoreFromPerformingMultiplicationOperations3(a0, a1);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}