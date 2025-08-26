using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _01671_MinimumNumberOfRemovalsToMakeMountainArray_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_01671_MinimumNumberOfRemovalsToMakeMountainArray))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01671_MinimumNumberOfRemovalsToMakeMountainArray))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01671_MinimumNumberOfRemovalsToMakeMountainArray))![1]);

        public static TheoryData<List<string>, int> _01671_MinimumNumberOfRemovalsToMakeMountainArrayPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _01671_MinimumNumberOfRemovalsToMakeMountainArrayPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_01671_MinimumNumberOfRemovalsToMakeMountainArrayPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _01671_MinimumNumberOfRemovalsToMakeMountainArray.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01671_MinimumNumberOfRemovalsToMakeMountainArrayPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _01671_MinimumNumberOfRemovalsToMakeMountainArray.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
