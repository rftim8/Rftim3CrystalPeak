using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00520_DetectCapital_Test
    {
        // Arrange
        private static readonly string a0 = "USA";
        private static readonly bool ar = true;

        private static readonly string b0 = "FlaG";
        private static readonly bool br = false;

        public static TheoryData<string, bool> _00520_DetectCapital_Data =>
            new()
            {
                { a0, ar },
                { b0, br }
            };

        [Theory]
        [MemberData(nameof(_00520_DetectCapital_Data))]
        public void DetectCapitalUse0(string word, bool expected)
        {
            // Act
            bool actual = _00520_DetectCapital.DetectCapitalUse0(word);

            // Assert
            //Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00520_DetectCapital_Data))]
        public void DetectCapitalUse1(string word, bool expected)
        {
            // Act
            bool actual = _00520_DetectCapital.DetectCapitalUse1(word);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
