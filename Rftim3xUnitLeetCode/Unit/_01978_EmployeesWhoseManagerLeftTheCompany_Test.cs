using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _01978_EmployeesWhoseManagerLeftTheCompany_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_01978_EmployeesWhoseManagerLeftTheCompany))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01978_EmployeesWhoseManagerLeftTheCompany))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01978_EmployeesWhoseManagerLeftTheCompany))![1]);

        public static TheoryData<List<string>, int> _01978_EmployeesWhoseManagerLeftTheCompanyPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _01978_EmployeesWhoseManagerLeftTheCompanyPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_01978_EmployeesWhoseManagerLeftTheCompanyPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _01978_EmployeesWhoseManagerLeftTheCompany.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01978_EmployeesWhoseManagerLeftTheCompanyPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _01978_EmployeesWhoseManagerLeftTheCompany.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
