namespace Rftim3CodinGame.Refactor.Optimization
{
    public class CodeOfTheRings
    {
        private static int counter = 0;

        public CodeOfTheRings()
        {
            List<string> x =
            [
                "AZ",
                "MINAS",
                "UMNE TALMAR RAHTAINE NIXENEN UMIR",
                "OOOOOOOOOOOOOOO",
                "BABCDEDCBABCDCB",
                "ZAZYA YAZ",
                "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA",
                "NONONONONONONONONONONONONONONONONONONONO",
                "GUZ MUG ZOG GUMMOG ZUMGUM ZUM MOZMOZ MOG ZOGMOG GUZMUGGUM",
                "SSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE",
                "BBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB",
                "GAAVOOOLLUGAAVOOOLLUGAAVOOOLLUGAAVOOOLLUGAAVOOOLLUGAAVOOOLLUGAAVOOOLLUGAAVOOOLLU",
                "O OROFARNE LASSEMISTA CARNIMIRIE O ROWAN FAIR UPON YOUR HAIR HOW WHITE THE BLOSSOM LAY",
                "ALROG BALROG BALROG BALROG BALROG BALROG BALROG BALROG BALROG BALROG BALROG BALROG BALROG BALROG BALROG BALROG BALROG BALROG BALROG BALROG BALROG BALROG BALROG BALROG BALROG BALROG B",
                "OYLO Y OOOYYY LLLYOOYY O YO YLOO O OLY YL OY L YY L YOO LYL YYYOOYLOL L Y O YYYLLOY O L YYYOOYLOL YOLOLOY",
                "TUVWXYZ ABCDEFGHIJ",
                "ABCDEFGHIJKLMNOPQRSTUVWXYZAABCDEFGHIJKLMNOPQRSTUVWXYZAABCDEFGHIJKLMNOPQRSTUVWXYZAABCDEFGHIJKLMNOPQRSTUVWXYZAABCDEFGHIJKLMNOPQRSTUVWXYZAABCDEFGHIJKLMNOPQRSTUVWXYZAABCDEFGHIJKLMNOPQRSTUVWXYZAABCDEFGHIJKLMNOPQRSTUVWXYZAABCDEFGHIJKLMNOPQRSTUVWXYZAABCDEFGHIJKLMNOPQRSTUVWXYZAABCDEFGHIJKLMNOPQRSTUVWXYZA",
                "OROZOLOKOTONOFOGOMOJOHOFOTOLOPO ODOYOWOAOZO OPOJOTO OROXOVOXO OC",
                "A B C D E F G H I J K L M N O P Q R S T U V W X Y Z",
                "FIFOFIFOFIFOFIFOFIFOFIFOFIFOFIFOFIFOFIFOFIFOFIFO FUM FUM FUM FUM FUM FUM FUM FUM FUM FUM FUM FUM FUM FUM FUM",
                "GY GY GY GY GY GY GY GY GY GY GY GY GY GY GY GY GY GY GY GY GY GY GY GY GY GY GY GY HIJIHIJIJIJIHIHIHIJIHIJIHIJIJIJIHHHIJIJHIHH",
                "MELLON MORIAMELLON MORIAMORIAMORIAMELLON MELLON MELLON MORIAMORIAMELLON MELLON MORIA",
                "ZAZAZAZAZAZAZAZAZAZAZAZAZAZAZAZAZAZAZAZACEGIKMOQSUWY BDFHJLNPRTVXZACEGIKMOQSUWY BDFHJLNPRTVXZA",
                "THREE RINGS FOR THE ELVEN KINGS UNDER THE SKY SEVEN FOR THE DWARF LORDS IN THEIR HALLS OF STONE NINE FOR MORTAL MEN DOOMED TO DIE ONE FOR THE DARK LORD ON HIS DARK THRONEIN THE LAND OF MORDOR WHERE THE SHADOWS LIE ONE RING TO RULE THEM ALL ONE RING TO FIND THEM ONE RING TO BRING THEM ALL AND IN THE DARKNESS BIND THEM IN THE LAND OF MORDOR WHERE THE SHADOWS LIE"
            ];
            foreach (string item in x)
            {
                Solve(item);
            }
            Console.WriteLine($"Counter: {counter}");
        }

        private static void Solve(string m)
        {
            string alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ ";
            int a = alpha.Length / 2;
            int b = alpha.Length;

            List<(char, int)> words = m.Select(o => (o, 0)).Distinct().ToList();

            for (int i = 0; i < words.Count; i++)
            {
                words[i] = (words[i].Item1, m.Select(o => o).Where(o => o == words[i].Item1).Count());
            }

            words = [.. words.OrderByDescending(o => o.Item2).ThenBy(o => o.Item1)];

            Console.WriteLine(m);
            foreach ((char, int) item in words)
            {
                Console.WriteLine($"{item.Item1}: {item.Item2}");
            }

            char c = m[0];
            string go = string.Empty;
            for (int i = 0; i < m.Length; i++)
            {
                int i1 = alpha.IndexOf(m[i]) + 1;
                int i2 = alpha.IndexOf(c) + 1;

                if (i == 0)
                {
                    if (i2 > a) go += string.Join('\0', Enumerable.Repeat('-', b - i2));
                    else go += string.Join('\0', Enumerable.Repeat('-', i2));
                    go += '.';
                }
                else
                {
                    if (i1 > i2)
                    {
                        if (i1 - i2 > a) go += string.Join('\0', Enumerable.Repeat('-', b - i1 + i2));
                        else go += string.Join('\0', Enumerable.Repeat('+', i1 - i2));
                        go += '.';
                    }
                    else if (i1 < i2)
                    {
                        if (i2 - i1 > a) go += string.Join('\0', Enumerable.Repeat('+', b - i2 + i1));
                        else go += string.Join('\0', Enumerable.Repeat('-', i2 - i1));
                        go += '.';
                    }
                    else go += '.';
                }
                c = m[i];
            }

            counter += go.Length;
            Console.WriteLine(go);
        }
    }
}
