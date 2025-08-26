using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _01170_CompareStringsByFrequencyOfTheSmallestCharacter_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_01170_CompareStringsByFrequencyOfTheSmallestCharacter))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01170_CompareStringsByFrequencyOfTheSmallestCharacter))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01170_CompareStringsByFrequencyOfTheSmallestCharacter))![1]);

        public static TheoryData<List<string>, int> _01170_CompareStringsByFrequencyOfTheSmallestCharacterPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _01170_CompareStringsByFrequencyOfTheSmallestCharacterPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_01170_CompareStringsByFrequencyOfTheSmallestCharacterPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _01170_CompareStringsByFrequencyOfTheSmallestCharacter.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01170_CompareStringsByFrequencyOfTheSmallestCharacterPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _01170_CompareStringsByFrequencyOfTheSmallestCharacter.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
