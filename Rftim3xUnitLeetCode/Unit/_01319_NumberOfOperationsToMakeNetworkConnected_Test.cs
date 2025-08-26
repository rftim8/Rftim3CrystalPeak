using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _01319_NumberOfOperationsToMakeNetworkConnected_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_01319_NumberOfOperationsToMakeNetworkConnected))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01319_NumberOfOperationsToMakeNetworkConnected))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01319_NumberOfOperationsToMakeNetworkConnected))![1]);

        public static TheoryData<List<string>, int> _01319_NumberOfOperationsToMakeNetworkConnectedPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _01319_NumberOfOperationsToMakeNetworkConnectedPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_01319_NumberOfOperationsToMakeNetworkConnectedPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _01319_NumberOfOperationsToMakeNetworkConnected.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01319_NumberOfOperationsToMakeNetworkConnectedPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _01319_NumberOfOperationsToMakeNetworkConnected.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
