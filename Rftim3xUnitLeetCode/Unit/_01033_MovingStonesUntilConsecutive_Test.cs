using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _01033_MovingStonesUntilConsecutive_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_01033_MovingStonesUntilConsecutive))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01033_MovingStonesUntilConsecutive))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01033_MovingStonesUntilConsecutive))![1]);

        public static TheoryData<List<string>, int> _01033_MovingStonesUntilConsecutivePartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _01033_MovingStonesUntilConsecutivePartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_01033_MovingStonesUntilConsecutivePartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _01033_MovingStonesUntilConsecutive.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01033_MovingStonesUntilConsecutivePartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _01033_MovingStonesUntilConsecutive.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
