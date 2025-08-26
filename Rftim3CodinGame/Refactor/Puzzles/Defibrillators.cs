namespace Rftim3CodinGame.Refactor.Puzzles
{
    public class Defibrillators
    {
        public Defibrillators()
        {
            string lon = "3,879483";
            string lat = "43,608177";
            int n = 3;

            string[] locations = {
                "1; Maison de la Prevention Sante; 6 rue Maguelone 340000 Montpellier; ; 3,87952263361082; 43,6071285339217",
                "2; Hotel de Ville; 1 place Georges Freche 34267 Montpellier; ; 3,89652239197876; 43,5987299452849",
                "3; Zoo de Lunaret; 50 avenue Agropolis 34090 Mtp; ; 3,87388031141133; 43,6395872778854"
            };

            Solve(lon, lat, n, locations);
        }

        private static void Solve(string lon, string lat, int n, string[] locations)
        {
            double temp = 0.0;
            string[] location = new string[n];
            int index = 0;
            int exact = 0;

            for (int i = 0; i < n; i++)
            {
                string defib = locations[i];
                location[i] = defib;

                double LON2 = double.Parse(defib.Split(';')[4].Replace(",", "."));
                double LAT2 = double.Parse(defib.Split(';')[5].Replace(",", "."));

                double LON1 = double.Parse(lon.Replace(",", "."));
                double LAT1 = double.Parse(lat.Replace(",", "."));

                if (LON1 != LON2 && LAT1 != LAT2)
                {
                    double x = (LON1 - LON2) * Math.Cos((LAT2 + LAT1) / 2);
                    double y = LAT1 - LAT2;
                    double d = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2)) * 6371;

                    if (d < temp)
                    {
                        temp = d;
                        index = i;
                    }

                    if (temp == 0)
                    {
                        temp = d;
                        index = i;
                    }
                }
                else exact = i;
            }

            Console.WriteLine(exact == 0 ? location[index].Split(';')[1] : location[exact].Split(';')[1]);
        }
    }
}
