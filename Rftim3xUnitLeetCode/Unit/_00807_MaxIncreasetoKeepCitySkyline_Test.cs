using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _00807_MaxIncreasetoKeepCitySkyline_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_00807_MaxIncreasetoKeepCitySkyline))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_00807_MaxIncreasetoKeepCitySkyline))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_00807_MaxIncreasetoKeepCitySkyline))![1]);

        public static TheoryData<List<string>, int> _00807_MaxIncreasetoKeepCitySkylinePartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _00807_MaxIncreasetoKeepCitySkylinePartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_00807_MaxIncreasetoKeepCitySkylinePartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _00807_MaxIncreasetoKeepCitySkyline.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00807_MaxIncreasetoKeepCitySkylinePartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _00807_MaxIncreasetoKeepCitySkyline.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
