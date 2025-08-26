namespace Rftim3LeetCode.Temp
{
    public class _02383_MinimumHoursOfTrainingToWinACompetition
    {
        /// <summary>
        /// You are entering a competition, and are given two positive integers initialEnergy and initialExperience denoting your initial energy and initial experience respectively.
        /// You are also given two 0-indexed integer arrays energy and experience, both of length n.
        /// You will face n opponents in order.The energy and experience of the ith opponent is denoted by energy[i] and experience[i] respectively.
        /// When you face an opponent, you need to have both strictly greater experience and energy to defeat them and move to the next opponent if available.
        /// Defeating the ith opponent increases your experience by experience[i], but decreases your energy by energy[i].
        /// Before starting the competition, you can train for some number of hours. 
        /// After each hour of training, you can either choose to increase your initial experience by one, or increase your initial energy by one.
        /// Return the minimum number of training hours required to defeat all n opponents.
        /// </summary>
        public _02383_MinimumHoursOfTrainingToWinACompetition()
        {
            Console.WriteLine(MinNumberOfHours(5, 3, [1, 4, 3, 2], [2, 6, 3, 1]));
            Console.WriteLine(MinNumberOfHours(2, 4, [1], [3]));
        }

        private static int MinNumberOfHours(int initialEnergy, int initialExperience, int[] energy, int[] experience)
        {
            int res = 0;
            int totalEnergyNeed = energy.Sum() + 1;
            res += totalEnergyNeed <= initialEnergy ? 0 : totalEnergyNeed - initialEnergy;

            for (int i = 0; i < energy.Length; i++)
            {
                if (experience[i] >= initialExperience)
                {
                    res += experience[i] - initialExperience + 1;
                    initialExperience = experience[i] + 1;
                }

                initialExperience += experience[i];
            }

            return res;
        }

        private static int MinNumberOfHours0(int initialEnergy, int initialExperience, int[] energy, int[] experience)
        {
            int missing = 0;

            for (int i = 0; i < energy.Length; i++)
            {
                if (initialEnergy <= energy[i])
                {
                    missing += energy[i] - initialEnergy + 1;
                    initialEnergy = energy[i] + 1;
                }
                if (initialExperience <= experience[i])
                {
                    missing += experience[i] - initialExperience + 1;
                    initialExperience = experience[i] + 1;
                }
                initialEnergy -= energy[i];
                initialExperience += experience[i];
            }

            return missing;
        }
    }
}
