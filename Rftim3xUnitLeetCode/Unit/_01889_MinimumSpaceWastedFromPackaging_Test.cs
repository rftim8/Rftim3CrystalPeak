using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _01889_MinimumSpaceWastedFromPackaging_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_01889_MinimumSpaceWastedFromPackaging))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01889_MinimumSpaceWastedFromPackaging))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01889_MinimumSpaceWastedFromPackaging))![1]);

        public static TheoryData<List<string>, int> _01889_MinimumSpaceWastedFromPackagingPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _01889_MinimumSpaceWastedFromPackagingPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_01889_MinimumSpaceWastedFromPackagingPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _01889_MinimumSpaceWastedFromPackaging.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01889_MinimumSpaceWastedFromPackagingPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _01889_MinimumSpaceWastedFromPackaging.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
