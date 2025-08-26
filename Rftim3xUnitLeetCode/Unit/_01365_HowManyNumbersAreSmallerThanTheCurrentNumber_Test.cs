using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _01365_HowManyNumbersAreSmallerThanTheCurrentNumber_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_01365_HowManyNumbersAreSmallerThanTheCurrentNumber))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01365_HowManyNumbersAreSmallerThanTheCurrentNumber))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01365_HowManyNumbersAreSmallerThanTheCurrentNumber))![1]);

        public static TheoryData<List<string>, int> _01365_HowManyNumbersAreSmallerThanTheCurrentNumberPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _01365_HowManyNumbersAreSmallerThanTheCurrentNumberPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_01365_HowManyNumbersAreSmallerThanTheCurrentNumberPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _01365_HowManyNumbersAreSmallerThanTheCurrentNumber.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01365_HowManyNumbersAreSmallerThanTheCurrentNumberPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _01365_HowManyNumbersAreSmallerThanTheCurrentNumber.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
