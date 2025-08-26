using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00790_DominoAndTrominoTiling_Test
    {
        // Arrange
        private static readonly int a0 = 3;
        private static readonly int ar = 5;

        private static readonly int b0 = 1;
        private static readonly int br = 1;

        public static TheoryData<int, int> _00790_DominoAndTrominoTiling_Data =>
            new()
            {
                { a0, ar },
                { b0, br }
            };

        [Theory]
        [MemberData(nameof(_00790_DominoAndTrominoTiling_Data))]
        public void DominoAndTrominoTiling0(int a0, int expected)
        {
            // Act
            int actual = _00790_DominoAndTrominoTiling.DominoAndTrominoTiling0(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00790_DominoAndTrominoTiling_Data))]
        public void DominoAndTrominoTiling1(int a0, int expected)
        {
            // Act
            int actual = _00790_DominoAndTrominoTiling.DominoAndTrominoTiling1(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00790_DominoAndTrominoTiling_Data))]
        public void DominoAndTrominoTiling2(int a0, int expected)
        {
            // Act
            int actual = _00790_DominoAndTrominoTiling.DominoAndTrominoTiling2(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00790_DominoAndTrominoTiling_Data))]
        public void DominoAndTrominoTiling3(int a0, int expected)
        {
            // Act
            int actual = _00790_DominoAndTrominoTiling.DominoAndTrominoTiling3(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00790_DominoAndTrominoTiling_Data))]
        public void DominoAndTrominoTiling4(int a0, int expected)
        {
            // Act
            int actual = _00790_DominoAndTrominoTiling.DominoAndTrominoTiling4(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00790_DominoAndTrominoTiling_Data))]
        public void DominoAndTrominoTiling5(int a0, int expected)
        {
            // Act
            int actual = _00790_DominoAndTrominoTiling.DominoAndTrominoTiling5(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00790_DominoAndTrominoTiling_Data))]
        public void DominoAndTrominoTiling6(int a0, int expected)
        {
            // Act
            int actual = _00790_DominoAndTrominoTiling.DominoAndTrominoTiling6(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}