using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _02171_RemovingMinimumNumberOfMagicBeans_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_02171_RemovingMinimumNumberOfMagicBeans))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02171_RemovingMinimumNumberOfMagicBeans))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02171_RemovingMinimumNumberOfMagicBeans))![1]);

        public static TheoryData<List<string>, int> _02171_RemovingMinimumNumberOfMagicBeansPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _02171_RemovingMinimumNumberOfMagicBeansPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_02171_RemovingMinimumNumberOfMagicBeansPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _02171_RemovingMinimumNumberOfMagicBeans.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02171_RemovingMinimumNumberOfMagicBeansPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _02171_RemovingMinimumNumberOfMagicBeans.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
