using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _02092_FindAllPeopleWithSecret_Test
    {
        // Arrange
        private static readonly int a0 = 6;
        private static readonly int[][] a1 = [[1, 2, 5], [2, 3, 8], [1, 5, 10]];
        private static readonly int a2 = 1;
        private static readonly List<int> ar = [0, 1, 2, 3, 5];

        private static readonly int b0 = 4;
        private static readonly int[][] b1 = [[3, 1, 3], [1, 2, 2], [0, 3, 3]];
        private static readonly int b2 = 3;
        private static readonly List<int> br = [0, 1, 3];

        private static readonly int c0 = 5;
        private static readonly int[][] c1 = [[3, 4, 2], [1, 2, 1], [2, 3, 1]];
        private static readonly int c2 = 1;
        private static readonly List<int> cr = [0, 1, 2, 3, 4];

        public static TheoryData<int, int[][], int, List<int>> _02092_FindAllPeopleWithSecret_Data =>
            new()
            {
                { a0, a1, a2, ar },
                { b0, b1, b2, br },
                { c0, c1, c2, cr }
            };


        [Theory]
        [MemberData(nameof(_02092_FindAllPeopleWithSecret_Data))]
        public void FindAllPeopleWithSecret0(int a0, int[][] a1, int a2, List<int> expected)
        {
            // Act
            IList<int> actual = _02092_FindAllPeopleWithSecret.FindAllPeopleWithSecret0(a0, a1, a2);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02092_FindAllPeopleWithSecret_Data))]
        public void FindAllPeopleWithSecret1(int a0, int[][] a1, int a2, List<int> expected)
        {
            // Act
            IList<int> actual = _02092_FindAllPeopleWithSecret.FindAllPeopleWithSecret1(a0, a1, a2);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02092_FindAllPeopleWithSecret_Data))]
        public void FindAllPeopleWithSecret2(int a0, int[][] a1, int a2, List<int> expected)
        {
            // Act
            IList<int> actual = _02092_FindAllPeopleWithSecret.FindAllPeopleWithSecret2(a0, a1, a2);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02092_FindAllPeopleWithSecret_Data))]
        public void FindAllPeopleWithSecret3(int a0, int[][] a1, int a2, List<int> expected)
        {
            // Act
            IList<int> actual = _02092_FindAllPeopleWithSecret.FindAllPeopleWithSecret3(a0, a1, a2);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02092_FindAllPeopleWithSecret_Data))]
        public void FindAllPeopleWithSecret4(int a0, int[][] a1, int a2, List<int> expected)
        {
            // Act
            IList<int> actual = _02092_FindAllPeopleWithSecret.FindAllPeopleWithSecret4(a0, a1, a2);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02092_FindAllPeopleWithSecret_Data))]
        public void FindAllPeopleWithSecret5(int a0, int[][] a1, int a2, List<int> expected)
        {
            // Act
            IList<int> actual = _02092_FindAllPeopleWithSecret.FindAllPeopleWithSecret5(a0, a1, a2);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}