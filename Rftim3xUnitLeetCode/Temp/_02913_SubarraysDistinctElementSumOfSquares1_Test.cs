namespace Rftim3xUnitLeetCode.Temp
{
    public class _02913_SubarraysDistinctElementSumOfSquares1_Test
    {
        // Arrange
        private static readonly IList<int> a0 = [1, 2, 1];
        private static readonly int ar = 15;

        private static readonly IList<int> b0 = [1, 1];
        private static readonly int br = 3;

        public static TheoryData<IList<int>, int> _02913_SubarraysDistinctElementSumOfSquares1_Data =>
            new()
            {
                { a0, ar },
                { b0, br }
            };

        [Theory]
        [MemberData(nameof(_02913_SubarraysDistinctElementSumOfSquares1_Data))]
        public void SumCounts0(IList<int> a0, int expected)
        {
            // Act
            //int actual = _02913_SubarraysDistinctElementSumOfSquares1.SumCounts0(a0);

            // Assert
            //Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02913_SubarraysDistinctElementSumOfSquares1_Data))]
        public void SumCounts1(IList<int> a0, int expected)
        {
            // Act
            //int actual = _02913_SubarraysDistinctElementSumOfSquares1.SumCounts1(a0);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
