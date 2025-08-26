using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _01125_SmallestSufficientTeam
    {
        /// <summary>
        /// In a project, you have a list of required skills req_skills, and a list of people. 
        /// The ith person people[i] contains a list of skills that the person has.
        /// Consider a sufficient team: a set of people such that for every required skill in req_skills, 
        /// there is at least one person in the team who has that skill.
        /// We can represent these teams by the index of each person.
        /// For example, team = [0, 1, 3] represents the people with skills people[0], people[1], and people[3].
        /// Return any sufficient team of the smallest possible size, represented by the index of each person.
        /// You may return the answer in any order.
        /// It is guaranteed an answer exists.
        /// </summary>
        public _01125_SmallestSufficientTeam()
        {
            int[]? x = SmallestSufficientTeam(
                ["java", "nodejs", "reactjs"], [["java"], ["nodejs"], ["nodejs", "reactjs"]]
                );

            int[]? y = SmallestSufficientTeam(
                ["algorithms", "math", "java", "reactjs", "csharp", "aws"],
                [
                    [ "algorithms","math","java" ],
                    [ "algorithms","math","reactjs" ],
                    [ "java","csharp","aws" ],
                    [ "reactjs","csharp" ],
                    [ "csharp","math" ],
                    [ "aws", "java" ]
                ]
                );

            RftTerminal.RftReadResult(x);
            RftTerminal.RftReadResult(y);
        }

        // Bottom-up DP with Bitmasks
        private static int[] SmallestSufficientTeam(string[] req_skills, IList<IList<string>> people)
        {
            int n = people.Count, m = req_skills.Length;
            Dictionary<string, int> skillId = [];
            for (int i = 0; i < m; i++)
            {
                skillId.Add(req_skills[i], i);
            }

            int[]? skillsMaskOfPerson = new int[n];
            for (int i = 0; i < n; i++)
            {
                foreach (string skill in people[i])
                {
                    skillsMaskOfPerson[i] |= 1 << skillId[skill];
                }
            }

            long[]? dp = new long[1 << m];
            Array.Fill(dp, (1L << n) - 1);
            dp[0] = 0;
            for (int skillsMask = 1; skillsMask < 1 << m; skillsMask++)
            {
                for (int i = 0; i < n; i++)
                {
                    int smallerSkillsMask = skillsMask & ~skillsMaskOfPerson[i];
                    if (smallerSkillsMask != skillsMask)
                    {
                        long peopleMask = dp[smallerSkillsMask] | 1L << i;

                        if (CountBits(peopleMask) < CountBits(dp[skillsMask]))
                        {
                            dp[skillsMask] = peopleMask;
                        }
                    }
                }
            }

            long answerMask = dp[(1 << m) - 1];
            int[]? ans = new int[CountBits(answerMask)];
            int ptr = 0;
            for (int i = 0; i < n; i++)
            {
                if ((answerMask >> i & 1) == 1)
                {
                    ans[ptr++] = i;
                }
            }

            return ans;
        }

        private static int CountBits(long x)
        {
            int y = 0;
            while (x != 0)
            {
                x &= x - 1;
                y++;
            }

            return y;
        }

        // Top-down DP + Memoization
        private static int n;
        private static int[]? skillsMaskOfPerson;
        private static long[]? dp;

        private static long F(int skillsMask)
        {
            if (skillsMask == 0) return 0L;

            if (dp![skillsMask] != -1) return dp[skillsMask];

            for (int i = 0; i < n; i++)
            {
                int smallerSkillsMask = skillsMask & ~skillsMaskOfPerson![i];
                if (smallerSkillsMask != skillsMask)
                {
                    long peopleMask = F(smallerSkillsMask) | 1L << i;

                    if (dp[skillsMask] == -1 || CountBits(peopleMask) < CountBits(dp[skillsMask])) dp[skillsMask] = peopleMask;
                }
            }

            return dp[skillsMask];
        }

        private static int[] SmallestSufficientTeam0(string[] req_skills, IList<IList<string>> people)
        {
            n = people.Count;
            int m = req_skills.Length;
            Dictionary<string, int> skillId = [];
            for (int i = 0; i < m; i++)
            {
                skillId.Add(req_skills[i], i);
            }

            skillsMaskOfPerson = new int[n];
            for (int i = 0; i < n; i++)
            {
                foreach (string skill in people[i])
                {
                    skillsMaskOfPerson[i] |= 1 << skillId[skill];
                }
            }

            dp = new long[1 << m];
            Array.Fill(dp, -1);
            long answerMask = F((1 << m) - 1);
            int[]? ans = new int[CountBits(answerMask)];
            int ptr = 0;
            for (int i = 0; i < n; i++)
            {
                if ((answerMask >> i & 1) == 1) ans[ptr++] = i;
            }

            return ans;
        }
    }
}
