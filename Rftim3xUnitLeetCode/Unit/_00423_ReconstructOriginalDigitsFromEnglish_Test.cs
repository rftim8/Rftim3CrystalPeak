using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _00423_ReconstructOriginalDigitsFromEnglish_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_00423_ReconstructOriginalDigitsFromEnglish))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_00423_ReconstructOriginalDigitsFromEnglish))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_00423_ReconstructOriginalDigitsFromEnglish))![1]);

        public static TheoryData<List<string>, int> _00423_ReconstructOriginalDigitsFromEnglishPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _00423_ReconstructOriginalDigitsFromEnglishPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_00423_ReconstructOriginalDigitsFromEnglishPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _00423_ReconstructOriginalDigitsFromEnglish.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00423_ReconstructOriginalDigitsFromEnglishPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _00423_ReconstructOriginalDigitsFromEnglish.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
