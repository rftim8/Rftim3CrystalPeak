using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _02444_CountSubarraysWithFixedBounds_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_02444_CountSubarraysWithFixedBounds))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02444_CountSubarraysWithFixedBounds))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02444_CountSubarraysWithFixedBounds))![1]);

        public static TheoryData<List<string>, int> _02444_CountSubarraysWithFixedBoundsPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _02444_CountSubarraysWithFixedBoundsPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_02444_CountSubarraysWithFixedBoundsPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _02444_CountSubarraysWithFixedBounds.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02444_CountSubarraysWithFixedBoundsPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _02444_CountSubarraysWithFixedBounds.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
