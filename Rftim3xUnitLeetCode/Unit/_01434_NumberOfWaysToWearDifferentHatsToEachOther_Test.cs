using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _01434_NumberOfWaysToWearDifferentHatsToEachOther_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_01434_NumberOfWaysToWearDifferentHatsToEachOther))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01434_NumberOfWaysToWearDifferentHatsToEachOther))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01434_NumberOfWaysToWearDifferentHatsToEachOther))![1]);

        public static TheoryData<List<string>, int> _01434_NumberOfWaysToWearDifferentHatsToEachOtherPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _01434_NumberOfWaysToWearDifferentHatsToEachOtherPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_01434_NumberOfWaysToWearDifferentHatsToEachOtherPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _01434_NumberOfWaysToWearDifferentHatsToEachOther.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01434_NumberOfWaysToWearDifferentHatsToEachOtherPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _01434_NumberOfWaysToWearDifferentHatsToEachOther.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
