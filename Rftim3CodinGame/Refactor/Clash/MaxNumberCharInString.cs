namespace Rftim3CodinGame.Refactor.Clash
{
    public class MaxNumberCharInString
    {
        public MaxNumberCharInString()
        {
            int n = 5;
            List<string> x =
            [
                "Hello",
                "Hellwerqqwero",
                "Hellorerwr",
                "Helewqrwerrrlo",
                "Hell   qwerwero"
            ];

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(x[i].ToLower().Where(char.IsLetter).GroupBy(m => m).OrderBy(m => m.Count()).Last().Key);
            }
        }
    }
}
