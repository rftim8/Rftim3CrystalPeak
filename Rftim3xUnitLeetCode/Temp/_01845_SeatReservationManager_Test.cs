using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _01845_SeatReservationManager_Test
    {
        // Arrange
        private static readonly List<string> a0 = ["SeatManager", "reserve", "reserve", "unreserve", "reserve", "reserve", "reserve", "reserve", "unreserve"];
        private static readonly List<int> a1 = [5, -1, -1, 2, -1, -1, -1, -1, 5];
        private static readonly List<int> ar = [1, 2, 2, 3, 4, 5];

        public static TheoryData<List<string>, List<int>, List<int>> _01845_SeatReservationManager_Data =>
            new()
            {
                { a0, a1, ar }
            };

        [Theory]
        [MemberData(nameof(_01845_SeatReservationManager_Data))]
        public void SeatReservationManager0(List<string> a0, List<int> a1, List<int> expected)
        {
            // Act
            List<int> actual = _01845_SeatReservationManager.SeatReservationManager0(a0, a1);

            // Assert
            //Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01845_SeatReservationManager_Data))]
        public void SeatReservationManager1(List<string> a0, List<int> a1, List<int> expected)
        {
            // Act
            List<int> actual = _01845_SeatReservationManager.SeatReservationManager1(a0, a1);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
