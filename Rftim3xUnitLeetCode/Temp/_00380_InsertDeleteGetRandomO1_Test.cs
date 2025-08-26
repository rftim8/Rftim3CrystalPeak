using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00380_InsertDeleteGetRandomO1_Test
    {
        // Arrange
        private static readonly string[] a0 = ["RandomizedSet", "insert", "remove", "insert", "getRandom", "remove", "insert", "getRandom"];
        private static readonly int[][] a1 = [[], [1], [2], [2], [], [1], [2], []];

        public static TheoryData<string[], int[][]> _00380_InsertDeleteGetRandomO1_Data =>
            new()
            {
                { a0, a1 }
            };

        [Theory]
        [MemberData(nameof(_00380_InsertDeleteGetRandomO1_Data))]
        public void RandomizeSet0(string[] a0, int[][] a1)
        {
            // Act
            List<object?> actual = _00380_InsertDeleteGetRandomO1.RandomizeSet0(a0, a1);
            List<object?>? expected = _00380_InsertDeleteGetRandomO1.R;

            // Assert
            //Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00380_InsertDeleteGetRandomO1_Data))]
        public void RandomizeSet1(string[] a0, int[][] a1)
        {
            // Act
            List<object?> actual = _00380_InsertDeleteGetRandomO1.RandomizeSet1(a0, a1);
            List<object?>? expected = _00380_InsertDeleteGetRandomO1.R;

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
