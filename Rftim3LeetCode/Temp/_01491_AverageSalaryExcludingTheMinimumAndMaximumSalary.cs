namespace Rftim3LeetCode.Temp
{
    public class _01491_AverageSalaryExcludingTheMinimumAndMaximumSalary
    {
        /// <summary>
        /// You are given an array of unique integers salary where salary[i] is the salary of the ith employee.
        /// Return the average salary of employees excluding the minimum and maximum salary.
        /// Answers within 10-5 of the actual answer will be accepted.
        /// </summary>
        public _01491_AverageSalaryExcludingTheMinimumAndMaximumSalary()
        {
            Console.WriteLine(Average(new int[] { 4000, 3000, 1000, 2000 }));
            Console.WriteLine(Average(new int[] { 1000, 2000, 3000 }));
        }

        private static double Average(int[] salary)
        {
            int n = salary.Length;
            Array.Sort(salary);

            double x = 0;
            for (int i = 1; i < n - 1; i++)
            {
                x += salary[i];
            }

            return x / (n - 2);
        }
    }
}
