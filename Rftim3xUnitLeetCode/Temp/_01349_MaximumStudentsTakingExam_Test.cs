using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _01349_MaximumStudentsTakingExam_Test
    {
        // Arrange
        private static readonly char[][] a0 =
            [
                ['#', '.', '#', '#', '.', '#'],
                ['.', '#', '#', '#', '#', '.'],
                ['#', '.', '#', '#', '.', '#']
            ];
        private static readonly int ar = 4;

        private static readonly char[][] b0 =
            [
                ['.', '#'],
                ['#', '#'],
                ['#', '.'],
                ['#', '#'],
                ['.', '#']
            ];
        private static readonly int br = 3;

        private static readonly char[][] c0 =
            [
                ['#', '.', '.', '.', '#'],
                ['.', '#', '.', '#', '.'],
                ['.', '.', '#', '.', '.'],
                ['.', '#', '.', '#', '.'],
                ['#', '.', '.', '.', '#']
            ];
        private static readonly int cr = 10;

        public static TheoryData<char[][], int> _01349_MaximumStudentsTakingExam_Data =>
            new()
            {
                { a0, ar },
                { b0, br },
                { c0, cr }
            };


        [Theory]
        [MemberData(nameof(_01349_MaximumStudentsTakingExam_Data))]
        public void MaximumStudentsTakingExam0(char[][] a0, int expected)
        {
            // Act
            int actual = _01349_MaximumStudentsTakingExam.MaximumStudentsTakingExam0(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01349_MaximumStudentsTakingExam_Data))]
        public void MaximumStudentsTakingExam1(char[][] a0, int expected)
        {
            // Act
            int actual = _01349_MaximumStudentsTakingExam.MaximumStudentsTakingExam1(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01349_MaximumStudentsTakingExam_Data))]
        public void MaximumStudentsTakingExam2(char[][] a0, int expected)
        {
            // Act
            int actual = _01349_MaximumStudentsTakingExam.MaximumStudentsTakingExam2(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}