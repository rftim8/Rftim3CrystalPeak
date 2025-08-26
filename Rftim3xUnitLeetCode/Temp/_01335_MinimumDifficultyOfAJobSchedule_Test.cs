using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _01335_MinimumDifficultyOfAJobSchedule_Test
    {
        // Arrange
        private static readonly int[] a0 = [6, 5, 4, 3, 2, 1];
        private static readonly int a1 = 2;
        private static readonly int ar = 7;

        private static readonly int[] b0 = [9, 9, 9];
        private static readonly int b1 = 4;
        private static readonly int br = -1;

        private static readonly int[] c0 = [1, 1, 1];
        private static readonly int c1 = 3;
        private static readonly int cr = 3;

        public static TheoryData<int[], int, int> Assert0_Data =>
            new()
            {
                { a0, a1, ar },
                { b0, b1, br },
                { c0, c1, cr }
            };

        [Theory]
        [MemberData(nameof(Assert0_Data))]
        public void MinDifficulty0(int[] a0, int a1, int expected)
        {
            // Act
            int actual = _01335_MinimumDifficultyOfAJobSchedule.MinDifficulty0(a0, a1);

            // Assert
            Assert.Equivalent(expected, actual, true);
        }

        [Theory]
        [MemberData(nameof(Assert0_Data))]
        public void MinDifficulty1(int[] a0, int a1, int expected)
        {
            // Act
            int actual = _01335_MinimumDifficultyOfAJobSchedule.MinDifficulty1(a0, a1);

            // Assert
            Assert.Equivalent(expected, actual, true);
        }

        [Theory]
        [MemberData(nameof(Assert0_Data))]
        public void MinDifficulty2(int[] a0, int a1, int expected)
        {
            // Act
            int actual = _01335_MinimumDifficultyOfAJobSchedule.MinDifficulty2(a0, a1);

            // Assert
            Assert.Equivalent(expected, actual, true);
        }
    }
}
