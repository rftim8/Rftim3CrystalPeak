using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _02402_MeetingRoomsIII_Test
    {
        // Arrange
        private static readonly int a0 = 2;
        private static readonly int[][] a1 = [[0, 10], [1, 5], [2, 7], [3, 4]];
        private static readonly int ar = 0;

        private static readonly int b0 = 3;
        private static readonly int[][] b1 = [[1, 20], [2, 10], [3, 5], [4, 9], [6, 8]];
        private static readonly int br = 1;

        public static TheoryData<int, int[][], int> _02402_MeetingRoomsIII_Data =>
            new()
            {
                { a0, a1, ar },
                { b0, b1, br }
            };

        [Theory]
        [MemberData(nameof(_02402_MeetingRoomsIII_Data))]
        public void MeetingRoomsIII0(int a0, int[][] a1, int expected)
        {
            // Act
            int actual = _02402_MeetingRoomsIII.MeetingRoomsIII0(a0, a1);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02402_MeetingRoomsIII_Data))]
        public void MeetingRoomsIII1(int a0, int[][] a1, int expected)
        {
            // Act
            int actual = _02402_MeetingRoomsIII.MeetingRoomsIII1(a0, a1);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}