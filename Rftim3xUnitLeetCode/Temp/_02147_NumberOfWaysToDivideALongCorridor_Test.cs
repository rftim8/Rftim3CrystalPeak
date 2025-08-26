namespace Rftim3xUnitLeetCode.Temp
{
    public class _02147_NumberOfWaysToDivideALongCorridor_Test
    {
        // Arrange
        private static readonly string a0 = "SSPPSPS";
        private static readonly int ar = 3;

        private static readonly string b0 = "PPSPSP";
        private static readonly int br = 1;

        private static readonly string c0 = "S";
        private static readonly int cr = 0;

        public static TheoryData<string, int> _02147_NumberOfWaysToDivideALongCorridor_Data =>
            new()
            {
                { a0, ar },
                { b0, br },
                { c0, cr }
            };

        [Theory]
        [MemberData(nameof(_02147_NumberOfWaysToDivideALongCorridor_Data))]
        public void NumberOfWays0(string nums, int expected)
        {
            // Act
            //int actual = _02147_NumberOfWaysToDivideALongCorridor.NumberOfWays0(nums);

            // Assert
            //Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02147_NumberOfWaysToDivideALongCorridor_Data))]
        public void NumberOfWays1(string nums, int expected)
        {
            // Act
            //int actual = _02147_NumberOfWaysToDivideALongCorridor.NumberOfWays1(nums);

            // Assert
            //Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02147_NumberOfWaysToDivideALongCorridor_Data))]
        public void NumberOfWays2(string nums, int expected)
        {
            // Act
            //int actual = _02147_NumberOfWaysToDivideALongCorridor.NumberOfWays2(nums);

            // Assert
            //Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02147_NumberOfWaysToDivideALongCorridor_Data))]
        public void NumberOfWays3(string nums, int expected)
        {
            // Act
            //int actual = _02147_NumberOfWaysToDivideALongCorridor.NumberOfWays3(nums);

            // Assert
            //Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02147_NumberOfWaysToDivideALongCorridor_Data))]
        public void NumberOfWays4(string nums, int expected)
        {
            // Act
            //int actual = _02147_NumberOfWaysToDivideALongCorridor.NumberOfWays4(nums);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
