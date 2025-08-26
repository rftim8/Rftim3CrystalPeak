namespace Rftim3xUnitLeetCode.Temp
{
    public class _02869_MinimumOperationsToCollectElements_Test
    {
        // Arrange
        private static readonly IList<int> a0 = [3, 1, 5, 4, 2];
        private static readonly int a1 = 2;
        private static readonly int ar = 4;

        private static readonly IList<int> b0 = [3, 1, 5, 4, 2];
        private static readonly int b1 = 5;
        private static readonly int br = 5;

        private static readonly IList<int> c0 = [3, 2, 5, 3, 1];
        private static readonly int c1 = 3;
        private static readonly int cr = 4;

        public static TheoryData<IList<int>, int, int> _02869_MinimumOperationsToCollectElements_Data =>
            new()
            {
                { a0, a1, ar },
                { b0, b1, br },
                { c0, c1, cr }
            };

        [Theory]
        [MemberData(nameof(_02869_MinimumOperationsToCollectElements_Data))]
        public void MinOperations0(IList<int> a0, int a1, int expected)
        {
            // Act
            //int actual = _02869_MinimumOperationsToCollectElements.MinOperations0(a0, a1);

            // Assert
            //Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02869_MinimumOperationsToCollectElements_Data))]
        public void MinOperations1(IList<int> a0, int a1, int expected)
        {
            // Act
            //int actual = _02869_MinimumOperationsToCollectElements.MinOperations1(a0, a1);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
