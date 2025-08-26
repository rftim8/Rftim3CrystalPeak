using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00504_Base7_Test
    {
        // Arrange
        private static readonly int a0 = 100;
        private static readonly string ar = "202";

        private static readonly int b0 = -7;
        private static readonly string br = "-10";

        public static TheoryData<int, string> _00504_Base7_Data =>
            new()
            {
                { a0, ar },
                { b0, br }
            };

        [Theory]
        [MemberData(nameof(_00504_Base7_Data))]
        public void ConvertToBaseSeven0(int num, string expected)
        {
            // Act
            string actual = _00504_Base7.ConvertToBaseSeven0(num);

            // Assert
            //Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00504_Base7_Data))]
        public void ConvertToBaseSeven1(int num, string expected)
        {
            // Act
            string actual = _00504_Base7.ConvertToBaseSeven1(num);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
