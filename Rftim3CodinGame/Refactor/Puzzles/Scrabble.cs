namespace Rftim3CodinGame.Refactor.Puzzles
{
    public class Scrabble
    {
        public Scrabble()
        {
            //List<Word> words = new()
            //{
            //    new Word("some", 0),
            //    new Word("first", 0),
            //    new Word("potsie", 0),
            //    new Word("day", 0),
            //    new Word("could", 0),
            //    new Word("postie", 0),
            //    new Word("from", 0),
            //    new Word("have", 0),
            //    new Word("back", 0),
            //    new Word("this", 0)
            //};
            //string letters = "sopitez";

            List<Word> words = new()
            {
                new Word("qzyoq", 0, true),
                new Word("azejuy", 0, true),
                new Word("kqjsdh", 0, true),
                new Word("aeiou", 0, true),
                new Word("qsjkdh", 0, true)
            };
            string letters = "qzaeiou";

            Solve(words, letters);
        }

        private static void Solve(List<Word> words, string letters)
        {
            List<Score> scores = new()
            {
                new Score("e", 1),
                new Score("a", 1),
                new Score("i", 1),
                new Score("o", 1),
                new Score("n", 1),
                new Score("r", 1),
                new Score("t", 1),
                new Score("l", 1),
                new Score("s", 1),
                new Score("u", 1),
                new Score("d", 2),
                new Score("g", 2),
                new Score("b", 3),
                new Score("c", 3),
                new Score("m", 3),
                new Score("p", 3),
                new Score("f", 4),
                new Score("h", 4),
                new Score("v", 4),
                new Score("w", 4),
                new Score("y", 4),
                new Score("k", 5),
                new Score("j", 8),
                new Score("x", 8),
                new Score("q", 10),
                new Score("z", 10),
            };

            foreach (Word word in words)
            {
                int counter = 0;
                foreach (char item in letters)
                {
                    if (word.word.Contains(item))
                    {
                        foreach (Score score in scores)
                        {
                            if (item.ToString() == score.letter) word.value += score.value;
                        }
                        counter++;
                    }
                }
                if (counter < word.word.Length) word.valid = false;
            }

            foreach (Word word in words)
            {
                Console.WriteLine($"{word.word}: {word.value} -> {word.valid}");
            }

            List<Word> validWords = words.Where(o => o.valid).ToList();

            int x = validWords[0].value;
            string y = validWords[0].word;

            foreach (Word word in validWords)
            {
                if (word.value > x)
                {
                    x = word.value;
                    y = word.word;
                }
            }

            Console.WriteLine(y);
        }

        class Score
        {
            public string letter;
            public int value;

            public Score(string letter, int value)
            {
                this.letter = letter;
                this.value = value;
            }
        }

        class Word
        {
            public string word;
            public int value;
            public bool valid;

            public Word(string word, int value, bool valid)
            {
                this.word = word;
                this.value = value;
                this.valid = valid;
            }
        }
    }
}
