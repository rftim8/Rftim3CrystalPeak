using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using System.Globalization;

namespace Rftim3AdventOfCode.Refactor
{
    public class _04_PassportProcessing : I_04_PassportProcessing
    {
        #region Static
        private readonly List<string>? data;

        public _04_PassportProcessing()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_04_PassportProcessing));
        }

        /// <summary>
        /// You arrive at the airport only to realize that you grabbed your North Pole Credentials instead of your passport. 
        /// While these documents are extremely similar, North Pole Credentials aren't issued by a country and therefore aren't actually valid documentation 
        /// for travel in most of the world.
        /// 
        /// It seems like you're not the only one having problems, though; a very long line has formed for the automatic passport scanners,
        /// and the delay could upset your travel itinerary.
        /// 
        /// Due to some questionable network security, you realize you might be able to solve both of these problems at the same time.
        /// 
        /// The automatic passport scanners are slow because they're having trouble detecting which passports have all required fields. 
        /// The expected fields are as follows:
        /// 
        /// byr(Birth Year)
        /// iyr(Issue Year)
        /// eyr(Expiration Year)
        /// hgt(Height)
        /// hcl(Hair Color)
        /// ecl(Eye Color)
        /// pid(Passport ID)
        /// cid(Country ID)
        /// Passport data is validated in batch files(your puzzle input). Each passport is represented as a sequence of key:value pairs 
        /// separated by spaces or newlines.Passports are separated by blank lines.
        /// 
        /// Here is an example batch file containing four passports:
        /// 
        /// ecl:gry pid:860033327 eyr:2020 hcl:#fffffd
        /// byr:1937 iyr:2017 cid:147 hgt:183cm
        /// 
        /// iyr:2013 ecl:amb cid:350 eyr:2023 pid:028048884
        /// hcl:#cfa07d byr:1929
        /// 
        /// hcl:#ae17e1 iyr:2013
        /// eyr:2024
        /// ecl:brn pid:760753108 byr:1931
        /// hgt:179cm
        /// hcl:#cfa07d eyr:2025 pid:166559648
        /// iyr:2011 ecl:brn hgt:59in
        /// The first passport is valid - all eight fields are present.The second passport is invalid - it is missing hgt (the Height field).
        /// 
        /// The third passport is interesting; the only missing field is cid, so it looks like data from North Pole Credentials, not a passport at all! 
        /// Surely, nobody would mind if you made the system temporarily ignore missing cid fields.Treat this "passport" as valid.
        /// The fourth passport is missing two fields, cid and byr.Missing cid is fine, but missing any other field is not, so this passport is invalid.
        /// 
        /// According to the above rules, your improved system would report 2 valid passports.
        /// 
        /// Count the number of valid passports - those that have all required fields. Treat cid as optional.In your batch file, how many passports are valid?
        /// </summary>
        [Benchmark]
        public int PartOne() => PartOne0(data!);

        private static int PartOne0(List<string> input)
        {
            int r = 0;

            List<string> x = [];
            int c = 0;
            foreach (string item in input)
            {
                if (string.IsNullOrEmpty(item))
                {
                    foreach (string item1 in x)
                    {
                        if (item1.Contains("byr:")) c++;
                        if (item1.Contains("iyr:")) c++;
                        if (item1.Contains("eyr:")) c++;
                        if (item1.Contains("hgt:")) c++;
                        if (item1.Contains("hcl:")) c++;
                        if (item1.Contains("ecl:")) c++;
                        if (item1.Contains("pid:")) c++;
                    }

                    if (c == 7) r++;

                    c = 0;
                    x.Clear();
                }
                else x.Add(item);
            }
            if (x.Count != 0)
            {
                foreach (string item1 in x)
                {
                    if (item1.Contains("byr:")) c++;
                    if (item1.Contains("iyr:")) c++;
                    if (item1.Contains("eyr:")) c++;
                    if (item1.Contains("hgt:")) c++;
                    if (item1.Contains("hcl:")) c++;
                    if (item1.Contains("ecl:")) c++;
                    if (item1.Contains("pid:")) c++;
                }

                if (c == 7) r++;
            }

            return r;
        }

        /// <summary>
        /// The line is moving more quickly now, but you overhear airport security talking about how passports with invalid data are getting through. 
        /// Better add some data validation, quick!
        /// 
        /// You can continue to ignore the cid field, but each other field has strict rules about what values are valid for automatic validation:
        /// 
        /// byr(Birth Year) - four digits; at least 1920 and at most 2002.
        /// iyr(Issue Year) - four digits; at least 2010 and at most 2020.
        /// eyr(Expiration Year) - four digits; at least 2020 and at most 2030.
        /// hgt(Height) - a number followed by either cm or in:
        /// If cm, the number must be at least 150 and at most 193.
        /// If in, the number must be at least 59 and at most 76.
        /// hcl(Hair Color) - a # followed by exactly six characters 0-9 or a-f.
        /// ecl(Eye Color) - exactly one of: amb blu brn gry grn hzl oth.
        /// pid(Passport ID) - a nine-digit number, including leading zeroes.
        /// cid(Country ID) - ignored, missing or not.
        /// Your job is to count the passports where all required fields are both present and valid according to the above rules.Here are some example values:
        /// 
        /// byr valid:   2002
        /// byr invalid: 2003
        /// 
        /// hgt valid:   60in
        /// hgt valid:   190cm
        /// hgt invalid: 190in
        /// hgt invalid: 190
        /// 
        /// hcl valid:   #123abc
        /// hcl invalid: #123abz
        /// hcl invalid: 123abc
        /// 
        /// ecl valid:   brn
        /// ecl invalid: wat
        /// 
        /// pid valid:   000000001
        /// pid invalid: 0123456789
        /// Here are some invalid passports:
        /// 
        /// eyr:1972 cid:100
        /// hcl:#18171d ecl:amb hgt:170 pid:186cm iyr:2018 byr:1926
        /// 
        /// iyr:2019
        /// hcl:#602927 eyr:1967 hgt:170cm
        /// ecl:grn pid:012533040 byr:1946
        /// 
        /// hcl:dab227 iyr:2012
        /// ecl:brn hgt:182cm pid:021572410 eyr:2020 byr:1992 cid:277
        /// 
        /// hgt:59cm ecl:zzz
        /// eyr:2038 hcl:74454a iyr:2023
        /// pid:3556412378 byr:2007
        /// Here are some valid passports:
        /// 
        /// pid:087499704 hgt:74in ecl:grn iyr:2012 eyr:2030 byr:1980
        /// hcl:#623a2f
        /// 
        /// eyr:2029 ecl:blu cid:129 byr:1989
        /// iyr:2014 pid:896056539 hcl:#a97842 hgt:165cm
        /// 
        /// hcl:#888785
        /// hgt:164cm byr:2001 iyr:2015 cid:88
        /// pid:545766238 ecl:hzl
        /// eyr:2022
        /// 
        /// iyr:2010 hgt:158cm hcl:#b6652a ecl:blu byr:1944 eyr:2021 pid:093154719
        /// Count the number of valid passports - those that have all required fields and valid values.Continue to treat cid as optional.
        /// In your batch file, how many passports are valid?
        /// </summary>        
        [Benchmark]
        public int PartTwo() => PartTwo0(data!);

        private static int PartTwo0(List<string> input)
        {
            int r = 0;

            List<string> x = [];
            int c = 0;
            foreach (string item in input)
            {
                if (string.IsNullOrEmpty(item))
                {
                    List<string> y = [];

                    foreach (string item1 in x)
                    {
                        y.AddRange(item1.Split(' '));
                    }

                    foreach (string item1 in y)
                    {
                        Console.Write($"{item1} ");
                        if (item1.Contains("byr"))
                        {
                            if (int.Parse(item1.Split(':')[1]) >= 1920 && int.Parse(item1.Split(':')[1]) <= 2002) c++;
                        }
                        if (item1.Contains("iyr"))
                        {
                            if (int.Parse(item1.Split(':')[1]) >= 2010 && int.Parse(item1.Split(':')[1]) <= 2020) c++;
                        }
                        if (item1.Contains("eyr"))
                        {
                            if (int.Parse(item1.Split(':')[1]) >= 2020 && int.Parse(item1.Split(':')[1]) <= 2030) c++;
                        }
                        if (item1.Contains("hgt"))
                        {
                            if (item1.Contains("cm"))
                            {
                                if (int.Parse(item1.Split(':')[1].Replace("cm", "")) >= 150 && int.Parse(item1.Split(':')[1].Replace("cm", "")) <= 193) c++;
                            }
                            else if (item1.Contains("in"))
                            {
                                if (int.Parse(item1.Split(':')[1].Replace("in", "")) >= 59 && int.Parse(item1.Split(':')[1].Replace("in", "")) <= 76) c++;
                            }
                        }
                        if (item1.Contains("hcl"))
                        {
                            if (item1.Contains('#') && item1.Split(':')[1].Length == 7)
                            {
                                if (int.TryParse(item1.Split(':')[1].Replace("#", ""), NumberStyles.HexNumber, CultureInfo.InvariantCulture, out int value)) c++;
                            }
                        }
                        if (item1.Contains("ecl"))
                        {
                            if (item1.Split(':')[1] == "amb" ||
                                item1.Split(':')[1] == "blu" ||
                                item1.Split(':')[1] == "brn" ||
                                item1.Split(':')[1] == "gry" ||
                                item1.Split(':')[1] == "grn" ||
                                item1.Split(':')[1] == "hzl" ||
                                item1.Split(':')[1] == "oth")
                                c++;
                        }
                        if (item1.Contains("pid"))
                        {
                            if (int.TryParse(item1.Split(':')[1], out int value) && item1.Split(':')[1].Length == 9) c++;
                        }
                    }
                    Console.WriteLine();
                    Console.WriteLine(c);

                    if (c == 7) r++;

                    c = 0;
                    x.Clear();
                }
                else x.Add(item);
            }
            if (x.Count != 0)
            {
                List<string> y = [];

                foreach (string item1 in x)
                {
                    y.AddRange(item1.Split(' '));
                }

                foreach (string item1 in y)
                {
                    if (item1.Contains("byr"))
                    {
                        if (int.Parse(item1.Split(':')[1]) >= 1920 && int.Parse(item1.Split(':')[1]) <= 2002) c++;
                    }
                    if (item1.Contains("iyr"))
                    {
                        if (int.Parse(item1.Split(':')[1]) >= 2010 && int.Parse(item1.Split(':')[1]) <= 2020) c++;
                    }
                    if (item1.Contains("eyr"))
                    {
                        if (int.Parse(item1.Split(':')[1]) >= 2020 && int.Parse(item1.Split(':')[1]) <= 2030) c++;
                    }
                    if (item1.Contains("hgt"))
                    {
                        if (item1.Contains("cm"))
                        {
                            if (int.Parse(item1.Split(':')[1].Replace("cm", "")) >= 150 && int.Parse(item1.Split(':')[1].Replace("cm", "")) <= 193) c++;
                        }
                        else if (item1.Contains("in"))
                        {
                            if (int.Parse(item1.Split(':')[1].Replace("in", "")) >= 59 && int.Parse(item1.Split(':')[1].Replace("in", "")) <= 76) c++;
                        }
                    }
                    if (item1.Contains("hcl"))
                    {
                        if (item1.Contains('#') && item1.Split(':')[1].Length == 7)
                        {
                            if (int.TryParse(item1.Split(':')[1].Replace("#", ""), NumberStyles.HexNumber, CultureInfo.InvariantCulture, out int value)) c++;
                        }
                    }
                    if (item1.Contains("ecl"))
                    {
                        if (item1.Split(':')[1] == "amb" ||
                            item1.Split(':')[1] == "blu" ||
                            item1.Split(':')[1] == "brn" ||
                            item1.Split(':')[1] == "gry" ||
                            item1.Split(':')[1] == "grn" ||
                            item1.Split(':')[1] == "hzl" ||
                            item1.Split(':')[1] == "oth")
                            c++;
                    }
                    if (item1.Contains("pid"))
                    {
                        if (int.TryParse(item1.Split(':')[1], out int value) && item1.Split(':')[1].Length == 9) c++;
                    }
                }

                if (c == 7) r++;
            }

            return r;
        }
        #endregion

        #region UnitTest
        public static int PartOne_Test(List<string> data) => PartOne0(data);

        public static int PartTwo_Test(List<string> data) => PartTwo0(data);
        #endregion

        #region Host
        private readonly IRftAdventOfCodeHostData? RftAdventOfCodeHostData;

        public _04_PassportProcessing(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_04_PassportProcessing));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}