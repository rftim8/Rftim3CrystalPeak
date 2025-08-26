using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using Rftim3AdventOfCode.Refactor;

namespace Rftim3xUnitAdventOfCode.Unit
{
    public class _01_InverseCaptcha_Test
    {
        // Arrange
        private static readonly List<string> Input = RftAdventOfCodeStaticData.Input_Test(problemName: nameof(_01_InverseCaptcha))!;
        private static readonly int ExpectedPartOne = int.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_01_InverseCaptcha))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_01_InverseCaptcha))![1]);

        public static TheoryData<List<string>, int> _01_InverseCaptchaPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _01_InverseCaptchaPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_01_InverseCaptchaPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _01_InverseCaptcha.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01_InverseCaptchaPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _01_InverseCaptcha.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
