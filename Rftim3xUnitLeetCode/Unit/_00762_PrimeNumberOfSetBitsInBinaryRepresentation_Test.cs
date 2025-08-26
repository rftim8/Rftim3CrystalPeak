using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _00762_PrimeNumberOfSetBitsInBinaryRepresentation_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_00762_PrimeNumberOfSetBitsInBinaryRepresentation))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_00762_PrimeNumberOfSetBitsInBinaryRepresentation))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_00762_PrimeNumberOfSetBitsInBinaryRepresentation))![1]);

        public static TheoryData<List<string>, int> _00762_PrimeNumberOfSetBitsInBinaryRepresentationPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _00762_PrimeNumberOfSetBitsInBinaryRepresentationPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_00762_PrimeNumberOfSetBitsInBinaryRepresentationPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _00762_PrimeNumberOfSetBitsInBinaryRepresentation.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00762_PrimeNumberOfSetBitsInBinaryRepresentationPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _00762_PrimeNumberOfSetBitsInBinaryRepresentation.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
