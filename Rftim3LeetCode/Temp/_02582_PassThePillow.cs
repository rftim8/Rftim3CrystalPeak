namespace Rftim3LeetCode.Temp
{
    public class _02582_PassThePillow
    {
        /// <summary>
        /// There are n people standing in a line labeled from 1 to n. The first person in the line is holding a pillow initially. 
        /// Every second, the person holding the pillow passes it to the next person standing in the line. 
        /// Once the pillow reaches the end of the line, the direction changes, and people continue passing the pillow in the opposite direction.
        /// For example, once the pillow reaches the nth person they pass it to the n - 1th person, then to the n - 2th person and so on.
        /// Given the two positive integers n and time, return the index of the person holding the pillow after time seconds.
        /// </summary>
        public _02582_PassThePillow()
        {
            Console.WriteLine(PassThePillow(4, 5));
            Console.WriteLine(PassThePillow(3, 2));
            Console.WriteLine(PassThePillow(18, 38));
        }

        private static int PassThePillow(int n, int time)
        {
            int j = 1;
            bool up = true;
            for (int i = 1; i <= time; i++)
            {
                if (up && j == n) up = false;
                if (!up && j == 1) up = true;

                if (up) j++;
                else j--;
            }

            return j;
        }
    }
}
