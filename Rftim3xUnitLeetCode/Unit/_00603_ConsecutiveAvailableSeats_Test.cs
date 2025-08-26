using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _00603_ConsecutiveAvailableSeats_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_00603_ConsecutiveAvailableSeats))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_00603_ConsecutiveAvailableSeats))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_00603_ConsecutiveAvailableSeats))![1]);

        public static TheoryData<List<string>, int> _00603_ConsecutiveAvailableSeatsPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _00603_ConsecutiveAvailableSeatsPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_00603_ConsecutiveAvailableSeatsPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _00603_ConsecutiveAvailableSeats.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00603_ConsecutiveAvailableSeatsPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _00603_ConsecutiveAvailableSeats.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
