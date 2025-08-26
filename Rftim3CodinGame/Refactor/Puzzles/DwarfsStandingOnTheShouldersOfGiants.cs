namespace Rftim3CodinGame.Refactor.Puzzles
{
    public class DwarfsStandingOnTheShouldersOfGiants
    {
        public DwarfsStandingOnTheShouldersOfGiants()
        {
            List<Dwarf> dwarves = new()
            {
                new Dwarf(new List<int>() { 7, 2 }),
                new Dwarf(new List<int>() { 8, 9 }),
                new Dwarf(new List<int>() { 1, 6 }),
                new Dwarf(new List<int>() { 6, 9 }),
                new Dwarf(new List<int>() { 1, 7 }),
                new Dwarf(new List<int>() { 1, 2 }),
                new Dwarf(new List<int>() { 3, 9 }),
                new Dwarf(new List<int>() { 2, 3 }),
                new Dwarf(new List<int>() { 6, 3 })
            };

            Solve(dwarves);
        }

        private static void Solve(List<Dwarf> dwarves)
        {
            for (int i = 0; i < dwarves.Count; i++)
            {
                for (int j = 0; j < dwarves.Count; j++)
                {
                    if (i != j)
                    {
                        if (dwarves[i].dwarfs.First() == dwarves[j].dwarfs.Last())
                        {
                            dwarves[j].dwarfs = dwarves[j].dwarfs.Concat(dwarves[i].dwarfs).ToList().Distinct().ToList();
                        }
                    }
                }
            }

            Console.WriteLine($"{dwarves.Max(o => o.dwarfs.Count)}");
        }

        class Dwarf
        {
            public List<int> dwarfs;

            public Dwarf(List<int> dwarfs)
            {
                this.dwarfs = dwarfs;
            }
        }
    }
}
