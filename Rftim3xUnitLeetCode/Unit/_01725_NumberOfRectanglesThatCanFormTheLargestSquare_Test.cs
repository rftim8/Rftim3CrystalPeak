using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _01725_NumberOfRectanglesThatCanFormTheLargestSquare_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_01725_NumberOfRectanglesThatCanFormTheLargestSquare))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01725_NumberOfRectanglesThatCanFormTheLargestSquare))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01725_NumberOfRectanglesThatCanFormTheLargestSquare))![1]);

        public static TheoryData<List<string>, int> _01725_NumberOfRectanglesThatCanFormTheLargestSquarePartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _01725_NumberOfRectanglesThatCanFormTheLargestSquarePartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_01725_NumberOfRectanglesThatCanFormTheLargestSquarePartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _01725_NumberOfRectanglesThatCanFormTheLargestSquare.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01725_NumberOfRectanglesThatCanFormTheLargestSquarePartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _01725_NumberOfRectanglesThatCanFormTheLargestSquare.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
