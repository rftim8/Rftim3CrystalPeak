using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00506_RelativeRanks_Test
    {
        // Arrange
        private static readonly int[] a0 = [5, 4, 3, 2, 1];
        private static readonly string[] ar = ["Gold Medal", "Silver Medal", "Bronze Medal", "4", "5"];

        private static readonly int[] b0 = [10, 3, 8, 9, 4];
        private static readonly string[] br = ["Gold Medal", "5", "Bronze Medal", "Silver Medal", "4"];

        public static TheoryData<int[], string[]> _00506_RelativeRanks_Data =>
            new()
            {
                { a0, ar },
                { b0, br }
            };

        [Theory]
        [MemberData(nameof(_00506_RelativeRanks_Data))]
        public void FindRelativeRanks0(int[] score, string[] expected)
        {
            // Act
            string[] actual = _00506_RelativeRanks.FindRelativeRanks0(score);

            // Assert
            //Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00506_RelativeRanks_Data))]
        public void FindRelativeRanks1(int[] score, string[] expected)
        {
            // Act
            string[] actual = _00506_RelativeRanks.FindRelativeRanks1(score);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
