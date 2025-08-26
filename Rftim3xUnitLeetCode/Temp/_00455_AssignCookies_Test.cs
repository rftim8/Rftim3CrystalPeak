namespace Rftim3xUnitLeetCode.Temp
{
    public class _00455_AssignCookies_Test
    {
        // Arrange
        private static readonly int[] a0 = [1, 2, 3];
        private static readonly int[] a1 = [1, 1];
        private static readonly int ar = 1;

        private static readonly int[] b0 = [1, 2];
        private static readonly int[] b1 = [1, 2, 3];
        private static readonly int br = 2;

        public static TheoryData<int[], int[], int> _00455_AssignCookies_Data =>
            new()
            {
                { a0, a1, ar },
                { b0, b1, br }
            };

        [Theory]
        [MemberData(nameof(_00455_AssignCookies_Data))]
        public void FindContentChildren0(int[] g, int[] s, int expected)
        {
            // Act
            //int actual = _00455_AssignCookies.FindContentChildren0(g, s);

            // Assert
            //Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00455_AssignCookies_Data))]
        public void FindContentChildren1(int[] g, int[] s, int expected)
        {
            // Act
            //int actual = _00455_AssignCookies.FindContentChildren1(g, s);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
