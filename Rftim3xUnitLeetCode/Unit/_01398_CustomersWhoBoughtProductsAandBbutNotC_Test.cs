using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _01398_CustomersWhoBoughtProductsAandBbutNotC_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_01398_CustomersWhoBoughtProductsAandBbutNotC))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01398_CustomersWhoBoughtProductsAandBbutNotC))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01398_CustomersWhoBoughtProductsAandBbutNotC))![1]);

        public static TheoryData<List<string>, int> _01398_CustomersWhoBoughtProductsAandBbutNotCPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _01398_CustomersWhoBoughtProductsAandBbutNotCPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_01398_CustomersWhoBoughtProductsAandBbutNotCPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _01398_CustomersWhoBoughtProductsAandBbutNotC.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01398_CustomersWhoBoughtProductsAandBbutNotCPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _01398_CustomersWhoBoughtProductsAandBbutNotC.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
