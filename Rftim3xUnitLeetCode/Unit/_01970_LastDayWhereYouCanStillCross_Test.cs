using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _01970_LastDayWhereYouCanStillCross_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_01970_LastDayWhereYouCanStillCross))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01970_LastDayWhereYouCanStillCross))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01970_LastDayWhereYouCanStillCross))![1]);

        public static TheoryData<List<string>, int> _01970_LastDayWhereYouCanStillCrossPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _01970_LastDayWhereYouCanStillCrossPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_01970_LastDayWhereYouCanStillCrossPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _01970_LastDayWhereYouCanStillCross.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01970_LastDayWhereYouCanStillCrossPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _01970_LastDayWhereYouCanStillCross.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
