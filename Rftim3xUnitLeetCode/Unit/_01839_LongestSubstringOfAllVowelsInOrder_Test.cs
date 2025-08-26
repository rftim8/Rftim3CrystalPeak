using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _01839_LongestSubstringOfAllVowelsInOrder_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_01839_LongestSubstringOfAllVowelsInOrder))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01839_LongestSubstringOfAllVowelsInOrder))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01839_LongestSubstringOfAllVowelsInOrder))![1]);

        public static TheoryData<List<string>, int> _01839_LongestSubstringOfAllVowelsInOrderPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _01839_LongestSubstringOfAllVowelsInOrderPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_01839_LongestSubstringOfAllVowelsInOrderPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _01839_LongestSubstringOfAllVowelsInOrder.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01839_LongestSubstringOfAllVowelsInOrderPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _01839_LongestSubstringOfAllVowelsInOrder.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
