namespace Rftim3CodinGame.Refactor.Puzzles
{
    public class WallStreet
    {
        public WallStreet()
        {
            //List<Action> actions = new()
            //{
            //    new Action("AAA", "BUY", 1, 10.00F),
            //    new Action("AAA", "SELL", 1, 10.00F)
            //};

            //List<Action> actions = new()
            //{
            //    new Action("AAA", "BUY", 1, 10.00F),
            //    new Action("BBB", "SELL", 1, 10.00F),
            //    new Action("BBB", "BUY", 1, 10.00F)
            //};

            //List<Action> actions = new()
            //{
            //    new Action("ABC", "BUY", 1, 9.00F),
            //    new Action("ABC", "SELL", 1, 10.00F)
            //};

            //List<Action> actions = new()
            //{
            //    new Action("ABC", "BUY", 10, 23.50F),
            //    new Action("BBC", "BUY", 10, 13.50F),
            //    new Action("ABC", "SELL", 8, 23.50F),
            //    new Action("ABC", "SELL", 5, 23.50F),
            //    new Action("BBC", "BUY", 8, 13.50F),
            //    new Action("BBC", "BUY", 12, 13.50F),
            //    new Action("ABC", "BUY", 10, 23.50F),
            //    new Action("ABC", "SELL", 10, 23.45F),
            //    new Action("ABC", "BUY", 3, 23.45F),
            //    new Action("BBC", "BUY", 10, 13.50F),
            //    new Action("BBC", "SELL", 100, 13.45F)
            //};

            List<Action> actions = new()
            {
                new Action("ABC", "SELL", 11, 11.00F),
                new Action("AAA", "BUY", 10, 12.00F),
                new Action("ABC", "BUY", 10, 11.50F),
                new Action("DFE", "SELL", 10, 11.25F),
                new Action("DFE", "BUY", 1, 10.00F),
                new Action("AAB", "SELL", 8, 12.00F),
                new Action("ABC", "BUY", 8, 11.25F),
                new Action("AAA", "SELL", 10, 11.00F),
                new Action("AAB", "SELL", 1, 10.00F),
                new Action("DFE", "SELL", 11, 11.00F),
                new Action("DCE", "SELL", 9, 11.50F),
                new Action("DEF", "BUY", 10, 11.25F),
                new Action("DFE", "SELL", 1, 12.00F),
                new Action("AAB", "BUY", 8, 11.00F),
                new Action("ABC", "BUY", 8, 11.25F),
                new Action("AAB", "BUY", 9, 11.50F),
                new Action("AAB", "BUY", 12, 11.25F),
                new Action("AAB", "BUY", 12, 11.00F),
                new Action("AAB", "BUY", 9, 10.00F),
                new Action("DEF", "SELL", 8, 11.25F),
                new Action("DEF", "BUY", 1, 11.00F),
                new Action("DCE", "SELL", 1, 11.25F),
                new Action("AAA", "BUY", 10, 11.25F),
                new Action("DFE", "SELL", 1, 11.25F),
                new Action("DCE", "BUY", 1, 11.75F),
                new Action("DFE", "BUY", 11, 11.50F),
                new Action("DEF", "SELL", 9, 12.00F),
                new Action("DEF", "BUY", 1, 11.50F),
                new Action("ABC", "BUY", 8, 11.00F),
                new Action("DCE", "BUY", 12, 11.50F),
                new Action("ABC", "SELL", 9, 11.75F),
                new Action("DCE", "SELL", 12, 11.50F),
                new Action("DFE", "SELL", 10, 11.50F),
                new Action("DCE", "BUY", 9, 12.00F),
                new Action("DEF", "SELL", 12, 11.75F),
                new Action("DCE", "BUY", 9, 11.75F),
                new Action("AAA", "BUY", 12, 11.50F),
                new Action("AAB", "BUY", 12, 11.75F),
                new Action("ABC", "BUY", 12, 10.00F),
                new Action("DCE", "SELL", 9, 11.25F),
                new Action("DEF", "BUY", 11, 12.00F),
                new Action("DFE", "SELL", 8, 11.00F),
                new Action("DFE", "BUY", 11, 11.25F),
                new Action("AAB", "SELL", 8, 12.00F),
                new Action("DFE", "SELL", 10, 12.00F),
                new Action("DFE", "SELL", 12, 11.75F),
                new Action("ABC", "BUY", 12, 12.00F),
                new Action("ABC", "SELL", 10, 11.25F),
                new Action("DEF", "BUY", 10, 11.50F),
                new Action("AAB", "BUY", 9, 11.50F),
                new Action("ABC", "SELL", 11, 11.25F),
                new Action("DFE", "BUY", 8, 12.00F),
                new Action("AAA", "BUY", 11, 11.75F),
                new Action("AAA", "SELL", 9, 11.50F),
                new Action("DCE", "BUY", 9, 11.25F),
                new Action("DCE", "BUY", 12, 11.25F),
                new Action("DCE", "SELL", 1, 11.75F),
                new Action("DEF", "SELL", 11, 11.25F),
                new Action("AAB", "SELL", 8, 10.00F),
                new Action("DCE", "BUY", 11, 11.50F),
                new Action("AAB", "SELL", 1, 11.25F),
                new Action("DFE", "BUY", 8, 11.75F),
                new Action("ABC", "SELL", 11, 12.00F),
                new Action("DCE", "BUY", 1, 11.00F),
                new Action("AAA", "BUY", 8, 10.00F),
                new Action("DFE", "BUY", 12, 10.00F),
                new Action("AAB", "BUY", 8, 10.00F),
                new Action("AAA", "BUY", 8, 10.00F),
                new Action("DFE", "SELL", 12, 11.25F),
                new Action("DCE", "SELL", 12, 11.25F),
                new Action("DEF", "SELL", 11, 11.50F),
                new Action("DCE", "SELL", 9, 11.75F),
                new Action("AAB", "SELL", 11, 12.00F),
                new Action("ABC", "BUY", 1, 11.00F),
                new Action("AAA", "BUY", 8, 11.25F),
                new Action("AAA", "BUY", 8, 11.75F),
                new Action("AAA", "SELL", 10, 10.00F),
                new Action("DEF", "SELL", 1, 11.00F),
                new Action("AAB", "SELL", 11, 11.75F),
                new Action("DCE", "BUY", 8, 11.25F),
                new Action("AAA", "SELL", 9, 10.00F),
                new Action("ABC", "SELL", 10, 11.00F),
                new Action("ABC", "SELL", 8, 11.50F),
                new Action("AAA", "SELL", 12, 11.25F),
                new Action("DFE", "BUY", 8, 12.00F),
                new Action("DCE", "BUY", 11, 10.00F),
                new Action("DEF", "BUY", 10, 11.25F),
                new Action("DEF", "BUY", 1, 11.75F),
                new Action("ABC", "BUY", 9, 11.00F),
                new Action("DCE", "BUY", 8, 11.75F),
                new Action("DEF", "BUY", 8, 11.25F),
                new Action("DFE", "SELL", 9, 12.00F),
                new Action("DFE", "BUY", 10, 10.00F),
                new Action("DEF", "SELL", 12, 12.00F),
                new Action("DFE", "BUY", 10, 10.00F),
                new Action("ABC", "SELL", 11, 12.00F),
                new Action("ABC", "BUY", 10, 12.00F),
                new Action("AAB", "BUY", 8, 11.00F),
                new Action("DEF", "BUY", 11, 11.75F),
                new Action("AAA", "BUY", 10, 11.25F)
            };

            Solve(actions);
        }

        private static void Solve(List<Action> actions)
        {
            List<Trade> trades = new();
            List<Book> booksBuy = new();
            List<Book> booksSell = new();

            foreach (Action action in actions)
            {
                if (action.symbol == "ABC") Console.WriteLine($"{action.symbol}: {action.action}\t{action.qty}\t{string.Format("{0:0,0.00}", action.price)}");
                //Console.WriteLine($"{action.symbol}: {action.action}\t{action.qty}\t{string.Format("{0:0,0.00}", action.price)}");
            }
            Console.WriteLine();

            foreach (Action action in actions)
            {
                if (booksBuy.Count > 0) booksBuy = booksBuy.OrderBy(o => o.symbol).ThenByDescending(o => o.price).Where(o => o.qty > 0).ToList();
                if (booksSell.Count > 0) booksSell = booksSell.OrderBy(o => o.symbol).ThenBy(o => o.price).Where(o => o.qty > 0).ToList();

                if (action.action == "SELL")
                {
                    if (booksBuy.Count == 0) booksSell.Add(new Book(action.symbol, action.qty, action.price));
                    else
                    {
                        foreach (Book book in booksBuy)
                        {
                            if (action.symbol == book.symbol && action.qty <= book.qty && action.price <= book.price && book.qty > 0)
                            {
                                trades.Add(new Trade(action.symbol, action.qty, book.price));
                                book.qty -= action.qty;
                                action.qty = 0;
                                break;
                            }
                            else if (action.symbol == book.symbol && action.qty > book.qty && action.price <= book.price && book.qty > 0)
                            {
                                trades.Add(new Trade(action.symbol, book.qty, book.price));
                                action.qty -= book.qty;
                                book.qty = 0;
                            }
                        }

                        if (action.qty > 0) booksSell.Add(new Book(action.symbol, action.qty, action.price));
                    }
                }
                else if (action.action == "BUY")
                {
                    if (booksSell.Count == 0) booksBuy.Add(new Book(action.symbol, action.qty, action.price));
                    else
                    {
                        foreach (Book book in booksSell)
                        {
                            if (action.symbol == book.symbol && action.qty <= book.qty && action.price >= book.price && book.qty > 0)
                            {
                                trades.Add(new Trade(action.symbol, action.qty, book.price));
                                book.qty -= action.qty;
                                action.qty = 0;
                                break;
                            }
                            else if (action.symbol == book.symbol && action.qty > book.qty && action.price >= book.price && book.qty > 0)
                            {
                                trades.Add(new Trade(action.symbol, book.qty, book.price));
                                action.qty -= book.qty;
                                book.qty = 0;
                            }
                        }

                        if (action.qty > 0) booksBuy.Add(new Book(action.symbol, action.qty, action.price));
                    }
                }
            }

            foreach (Trade trade in trades)
            {
                if (trade.symbol == "ABC") Console.WriteLine($"{trade.symbol} {trade.qty} {string.Format("{0:0,0.00}", trade.price)}");
                //Console.WriteLine($"{trade.symbol} {trade.qty} {string.Format("{0:0,0.00}", trade.price)}");
            }

            if (trades.Count == 0) Console.WriteLine($"NO TRADE");
        }

        class Action
        {
            public string symbol, action;
            public int qty;
            public float price;

            public Action(string symbol, string action, int qty, float price)
            {
                this.symbol = symbol;
                this.action = action;
                this.qty = qty;
                this.price = price;
            }
        }

        class Book
        {
            public string symbol;
            public int qty;
            public float price;

            public Book(string symbol, int qty, float price)
            {
                this.symbol = symbol;
                this.qty = qty;
                this.price = price;
            }
        }

        class Trade
        {
            public string symbol;
            public int qty;
            public float price;

            public Trade(string symbol, int qty, float price)
            {
                this.symbol = symbol;
                this.qty = qty;
                this.price = price;
            }
        }
    }
}
