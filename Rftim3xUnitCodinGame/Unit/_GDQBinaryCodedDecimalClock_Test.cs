using Rftim3Convoy.Services.Static.CP.CodinGame.Data;
using Rftim3CodinGame.Refactor;

namespace Rftim3xUnitCodinGame.Unit
{
    public class _GDQBinaryCodedDecimalClock_Test
    {
        // Arrange
        private static readonly List<string> Input = RftCodinGameStaticData.Input_Test(problemName: nameof(_GDQBinaryCodedDecimalClock))!;
        private static readonly int ExpectedPartOne = int.Parse(RftCodinGameStaticData.Output_Test(problemName: nameof(_GDQBinaryCodedDecimalClock))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftCodinGameStaticData.Output_Test(problemName: nameof(_GDQBinaryCodedDecimalClock))![1]);

        public static TheoryData<List<string>, int> _GDQBinaryCodedDecimalClockPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _GDQBinaryCodedDecimalClockPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_GDQBinaryCodedDecimalClockPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _GDQBinaryCodedDecimalClock.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_GDQBinaryCodedDecimalClockPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _GDQBinaryCodedDecimalClock.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
