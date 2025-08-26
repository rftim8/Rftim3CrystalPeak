using Rftim3Convoy.Services.Static.CP.CodinGame.Data;
using Rftim3CodinGame.Refactor;

namespace Rftim3xUnitCodinGame.Unit
{
    public class _CreateTheLongestSequenceOf1s_Test
    {
        // Arrange
        private static readonly List<string> Input = RftCodinGameStaticData.Input_Test(problemName: nameof(_CreateTheLongestSequenceOf1s))!;
        private static readonly int ExpectedPartOne = int.Parse(RftCodinGameStaticData.Output_Test(problemName: nameof(_CreateTheLongestSequenceOf1s))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftCodinGameStaticData.Output_Test(problemName: nameof(_CreateTheLongestSequenceOf1s))![1]);

        public static TheoryData<List<string>, int> _CreateTheLongestSequenceOf1sPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _CreateTheLongestSequenceOf1sPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_CreateTheLongestSequenceOf1sPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _CreateTheLongestSequenceOf1s.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_CreateTheLongestSequenceOf1sPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _CreateTheLongestSequenceOf1s.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
