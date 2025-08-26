using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _00849_MaximizeDistanceToClosestPerson_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_00849_MaximizeDistanceToClosestPerson))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_00849_MaximizeDistanceToClosestPerson))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_00849_MaximizeDistanceToClosestPerson))![1]);

        public static TheoryData<List<string>, int> _00849_MaximizeDistanceToClosestPersonPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _00849_MaximizeDistanceToClosestPersonPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_00849_MaximizeDistanceToClosestPersonPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _00849_MaximizeDistanceToClosestPerson.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00849_MaximizeDistanceToClosestPersonPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _00849_MaximizeDistanceToClosestPerson.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
