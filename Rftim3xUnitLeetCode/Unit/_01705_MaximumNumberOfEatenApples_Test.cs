using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _01705_MaximumNumberOfEatenApples_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_01705_MaximumNumberOfEatenApples))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01705_MaximumNumberOfEatenApples))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01705_MaximumNumberOfEatenApples))![1]);

        public static TheoryData<List<string>, int> _01705_MaximumNumberOfEatenApplesPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _01705_MaximumNumberOfEatenApplesPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_01705_MaximumNumberOfEatenApplesPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _01705_MaximumNumberOfEatenApples.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01705_MaximumNumberOfEatenApplesPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _01705_MaximumNumberOfEatenApples.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
