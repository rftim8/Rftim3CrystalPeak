using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _01442_CountTripletsThatCanFormTwoArraysofEqualXOR_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_01442_CountTripletsThatCanFormTwoArraysofEqualXOR))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01442_CountTripletsThatCanFormTwoArraysofEqualXOR))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01442_CountTripletsThatCanFormTwoArraysofEqualXOR))![1]);

        public static TheoryData<List<string>, int> _01442_CountTripletsThatCanFormTwoArraysofEqualXORPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _01442_CountTripletsThatCanFormTwoArraysofEqualXORPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_01442_CountTripletsThatCanFormTwoArraysofEqualXORPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _01442_CountTripletsThatCanFormTwoArraysofEqualXOR.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01442_CountTripletsThatCanFormTwoArraysofEqualXORPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _01442_CountTripletsThatCanFormTwoArraysofEqualXOR.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
