using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _01282_GroupThePeopleGivenTheGroupSizeTheyBelongTo_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_01282_GroupThePeopleGivenTheGroupSizeTheyBelongTo))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01282_GroupThePeopleGivenTheGroupSizeTheyBelongTo))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01282_GroupThePeopleGivenTheGroupSizeTheyBelongTo))![1]);

        public static TheoryData<List<string>, int> _01282_GroupThePeopleGivenTheGroupSizeTheyBelongToPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _01282_GroupThePeopleGivenTheGroupSizeTheyBelongToPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_01282_GroupThePeopleGivenTheGroupSizeTheyBelongToPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _01282_GroupThePeopleGivenTheGroupSizeTheyBelongTo.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01282_GroupThePeopleGivenTheGroupSizeTheyBelongToPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _01282_GroupThePeopleGivenTheGroupSizeTheyBelongTo.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
