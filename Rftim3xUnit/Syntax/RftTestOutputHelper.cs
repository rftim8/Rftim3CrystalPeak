using Xunit.Abstractions;

namespace Rftim3xUnit.Syntax
{
    public class RftTestOutputHelper(ITestOutputHelper testOutputHelper)
    {
        [Theory]
        [InlineData(1, 2)]
        public void RftTest(int x, int y)
        {
            for (int i = 0; i < 10; i++)
            {
                testOutputHelper.WriteLine($"{x} {y}");
            }
        }
    }
}
