using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00168_ExcelSheetColumnTitle_Test
    {
        // Arrange
        private static readonly int a0 = 1;
        private static readonly string ar = "A";

        private static readonly int b0 = 28;
        private static readonly string br = "AB";

        private static readonly int c0 = 701;
        private static readonly string cr = "ZY";

        public static TheoryData<int, string> _00168_ExcelSheetColumnTitle_Data =>
            new()
            {
                { a0, ar },
                { b0, br },
                { c0, cr }
            };

        [Theory]
        [MemberData(nameof(_00168_ExcelSheetColumnTitle_Data))]
        public void ConvertToTitle0(int columnNumber, string expected)
        {
            // Act
            string actual = _00168_ExcelSheetColumnTitle.ConvertToTitle0(columnNumber);

            // Assert
            //Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00168_ExcelSheetColumnTitle_Data))]
        public void ConvertToTitle1(int columnNumber, string expected)
        {
            // Act
            string actual = _00168_ExcelSheetColumnTitle.ConvertToTitle1(columnNumber);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
