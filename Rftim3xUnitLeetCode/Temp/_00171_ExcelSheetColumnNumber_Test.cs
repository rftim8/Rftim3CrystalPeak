namespace Rftim3xUnitLeetCode.Temp
{
    public class _00171_ExcelSheetColumnNumber_Test
    {
        // Arrange
        private static readonly string a0 = "A";
        private static readonly int ar = 1;

        private static readonly string b0 = "AB";
        private static readonly int br = 28;

        private static readonly string c0 = "ZY";
        private static readonly int cr = 701;

        public static TheoryData<string, int> _00171_ExcelSheetColumnNumber_Data =>
            new()
            {
                { a0, ar },
                { b0, br },
                { c0, cr }
            };

        [Theory]
        [MemberData(nameof(_00171_ExcelSheetColumnNumber_Data))]
        public void TitleToNumber0(string columnTitle, int expected)
        {
            // Act
            //int actual = _00171_ExcelSheetColumnNumber.TitleToNumber0(columnTitle);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
