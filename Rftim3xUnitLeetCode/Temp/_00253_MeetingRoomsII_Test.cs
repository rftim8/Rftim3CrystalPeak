namespace Rftim3xUnitLeetCode.Temp
{
    public class _00253_MeetingRoomsII_Test
    {
        // Arrange
        private static readonly int[][] a0 = [[0, 30], [5, 10], [15, 20]];
        private static readonly int ar = 2;

        private static readonly int[][] b0 = [[7, 10], [2, 4]];
        private static readonly int br = 1;

        public static TheoryData<int[][], int> _00253_MeetingRoomsII_Data =>
            new()
            {
                { a0, ar },
                { b0, br }
            };

        [Theory]
        [MemberData(nameof(_00253_MeetingRoomsII_Data))]
        public void CanAttendMeetings0(int[][] a0, int expected)
        {
            // Act
            //int actual = _00253_MeetingRoomsII.MinMeetingRooms0(a0);

            // Assert
            //Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00253_MeetingRoomsII_Data))]
        public void CanAttendMeetings1(int[][] a0, int expected)
        {
            // Act
            //int actual = _00253_MeetingRoomsII.MinMeetingRooms1(a0);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
