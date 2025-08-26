namespace Rftim3LeetCode.Temp
{
    public class _01854_MaximumPopulationYear
    {
        /// <summary>
        /// You are given a 2D integer array logs where each logs[i] = [birthi, deathi] indicates the birth and death years of the ith person.
        /// The population of some year x is the number of people alive during that year.
        /// The ith person is counted in year x's population if x is in the inclusive range [birthi, deathi - 1].
        /// Note that the person is not counted in the year that they die.
        /// Return the earliest year with the maximum population.
        /// </summary>
        public _01854_MaximumPopulationYear()
        {
            Console.WriteLine(MaximumPopulation(
            [
                [1993, 1999],
                [2000, 2010]
            ]));
            Console.WriteLine(MaximumPopulation(
            [
                [1950, 1961],
                [1960, 1971],
                [1970, 1981]
            ]));
        }

        private static int MaximumPopulation(int[][] logs)
        {
            int n = logs.Length;
            int[] births = new int[n];
            int[] deaths = new int[n];

            for (int i = 0; i < n; i++)
            {
                births[i] = logs[i][0];
                deaths[i] = logs[i][1];
            }

            Array.Sort(births);
            Array.Sort(deaths);

            int currentPopulation = 0;
            int deathIndex = 0;
            int maxPopulation = 0;
            int maxYear = 0;

            for (int i = 0; i < n; i++)
            {
                currentPopulation++;
                while (deaths[deathIndex] <= births[i])
                {
                    currentPopulation--;
                    deathIndex++;
                }
                if (currentPopulation > maxPopulation)
                {
                    maxPopulation = currentPopulation;
                    maxYear = births[i];
                }
            }

            return maxYear;
        }
    }
}
