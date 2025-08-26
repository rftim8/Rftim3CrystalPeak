namespace Rftim3CodinGame.Refactor.Puzzles
{
    public class YouAreTheFatherMauryPovichStyle
    {
        /// <summary>
        /// ~ ~ ~ P o p   C u l t u r e   B a c k g r o u n d ~ ~ ~
        /// 
        /// Maury Povich hosted a popular talk show in America for decades.
        /// A famous and common theme for an episode was helping a new mom figure out which of her past "gentleman callers" is her child's biological father. 
        /// Maury’s staff would swab and paternity-test a sample from each possible man and then Maury would announce with much fanfare
        /// either "You are NOT the father!" or "You ARE the father!"
        /// 
        /// (For your amusement only, see banner image and video link far below for clips of that; it isn't needed to solve this puzzle.)
        /// 
        /// ~ ~ ~B i o l o g y   B a c k g r o u n d ~ ~ ~
        ///         Every creature has multiple "Pairs of Chromosomes," henceforth called chromPairs.
        /// 
        /// For each chromPair,
        /// Mother and Father each contribute 1 chromosome to form the child's chromPair.
        /// 
        /// In the very simplified world of this puzzle, a chromosome is simply 1 character and a chromPair is simply 2 characters.
        /// 
        /// ~ ~ ~E x a m p l e ~ ~ ~
        /// 
        /// The species has 2 chromPairs.
        /// Mother is: ab cd
        /// Father is: wx yz
        /// 
        /// Their child is created by having:
        /// ‣ 1 of ab plus 1 of wx for its 1st chromPair, and
        /// ‣ 1 of cd plus 1 of yz for its 2nd chromPair.
        /// 
        /// So the child could be: aw cy or bw cz...or any of 14 other combinations.
        /// 
        /// However, their child cannot be:
        /// ‣ aq cy ... because q is not a chromosome from either parent.
        /// ‣ ab cy ... because it doesn't have anything from Father's 1st chromPair.
        /// ‣ az cy ... because even though Father has z, it's not in his 1st chromPair.
        /// 
        /// NOTE: Order in chromPair doesn't matter: aw is exactly equal to wa.
        /// 
        /// ~ ~ ~Y o u r T a s k ~ ~ ~
        /// 
        /// Given the above rules, help Maury Povich tell each single mother who the actualFather of her child is.
        /// </summary>
        public YouAreTheFatherMauryPovichStyle()
        {
            string mother = "Mother Julie:        Uj $7";
            string child = "Child Brandon:       Wj =$";

            List<string> fathers = [
                "Garrett:             #; wc",
                "Macallister:         P2 zv",
                "Jeffrey:             KI J&",
                "Scott:               WW :=",
                "Angus:               Xm N1"
            ];

            Console.WriteLine(RftSolve(mother, child, fathers));
        }

        public static string RftSolve(string mother, string child, List<string> fathers)
        {
            List<string> pairm = [.. mother.Split(":   ")[1].Split(' ', StringSplitOptions.RemoveEmptyEntries)];
            List<string> pairc = [.. child.Split(":   ")[1].Split(' ', StringSplitOptions.RemoveEmptyEntries)];

            Dictionary<string, int> kvp = [];

            foreach (string item in fathers)
            {
                string name = item.Split(':')[0];
                List<string> pairf = [.. item.Split(":   ")[1].Split(' ', StringSplitOptions.RemoveEmptyEntries)];
                for (int i = 0; i < pairf.Count - 1; i++)
                {

                    if ((pairf[i][0] == pairc[i][0] && pairm[i].Contains(pairc[i][1]) ||
                        pairf[i][0] == pairc[i][1] && pairm[i].Contains(pairc[i][0]) ||
                        pairf[i][1] == pairc[i][0] && pairm[i].Contains(pairc[i][1]) ||
                        pairf[i][1] == pairc[i][1] && pairm[i].Contains(pairc[i][0]))
                        &&
                        (pairf[i + 1][0] == pairc[i + 1][0] && pairm[i + 1].Contains(pairc[i + 1][1]) ||
                        pairf[i + 1][0] == pairc[i + 1][1] && pairm[i + 1].Contains(pairc[i + 1][0]) ||
                        pairf[i + 1][1] == pairc[i + 1][0] && pairm[i + 1].Contains(pairc[i + 1][1]) ||
                        pairf[i + 1][1] == pairc[i + 1][1] && pairm[i + 1].Contains(pairc[i + 1][0])))
                    {
                        if (kvp.TryGetValue(name, out int value)) kvp[name] = ++value;
                        else kvp[name] = 1;
                    }
                }
            }
            return $"{kvp.MaxBy(o => o.Value).Key}, you are the father!";
        }
    }
}
