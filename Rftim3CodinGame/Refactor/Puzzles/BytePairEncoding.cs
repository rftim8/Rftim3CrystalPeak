namespace Rftim3CodinGame.Refactor.Puzzles
{
    public class BytePairEncoding
    {
        public BytePairEncoding()
        {
            //int n = 1;
            //int n = 2;
            //int n = 4;
            //int m = 11;
            //int m = 10;
            //int m = 10;

            //List<string> x = new List<string>() {
            //    "aaabdaaabac"
            //};

            //List<string> x = new List<string>() {
            //    "aedcaafffb",
            //    "ddcaaacdcd"
            //};

            //List<string> x = new List<string>() {
            //    "aaaaaaaaaa",
            //    "aaaaabbbbb",
            //    "bbbbbbbbbb",
            //    "cccccccccc"
            //};

            List<string> x = new()
            {
                "cdeaafdhhh",
                "cdecbfcbhf",
                "hdhhccfhed",
                "eadggchefh",
                "gcaffgdcag",
                "dfedaghgce",
                "afbdccegbf",
                "ggafhdffbh",
                "ahgadeabcc",
                "abhfgeceff"
            };

            Solve(x);
        }

        private static void Solve(List<string> x)
        {
            string alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string temp = "";

            for (int i = 0; i < x.Count; i++)
            {
                temp += x[i];
            }

            List<KeyValuePairs> keyValuePairs = new();

            int maxValue = 2;

            while (maxValue > 1)
            {
                List<Pairs> pairs = new();
                string pair = "";

                for (int i = 0; i < temp.Length - 1; i++)
                {
                    pair = temp.Substring(i, 2);
                    bool already = false;

                    for (int j = 0; j < pairs.Count; j++)
                    {
                        if (pairs[j].pair == pair) already = true;
                    }

                    if (!already) pairs.Add(new Pairs(pair, 0, i));
                }

                for (int i = 0; i < pairs.Count; i++)
                {
                    int z = temp.Split(new string[] { pairs[i].pair }, StringSplitOptions.None).Length;
                    pairs[i].count = z - 1;
                }

                pairs = pairs.OrderByDescending(a => a.count).ThenBy(a => a.appear).ToList();

                if (pairs[0].count > 1)
                {
                    temp = temp.Replace(pairs[0].pair, alpha.Last().ToString());
                    keyValuePairs.Add(new KeyValuePairs(alpha.Last().ToString(), pairs[0].pair));
                    alpha = alpha.Remove(alpha.Length - 1);

                }
                maxValue = pairs[0].count;

                pairs.Clear();
            }

            Console.WriteLine(temp);

            for (int i = 0; i < keyValuePairs.Count; i++)
            {
                Console.WriteLine($"{keyValuePairs[i].key} = {keyValuePairs[i].value}");
            }
        }

        public class Pairs
        {
            public string pair;
            public int count, appear;

            public Pairs(string pair, int count, int appear)
            {
                this.pair = pair;
                this.count = count;
                this.appear = appear;
            }
        }

        public class KeyValuePairs
        {
            public string key, value;

            public KeyValuePairs(string key, string value)
            {
                this.key = key;
                this.value = value;
            }
        }
    }
}
