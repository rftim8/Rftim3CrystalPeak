namespace Rftim3LeetCode.Temp
{
    public class _02798_NumberOfEmployeesWhoMetTheTarget
    {
        /// <summary>
        /// There are n employees in a company, numbered from 0 to n - 1. 
        /// Each employee i has worked for hours[i] hours in the company.
        /// The company requires each employee to work for at least target hours.
        /// You are given a 0-indexed array of non-negative integers hours of length n and a non-negative integer target.
        /// Return the integer denoting the number of employees who worked at least target hours.
        /// </summary>
        public _02798_NumberOfEmployeesWhoMetTheTarget()
        {
            Console.WriteLine(NumberOfEmployeesWhoMetTarget([0, 1, 2, 3, 4], 2));
            Console.WriteLine(NumberOfEmployeesWhoMetTarget([5, 1, 4, 2, 2], 6));
            Console.WriteLine(NumberOfEmployeesWhoMetTarget([98], 5));
        }

        private static int NumberOfEmployeesWhoMetTarget(int[] hours, int target)
        {
            return hours.Where(o => o >= target).Count();
        }

        private static int NumberOfEmployeesWhoMetTarget0(int[] hours, int target)
        {
            int k = 0;
            for (int i = 0; i < hours.Length; i++)
            {
                if (hours[i] >= target) k++;
            }

            return k;
        }
    }
}
