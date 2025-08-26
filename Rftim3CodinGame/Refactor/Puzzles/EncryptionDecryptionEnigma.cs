namespace Rftim3CodinGame.Refactor.Puzzles
{
    public class EncryptionDecryptionEnigma
    {
        public EncryptionDecryptionEnigma()
        {
            string alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            //string operation = "ENCODE";
            string operation = "DECODE";
            //int pseudoRandomNumber = 4;
            //int pseudoRandomNumber = 7;
            int pseudoRandomNumber = 9;
            List<string> rotor = new()
            {
                "BDFHJLCPRTXVZNYEIWGAKMUSQO",
                "AJDKSIRUXBLHWTMCQGZNPYFVOE",
                "EKMFLGDQVZNTOWYHXUSPAIBRCJ"
            };

            //string message = "AAA";
            //string message = "WEATHERREPORTWINDYTODAY";
            string message = "PQSACVVTOISXFXCIAMQEM";
            //string message = "XPCXAUPHYQALKJMGKRWPGYHFTKRFFFNOUTZCABUAEHQLGXREZ";
            //string message = "EVERYONEISWELCOMEHEREEVERYONEISWELCOMEHERE";

            Solve(operation, pseudoRandomNumber, rotor, message, alpha);
        }

        private static void Solve(string operation, int pseudoRandomNumber, List<string> rotor, string message, string alpha)
        {

            if (operation == "ENCODE")
            {
                Encode(pseudoRandomNumber, rotor, message, rotor.Count, alpha);
            }
            else if (operation == "DECODE")
            {
                Decode(pseudoRandomNumber, rotor, message, rotor.Count, alpha);
            }
        }

        private static void Encode(int pseudoRandomNumber, List<string> rotor, string message, int n, string alpha)
        {
            int count = pseudoRandomNumber;
            string test = "";
            string[] test1 = new string[n];

            for (int j = 0; j < message.Length; j++)
            {
                int index;
                int location = alpha.IndexOf(message[j].ToString()) + count + j;
                if (location < alpha.Length) index = location;
                else
                {
                    while (location >= alpha.Length) location -= alpha.Length;
                    index = location;
                }

                test += alpha[index].ToString();
                Console.WriteLine(test);
            }

            for (int j = 0; j < n; j++)
            {
                for (int i = 0; i < test.Length; i++)
                {
                    test1[j] += rotor[j].Substring(alpha.IndexOf(test[i].ToString()), 1);
                }
                test = test1[j];
            }
            Console.WriteLine(test);
        }

        private static void Decode(int pseudoRandomNumber, List<string> rotor, string message, int n, string alpha)
        {
            int count = pseudoRandomNumber;
            string test = "";
            string[] test1 = new string[n];

            for (int j = n - 1; j >= 0; j--)
            {
                for (int i = 0; i < message.Length; i++)
                {
                    test1[j] += alpha.Substring(rotor[j].IndexOf(message[i].ToString()), 1);
                }
                message = test1[j];
                Console.WriteLine(message);
            }

            for (int i = 0; i < message.Length; i++)
            {
                int index = alpha.IndexOf(message[i].ToString()) - count - i;
                if (index >= 0) test += alpha[index].ToString();
                else
                {
                    while (index < 0)
                    {
                        index += alpha.Length;
                    }
                    test += alpha[index].ToString();
                }
            }
            Console.WriteLine(test);
        }
    }
}
