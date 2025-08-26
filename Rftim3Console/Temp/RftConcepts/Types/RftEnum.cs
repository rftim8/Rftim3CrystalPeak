namespace Rftim3Console.Temp.RftConcepts.Types
{
    public class RftEnum
    {
        [Flags]
        private enum Seasons
        {
            None = 0,
            Spring = 1,
            Summer = 2,
            Autumn = 4,
            Winter = 8,
            All = Spring | Summer | Autumn | Winter
        }

        public RftEnum()
        {
            RftExample();
        }

        private static void RftExample()
        {
            Seasons a = (Seasons)8;
            Console.WriteLine($"{Seasons.Spring | Seasons.Winter}");
            Console.WriteLine($"{a}");
            Console.WriteLine($"{Seasons.Summer | Seasons.All}");
            Console.WriteLine($"{Seasons.Summer & Seasons.All}");
            Console.WriteLine($"{Seasons.Summer ^ Seasons.All}");
        }
    }
}
