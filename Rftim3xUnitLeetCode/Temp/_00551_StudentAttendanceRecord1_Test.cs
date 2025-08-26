using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00551_StudentAttendanceRecord1_Test
    {
        // Arrange
        private static readonly string a0 = "PPALLP";
        private static readonly bool ar = true;

        private static readonly string b0 = "PPALLL";
        private static readonly bool br = false;

        public static TheoryData<string, bool> _00551_StudentAttendanceRecord1_Data =>
            new()
            {
                { a0, ar },
                { b0, br }
            };

        [Theory]
        [MemberData(nameof(_00551_StudentAttendanceRecord1_Data))]
        public void CheckRecord0(string s, bool expected)
        {
            // Act
            bool actual = _00551_StudentAttendanceRecord1.CheckRecord0(s);

            // Assert
            //Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00551_StudentAttendanceRecord1_Data))]
        public void CheckRecord1(string s, bool expected)
        {
            // Act
            bool actual = _00551_StudentAttendanceRecord1.CheckRecord1(s);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
