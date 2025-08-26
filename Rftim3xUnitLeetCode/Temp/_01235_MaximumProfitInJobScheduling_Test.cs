namespace Rftim3xUnitLeetCode.Temp
{
    public class _01235_MaximumProfitInJobScheduling_Test
    {
        // Arrange
        private static readonly int[] a0 = [1, 2, 3, 3];
        private static readonly int[] a1 = [3, 4, 5, 6];
        private static readonly int[] a2 = [50, 10, 40, 70];
        private static readonly int ar = 120;

        private static readonly int[] b0 = [1, 2, 3, 4, 6];
        private static readonly int[] b1 = [3, 5, 10, 6, 9];
        private static readonly int[] b2 = [20, 20, 100, 70, 60];
        private static readonly int br = 150;

        private static readonly int[] c0 = [1, 1, 1];
        private static readonly int[] c1 = [2, 3, 4];
        private static readonly int[] c2 = [5, 6, 4];
        private static readonly int cr = 6;

        public static TheoryData<int[], int[], int[], int> _01235_MaximumProfitInJobScheduling_Data =>
            new()
            {
                { a0, a1, a2, ar },
                { b0, b1, b2, br },
                { c0, c1, c2, cr }
            };

        [Theory]
        [MemberData(nameof(_01235_MaximumProfitInJobScheduling_Data))]
        public void JobScheduling0(int[] a0, int[] a1, int[] a2, int expected)
        {
            // Act
            //int actual = _01235_MaximumProfitInJobScheduling.JobScheduling0(a0, a1, a2);

            // Assert
            //Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01235_MaximumProfitInJobScheduling_Data))]
        public void JobScheduling1(int[] a0, int[] a1, int[] a2, int expected)
        {
            // Act
            //int actual = _01235_MaximumProfitInJobScheduling.JobScheduling1(a0, a1, a2);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
