using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00412_FizzBuzz_Test
    {
        // Arrange
        private static readonly int a0 = 3;
        private static readonly string[] ar = ["1", "2", "Fizz"];

        private static readonly int b0 = 5;
        private static readonly string[] br = ["1", "2", "Fizz", "4", "Buzz"];

        private static readonly int c0 = 15;
        private static readonly string[] cr = ["1", "2", "Fizz", "4", "Buzz", "Fizz", "7", "8", "Fizz", "Buzz", "11", "Fizz", "13", "14", "FizzBuzz"];

        public static TheoryData<int, string[]> _00412_FizzBuzz_Data =>
            new()
            {
                { a0, ar },
                { b0, br },
                { c0, cr }
            };

        [Theory]
        [MemberData(nameof(_00412_FizzBuzz_Data))]
        public void FizzBuzz0(int n, string[] expected)
        {
            // Act
            IList<string> actual = _00412_FizzBuzz.FizzBuzz0(n);

            // Assert
            //Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00412_FizzBuzz_Data))]
        public void FizzBuzz1(int n, string[] expected)
        {
            // Act
            IList<string> actual = _00412_FizzBuzz.FizzBuzz1(n);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
