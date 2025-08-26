using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _01432_MaxDifferenceYouCanGetFromChangingAnInteger_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_01432_MaxDifferenceYouCanGetFromChangingAnInteger))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01432_MaxDifferenceYouCanGetFromChangingAnInteger))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01432_MaxDifferenceYouCanGetFromChangingAnInteger))![1]);

        public static TheoryData<List<string>, int> _01432_MaxDifferenceYouCanGetFromChangingAnIntegerPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _01432_MaxDifferenceYouCanGetFromChangingAnIntegerPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_01432_MaxDifferenceYouCanGetFromChangingAnIntegerPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _01432_MaxDifferenceYouCanGetFromChangingAnInteger.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01432_MaxDifferenceYouCanGetFromChangingAnIntegerPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _01432_MaxDifferenceYouCanGetFromChangingAnInteger.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
