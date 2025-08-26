using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _01628_DesignanExpressionTreeWithEvaluateFunction_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_01628_DesignanExpressionTreeWithEvaluateFunction))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01628_DesignanExpressionTreeWithEvaluateFunction))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01628_DesignanExpressionTreeWithEvaluateFunction))![1]);

        public static TheoryData<List<string>, int> _01628_DesignanExpressionTreeWithEvaluateFunctionPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _01628_DesignanExpressionTreeWithEvaluateFunctionPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_01628_DesignanExpressionTreeWithEvaluateFunctionPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _01628_DesignanExpressionTreeWithEvaluateFunction.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01628_DesignanExpressionTreeWithEvaluateFunctionPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _01628_DesignanExpressionTreeWithEvaluateFunction.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
