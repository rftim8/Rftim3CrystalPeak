namespace Rftim3CodinGame.Refactor.Puzzles
{
    public class TestBeforeValidate
    {
        public TestBeforeValidate()
        {
            List<string> actions = new()
            {
                "Connect",
                "Disconnect",
                "Authenticate",
                "Play",
                "Share",
                "Win"
            };
            List<string> orders = new()
            {
                "Share before Disconnect",
                "Share after Win",
                "Play after Connect",
                "Play before Win"
            };

            Solve(actions, orders);
        }

        private static void Solve(List<string> actions, List<string> orders)
        {
            for (int i = 0; i < orders.Count; i++)
            {
                foreach (string order in orders)
                {
                    List<string> ranks = order.Split(' ').ToList();

                    if (ranks[1] == "before")
                    {
                        if (actions.IndexOf(ranks[2]) < actions.IndexOf(ranks[0]))
                        {
                            actions.Remove(ranks[2]);
                            actions.Insert(actions.IndexOf(ranks[0]) + 1, ranks[2]);
                        }
                    }
                    else
                    {
                        if (actions.IndexOf(ranks[0]) < actions.IndexOf(ranks[2]))
                        {
                            actions.Remove(ranks[0]);
                            actions.Insert(actions.IndexOf(ranks[2]) + 1, ranks[0]);
                        }
                    }
                }
            }

            foreach (string action in actions)
            {
                Console.WriteLine($"{action}");
            }
        }
    }
}
