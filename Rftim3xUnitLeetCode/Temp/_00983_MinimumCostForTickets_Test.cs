using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00983_MinimumCostForTickets_Test
    {
        // Arrange
        private static readonly int[] a0 = [1, 4, 6, 7, 8, 20], a1 = [2, 7, 15];
        private static readonly int ar = 11;

        private static readonly int[] b0 = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 30, 31], b1 = [2, 7, 15];
        private static readonly int br = 17;

        public static TheoryData<int[], int[], int> _00983_MinimumCostForTickets_Data =>
            new()
            {
                { a0, a1, ar },
                { b0, b1, br }
            };

        [Theory]
        [MemberData(nameof(_00983_MinimumCostForTickets_Data))]
        public void MinimumCostForTickets0(int[] a0, int[] a1, int expected)
        {
            // Act
            int actual = _00983_MinimumCostForTickets.MinimumCostForTickets0(a0, a1);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00983_MinimumCostForTickets_Data))]
        public void MinimumCostForTickets1(int[] a0, int[] a1, int expected)
        {
            // Act
            int actual = _00983_MinimumCostForTickets.MinimumCostForTickets1(a0, a1);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00983_MinimumCostForTickets_Data))]
        public void MinimumCostForTickets2(int[] a0, int[] a1, int expected)
        {
            // Act
            int actual = _00983_MinimumCostForTickets.MinimumCostForTickets2(a0, a1);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}