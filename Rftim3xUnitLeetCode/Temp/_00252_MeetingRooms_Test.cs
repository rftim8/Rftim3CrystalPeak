using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00252_MeetingRooms_Test
    {
        // Arrange
        private static readonly int[][] a0 = [[0, 30], [5, 10], [15, 20]];
        private static readonly bool ar = false;

        private static readonly int[][] b0 = [[7, 10], [2, 4]];
        private static readonly bool br = true;

        public static TheoryData<int[][], bool> _00252_MeetingRooms_Data =>
            new()
            {
                { a0, ar },
                { b0, br }
            };

        [Theory]
        [MemberData(nameof(_00252_MeetingRooms_Data))]
        public void CanAttendMeetings0(int[][] a0, bool expected)
        {
            // Act
            bool actual = _00252_MeetingRooms.CanAttendMeetings0(a0);

            // Assert
            //Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00252_MeetingRooms_Data))]
        public void CanAttendMeetings1(int[][] a0, bool expected)
        {
            // Act
            bool actual = _00252_MeetingRooms.CanAttendMeetings1(a0);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
