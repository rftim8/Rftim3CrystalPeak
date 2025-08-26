using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _01318_MinimumFlipsToMakeAORBEqualToC_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_01318_MinimumFlipsToMakeAORBEqualToC))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01318_MinimumFlipsToMakeAORBEqualToC))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01318_MinimumFlipsToMakeAORBEqualToC))![1]);

        public static TheoryData<List<string>, int> _01318_MinimumFlipsToMakeAORBEqualToCPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _01318_MinimumFlipsToMakeAORBEqualToCPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_01318_MinimumFlipsToMakeAORBEqualToCPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _01318_MinimumFlipsToMakeAORBEqualToC.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01318_MinimumFlipsToMakeAORBEqualToCPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _01318_MinimumFlipsToMakeAORBEqualToC.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
