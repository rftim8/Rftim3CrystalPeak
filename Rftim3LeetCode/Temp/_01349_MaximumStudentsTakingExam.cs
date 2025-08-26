namespace Rftim3LeetCode.Temp
{
    public class _01349_MaximumStudentsTakingExam
    {
        /// <summary>
        /// Given a m* n matrix seats  that represent seats distributions in a classroom.
        /// If a seat is broken, it is denoted by '#' character otherwise it is denoted by a '.' character.
        /// 
        /// Students can see the answers of those sitting next to the left, right, upper left and upper right, 
        /// but he cannot see the answers of the student sitting directly in front or behind him. 
        /// Return the maximum number of students that can take the exam together without any cheating being possible.
        /// 
        /// Students must be placed in seats in good condition.
        /// </summary>
        public _01349_MaximumStudentsTakingExam()
        {
            Console.WriteLine(MaximumStudentsTakingExam0
                (
                    [
                        ['#', '.', '#', '#', '.', '#'],
                        ['.', '#', '#', '#', '#', '.'],
                        ['#', '.', '#', '#', '.', '#']
                    ]
                ));

            Console.WriteLine(MaximumStudentsTakingExam0
                (
                    [
                        ['.', '#'],
                        ['#', '#'],
                        ['#', '.'],
                        ['#', '#'],
                        ['.', '#']
                    ]
                ));

            Console.WriteLine(MaximumStudentsTakingExam0
                (
                    [
                        ['#', '.', '.', '.', '#'],
                        ['.', '#', '.', '#', '.'],
                        ['.', '.', '#', '.', '.'],
                        ['.', '#', '.', '#', '.'],
                        ['#', '.', '.', '.', '#']
                    ]
                ));
        }

        public static int MaximumStudentsTakingExam0(char[][] a0) => RftMaximumStudentsTakingExam0(a0);

        public static int MaximumStudentsTakingExam1(char[][] a0) => RftMaximumStudentsTakingExam1(a0);

        public static int MaximumStudentsTakingExam2(char[][] a0) => RftMaximumStudentsTakingExam2(a0);

        private static int RftMaximumStudentsTakingExam0(char[][] seats)
        {
            int rows = seats.Length;
            int columns = seats[0].Length;
            List<int> validity = [];
            for (int i = 0; i < rows; i++)
            {
                int cur = 0;
                for (int j = 0; j < columns; j++)
                {
                    cur = cur * 2 + (seats[i][j] == '.' ? 1 : 0);
                }
                validity.Add(cur);
            }

            int maxStates = 1 << columns;
            int[,] f = new int[rows + 1, maxStates];
            f[0, 0] = 0;
            int max = int.MinValue;
            int[] bitCount = new int[maxStates];

            for (int i = 1; i <= rows; i++)
            {
                int valid = validity[i - 1];

                for (int j = 0; j < maxStates; j++)
                {
                    f[i, j] = -1;
                    bitCount[j] = bitCount[j / 2] + j % 2;

                    if ((j & valid) == j && (j & j >> 1) == 0)
                    {
                        for (int k = 0; k < maxStates; k++)
                        {
                            if ((j & k >> 1) == 0 && (j & k << 1) == 0 && f[i - 1, k] != -1)
                            {
                                f[i, j] = Math.Max(f[i, j], f[i - 1, k] + bitCount[j]);
                                max = Math.Max(max, f[i, j]);
                            }
                        }
                    }
                }
            }

            return max;
        }

        private static int RftMaximumStudentsTakingExam1(char[][] seats)
        {
            Dictionary<string, int> dic = [];

            return Dfs(0, 0, seats, dic);
        }

        private static int Dfs(int i, int j, char[][] seats, Dictionary<string, int> dic)
        {
            int n = seats.Length;
            int m = seats[0].Length;

            if (j == m)
            {
                string key = $"{i}_{new string(seats[i])}";

                if (dic.TryGetValue(key, out int value)) return value;

                dic[key] = Dfs(i + 1, 0, seats, dic);

                return dic[key];
            }

            if (i == n) return 0;

            char c = seats[i][j];

            int res = 0;

            res = Math.Max(res, Dfs(i, j + 1, seats, dic));

            if (c == '.'
                && (j == 0 || seats[i][j - 1] != 'p')
                && (j == 0 || i == 0 || seats[i - 1][j - 1] != 'p')
                && (j == m - 1 || i == 0 || seats[i - 1][j + 1] != 'p'))
            {
                seats[i][j] = 'p';
                res = Math.Max(res, 1 + Dfs(i, j + 1, seats, dic));
                seats[i][j] = '.';
            }

            return res;
        }

        private static int RftMaximumStudentsTakingExam2(char[][] seats)
        {
            int r = seats.Length;
            int c = seats[0].Length;
            Dictionary<int, int>[] map = new Dictionary<int, int>[r];
            for (int i = 0; i < r; i++)
            {
                map[i] = [];
            }

            int dfs(int row, int prevmask)
            {
                if (row == r) return 0;
                if (map[row].TryGetValue(prevmask, out int value)) return value;

                List<(int, int)> masks = [(0, 0)];
                List<(int, int)> next = [];
                for (int i = 0; i < c; i++)
                {
                    foreach ((int, int) mask in masks)
                    {
                        if (seats[row][i] == '.' && (prevmask & 1 << i) == 0 && (prevmask & 1 << i + 2) == 0 && (mask.Item1 & 1 << i) == 0)
                        {
                            int addmask = mask.Item1 + (1 << i + 1);
                            next.Add((addmask, mask.Item2 + 1));
                            next.Add((mask.Item1, mask.Item2));
                        }
                        else next.Add((mask.Item1, mask.Item2));
                    }
                    masks = next;
                    next = [];
                }

                int ans = 0;
                foreach ((int, int) mask in masks)
                {
                    ans = Math.Max(ans, mask.Item2 + dfs(row + 1, mask.Item1));
                }
                map[row].Add(prevmask, ans);

                return ans;
            }

            return dfs(0, 0);
        }
    }
}
