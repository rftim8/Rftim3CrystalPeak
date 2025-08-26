using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00507_PerfectNumber_Test
    {
        // Arrange
        private static readonly int a0 = 28;
        private static readonly bool ar = true;

        private static readonly int b0 = 7;
        private static readonly bool br = false;

        public static TheoryData<int, bool> _00507_PerfectNumber_Data =>
            new()
            {
                { a0, ar },
                { b0, br }
            };

        [Theory]
        [MemberData(nameof(_00507_PerfectNumber_Data))]
        public void CheckPerfectNumber0(int num, bool expected)
        {
            // Act
            bool actual = _00507_PerfectNumber.CheckPerfectNumber0(num);

            // Assert
            //Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00507_PerfectNumber_Data))]
        public void CheckPerfectNumber1(int num, bool expected)
        {
            // Act
            bool actual = _00507_PerfectNumber.CheckPerfectNumber1(num);

            // Assert
            //Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00507_PerfectNumber_Data))]
        public void CheckPerfectNumber2(int num, bool expected)
        {
            // Act
            bool actual = _00507_PerfectNumber.CheckPerfectNumber2(num);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
