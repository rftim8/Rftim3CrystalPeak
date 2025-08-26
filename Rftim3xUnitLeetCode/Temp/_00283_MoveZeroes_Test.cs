using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00283_MoveZeroes_Test
    {
        // Arrange
        private static readonly int[] a0 = [0, 1, 0, 3, 12];
        private static readonly int[] ar = [1, 3, 12, 0, 0];

        private static readonly int[] b0 = [0];
        private static readonly int[] br = [0];

        public static TheoryData<int[], int[]> _00283_MoveZeroes_Data =>
            new()
            {
                { a0, ar },
                { b0, br }
            };

        [Theory]
        [MemberData(nameof(_00283_MoveZeroes_Data))]
        public void MoveZeroes0(int[] nums, int[] expected)
        {
            // Act
            int[] actual = _00283_MoveZeroes.MoveZeroes0(nums);

            // Assert
            //Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00283_MoveZeroes_Data))]
        public void MoveZeroes1(int[] nums, int[] expected)
        {
            // Act
            int[] actual = _00283_MoveZeroes.MoveZeroes1(nums);

            // Assert
            //Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00283_MoveZeroes_Data))]
        public void MoveZeroes2(int[] nums, int[] expected)
        {
            // Act
            int[] actual = _00283_MoveZeroes.MoveZeroes2(nums);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
