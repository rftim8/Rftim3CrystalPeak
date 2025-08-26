using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _01409_QueriesonaPermutationWithKey_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_01409_QueriesonaPermutationWithKey))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01409_QueriesonaPermutationWithKey))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01409_QueriesonaPermutationWithKey))![1]);

        public static TheoryData<List<string>, int> _01409_QueriesonaPermutationWithKeyPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _01409_QueriesonaPermutationWithKeyPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_01409_QueriesonaPermutationWithKeyPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _01409_QueriesonaPermutationWithKey.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01409_QueriesonaPermutationWithKeyPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _01409_QueriesonaPermutationWithKey.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
