using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _01762_BuildingsWithAnOceanView_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_01762_BuildingsWithAnOceanView))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01762_BuildingsWithAnOceanView))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01762_BuildingsWithAnOceanView))![1]);

        public static TheoryData<List<string>, int> _01762_BuildingsWithAnOceanViewPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _01762_BuildingsWithAnOceanViewPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_01762_BuildingsWithAnOceanViewPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _01762_BuildingsWithAnOceanView.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01762_BuildingsWithAnOceanViewPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _01762_BuildingsWithAnOceanView.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
