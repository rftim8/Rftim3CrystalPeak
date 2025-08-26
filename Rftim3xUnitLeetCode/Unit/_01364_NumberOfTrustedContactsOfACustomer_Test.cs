using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _01364_NumberOfTrustedContactsOfACustomer_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_01364_NumberOfTrustedContactsOfACustomer))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01364_NumberOfTrustedContactsOfACustomer))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01364_NumberOfTrustedContactsOfACustomer))![1]);

        public static TheoryData<List<string>, int> _01364_NumberOfTrustedContactsOfACustomerPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _01364_NumberOfTrustedContactsOfACustomerPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_01364_NumberOfTrustedContactsOfACustomerPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _01364_NumberOfTrustedContactsOfACustomer.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01364_NumberOfTrustedContactsOfACustomerPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _01364_NumberOfTrustedContactsOfACustomer.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
