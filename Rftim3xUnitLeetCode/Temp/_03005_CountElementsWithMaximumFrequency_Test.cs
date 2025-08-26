using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _03005_CountElementsWithMaximumFrequency_Test
    {
        // Arrange
        private static readonly int[] a0 = [1, 2, 2, 3, 1, 4];
        private static readonly int ar = 4;

        private static readonly int[] b0 = [1, 2, 3, 4, 5];
        private static readonly int br = 5;

        public static TheoryData<int[], int> _03005_CountElementsWithMaximumFrequency_Data =>
            new()
            {
                { a0, ar },
                { b0, br }
            };


        [Theory]
        [MemberData(nameof(_03005_CountElementsWithMaximumFrequency_Data))]
        public void CountElementsWithMaximumFrequency0(int[] a0, int expected)
        {
            // Act
            int actual = _03005_CountElementsWithMaximumFrequency.CountElementsWithMaximumFrequency0(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}