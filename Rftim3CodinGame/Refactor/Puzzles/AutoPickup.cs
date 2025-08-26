namespace Rftim3CodinGame.Refactor.Puzzles
{
    public class AutoPickup
    {
        public AutoPickup()
        {
            //string packet = "101001010";
            //string packet = "10100010101001011";
            //string packet = "00100101110100011";
            string packet = "111000111010010110010011101";

            Solve(packet);
        }

        private static void Solve(string packet)
        {
            string response = "";

            while (packet.Length > 0)
            {
                string id = packet[..3];
                string infoLengthString = packet.Substring(3, 4);
                int infoLength = Convert.ToInt32(infoLengthString, 2);
                string info = packet.Substring(7, infoLength);

                if (id == "101")
                {
                    packet = packet[(3 + 4 + infoLength)..];
                    response += $"001{infoLengthString}{info}";
                }
                else packet = packet[(3 + 4 + infoLength)..];

                #region Testing
                Console.WriteLine($"Id: {id}\nPacketLength: {infoLength}\nInfo: {info}");
                #endregion
            }

            Console.WriteLine($"{response}");
        }
    }
}
