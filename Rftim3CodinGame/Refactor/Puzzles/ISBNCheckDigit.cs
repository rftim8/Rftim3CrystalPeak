namespace Rftim3CodinGame.Refactor.Puzzles
{
    public class ISBNCheckDigit
    {
        public ISBNCheckDigit()
        {
            const int n = 8;
            string alpha = "abcdefghijklmnopqrstuvwxyz";

            string[] ISBN = new string[n]
            {
                "0306406152",
                "013603599X",
                "1145185215X",
                "9780306406157",
                "9780306406154",
                "978043551907X",
                "0387372350",
                "9780133661750"
            };

            Solve(n, alpha, ISBN);
        }

        private static void Solve(int n, string alpha, string[] ISBN)
        {
            List<string> invalid = new();
            int counter = 0;

            for (int i = 0; i < n; i++)
            {
                string isbn = ISBN[i];

                bool checkISBNLength = isbn.Length == 10 || isbn.Length == 13;
                if (checkISBNLength)
                {
                    bool checkISBNAlpha = false;
                    for (int j = 0; j < isbn.Length - 1; j++)
                    {
                        if (alpha.Contains(isbn[j].ToString()) || alpha.ToUpper().Contains(isbn[j].ToString()))
                        {
                            checkISBNAlpha = true;
                            j = isbn.Length - 1;
                        }
                    }

                    if (checkISBNAlpha)
                    {
                        invalid.Add(isbn);
                        counter++;
                    }
                    else
                    {
                        if (isbn.Length == 10)
                        {
                            int result = 0;
                            int weight = 10;

                            for (int k = 0; k < isbn.Length - 1; k++)
                            {
                                result += int.Parse(isbn[k].ToString()) * weight;
                                weight--;
                            }

                            if (isbn[^1].ToString() != "X")
                            {
                                if (result % 11 != 0)
                                {
                                    if (11 - result % 11 != int.Parse(isbn[^1].ToString()))
                                    {
                                        Console.WriteLine(result);
                                        invalid.Add(isbn);
                                        counter++;
                                    }
                                }
                                else
                                {
                                    if (int.Parse(isbn[^1].ToString()) != 0)
                                    {
                                        Console.WriteLine(result);
                                        invalid.Add(isbn);
                                        counter++;
                                    }
                                }
                            }
                            else
                            {
                                if (11 - result % 11 != 10)
                                {
                                    invalid.Add(isbn);
                                    counter++;
                                }
                            }
                        }
                        else if (isbn.Length == 13)
                        {
                            int result = 0;
                            int weight = 12;

                            for (int k = 0; k < isbn.Length - 1; k++)
                            {
                                if (weight % 2 == 0)
                                {
                                    result += int.Parse(isbn[k].ToString()) * 1;
                                    weight--;
                                }
                                else
                                {
                                    result += int.Parse(isbn[k].ToString()) * 3;
                                    weight--;
                                }
                            }

                            if (!isbn.EndsWith("X"))
                            {
                                if (result % 10 != 0)
                                {
                                    if (10 - result % 10 != int.Parse(isbn[^1].ToString()))
                                    {
                                        invalid.Add(isbn);
                                        counter++;
                                    }

                                }
                                else
                                {
                                    if (int.Parse(isbn[^1].ToString()) != 0)
                                    {
                                        invalid.Add(isbn);
                                        counter++;
                                    }
                                }
                            }
                            else
                            {
                                invalid.Add(isbn);
                                counter++;
                            }
                        }
                    }
                }
                else
                {
                    invalid.Add(isbn);
                    counter++;
                }
            }

            Console.WriteLine($"{counter} invalid:");
            for (int i = 0; i < invalid.Count; i++)
            {
                Console.WriteLine($"{invalid[i]}");
            }
        }
    }
}
