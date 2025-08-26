namespace Rftim3CodinGame.Refactor.Puzzles
{
    public class NGRBasicRadar
    {
        public NGRBasicRadar()
        {
            List<string> list =
            [
                "FH-790-HH A21-42 1620040132000",
                "ET-318-NQ A21-42 1620040623000",
                "BV-670-GV A21-42 1620040665000",
                "FH-790-HH A21-55 1620040747000",
                "DV-046-YY A21-42 1620040839000",
                "ET-318-NQ A21-55 1620041044000",
                "BV-670-GV A21-55 1620041071000",
                "FZ-792-EC A21-42 1620041284000",
                "DV-046-YY A21-55 1620041326000",
                "FZ-792-EC A21-55 1620041633000",
                "BP-301-UL A21-42 1620041863000",
                "BV-047-TT A21-42 1620042133000",
                "BP-301-UL A21-55 1620042487000",
                "BV-047-TT A21-55 1620042570000",
                "FT-918-CZ A21-42 1620042842000",
                "DZ-507-JZ A21-42 1620043072000",
                "DF-857-ZR A21-42 1620043398000",
                "FT-918-CZ A21-55 1620043609000",
                "DZ-507-JZ A21-55 1620043803000",
                "DF-857-ZR A21-55 1620043835000"
            ];

            Solve(list);
        }

        private static void Solve(List<string> l)
        {
            l = [.. l.OrderBy(o => o.Split(' ')[0])];

            for (int i = 0; i < l.Count; i++)
            {
                if (i % 2 == 0)
                {
                    string car = l[i].Split(' ')[0];
                    string plate1 = l[i].Split(' ')[1];
                    string plate2 = l[i + 1].Split(' ')[1];
                    long time1 = long.Parse(l[i].Split(' ')[2]);
                    long time2 = long.Parse(l[i + 1].Split(' ')[2]);
                    float timeCar = (float)((float)((time2 - time1) / 1000) / 60) / 60;
                    float timeIdeal = 13F / 130F;
                    int speed = (int)(13 / timeCar);

                    if (timeCar < timeIdeal) Console.WriteLine($"{car} = {plate1} -> {plate2}: {timeIdeal} {timeCar} {speed}");
                }
            }
        }
    }
}
