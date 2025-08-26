using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _00358_RearrangeStringkDistanceApart_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_00358_RearrangeStringkDistanceApart))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_00358_RearrangeStringkDistanceApart))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_00358_RearrangeStringkDistanceApart))![1]);

        public static TheoryData<List<string>, int> _00358_RearrangeStringkDistanceApartPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _00358_RearrangeStringkDistanceApartPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_00358_RearrangeStringkDistanceApartPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _00358_RearrangeStringkDistanceApart.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00358_RearrangeStringkDistanceApartPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _00358_RearrangeStringkDistanceApart.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
